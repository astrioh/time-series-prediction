using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace vremRyad
{
    public partial class Form1 : Form
    {
        TimeSeries timeSeries;
        private char separator = ';';
        private string openFileName = string.Empty;

        public Form1()
        {
            InitializeComponent();
            this.timeSeries = new TimeSeries();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                dataGridViewTimeSeries.Columns.Clear();

                openFileName = openFileDialog.FileName;
                try
                {
                    string[][] parsedData = this.parseTimeSeries(openFileName);
                    this.fillDataTable(parsedData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewTimeSeries.ClearSelection();
        }

        private void buttonPlotGraph_Click(object sender, EventArgs e)
        {
            chartTimeSeries.Series[0].Points.Clear();

            for (int i = 0; i < dataGridViewTimeSeries.Rows.Count - 1; i++)
            {
                chartTimeSeries.Series[0].Points.AddXY(processValueForChart(dataGridViewTimeSeries[0, i].Value), processValueForChart(dataGridViewTimeSeries[1, i].Value));
            }
        }

        private void chartTypeChanged(int tag)
        {
            switch (tag)
            {
                case 0:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Spline;
                    break;
                case 1:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Line;
                    break;
                case 2:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Bar;
                    break;
                case 3:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Column;
                    break;
                case 4:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Radar;
                    break;
            }
        }

        private double processValueForChart(object value)
        {
            return double.Parse(value.ToString());
        }

        private string[][] parseTimeSeries(string path)
        {
            string[] lines = File.ReadAllLines(path);

            if (lines.Length <= 0)
            {
                throw new Exception("Пустой файл");
            }

            int lineLength = lines[0].Split(separator).Length;

            if (lines[0][lines[0].Length - 1] == separator)
            {
                lineLength--;
            }

            List<string[]> linesList = new List<string[]>();

            foreach (string line in lines)
            {
                List<string> lineList = new List<string>();

                bool isValid = true;

                string[] words = line.Split(separator);

                for (int j = 0; j < lineLength; j++)
                {
                    string processedWord = processWord(words[j]);
                    isValid = double.TryParse(processedWord, out double parsedWord);

                    if (!isValid)
                    {
                        break;
                    }

                    lineList.Add(processedWord);
                }

                if (isValid)
                {
                    linesList.Add(lineList.ToArray());
                }
            }

            return linesList.ToArray();
        }
        private void fillDataTable(string[][] table)
        {
            DataTable dt = new DataTable();
            
            for (int i = 0; i < table[0].Length; i++)
            {
                dt.Columns.Add(new DataColumn(""));
            }

            foreach (string[] line in table)
            {
                DataRow dr = dt.NewRow();

                for (int i = 0; i < line.Length; i++)
                {
                    dr[i] = line[i];
                }

                dt.Rows.Add(dr);
            }

            if (dt.Rows.Count > 0)
            {
                dataGridViewTimeSeries.DataSource = dt;
            }
            else
            {
                throw new Exception("Ошибка чтения файла");
            }
        }

        private string processWord(string word)
        {
            return word.Trim();
        }

        private void separatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sep = Interaction.InputBox("Введите разделитель:", "Разделитель", separator.ToString());
            if (sep == "")
            {
                return;
            }
            if (sep.Length > 1)
            {
                DialogResult dr = MessageBox.Show($"Разделитель указан неверно!\nВозвращено значение: \"{separator}\". \nИзменить?", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr == DialogResult.Yes)
                {
                    separatorToolStripMenuItem.PerformClick();
                }
            }
            else
            {
                separator = char.Parse(sep);
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = chartTimeSeries.Series[0].Color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                chartTimeSeries.Series[0].Color = colorDialog.Color;
            }
        }

        private void graphTypeChanges(object sender, EventArgs e)
        {
            foreach(ToolStripMenuItem item in graphTypeToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            ((ToolStripMenuItem)sender).Checked = true;
            chartTypeChanged(Convert.ToInt32(((ToolStripMenuItem)sender).Tag));
        }

        private void forecastingChanges(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in forecastingToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            ((ToolStripMenuItem)sender).Checked = true;
        }

        private string forecastingCheck()
        {
            string itemText = string.Empty;
            foreach (ToolStripMenuItem item in forecastingToolStripMenuItem.DropDownItems)
            {
                if (item.Checked)
                {
                    itemText = item.Text;
                    break;
                }
            }
            return itemText;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewTimeSeries.Rows.Count < 1 || openFileName == string.Empty)
            {
                MessageBox.Show($"Временной ряд ещё не спрогнозирован!\nОткройте файл и повторите попытку!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Создание pdf таблицы
                    PdfPTable table = new PdfPTable(dataGridViewTimeSeries.Columns.Count);
                    string fontLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                    BaseFont baseFont = BaseFont.CreateFont(fontLocation, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    Font fontParagraph = new Font(baseFont, 14, iTextSharp.text.Font.NORMAL);
                    for (int i = 0; i < dataGridViewTimeSeries.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewTimeSeries.Columns.Count; j++)
                        {
                            table.AddCell(new Phrase(dataGridViewTimeSeries.Rows[i].Cells[j].Value.ToString(), fontParagraph));
                        }
                    }

                    // Создание случайного имени для картинки из chart
                    string filenameString = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 5);
                    string[] incorrectSymb = { "=", "+", "/" };
                    for (int i = 0; i < incorrectSymb.Length; i++)
                    {
                        filenameString = filenameString.Replace(incorrectSymb[i], "");
                    }

                    // Сохранение картинки из chart
                    chartTimeSeries.SaveImage($"{filenameString}.png", System.Drawing.Imaging.ImageFormat.Png);

                    // Создание pdf картинки
                    System.Drawing.Image chartImage = System.Drawing.Image.FromFile($"{filenameString}.png");
                    Image pdfImage = Image.GetInstance(chartImage, System.Drawing.Imaging.ImageFormat.Png);
                    pdfImage.Alignment = Element.ALIGN_CENTER;

                    // Создание параграфов
                    Paragraph openCsvFile = new Paragraph($"Файл: {openFileName.Split('\\')[openFileName.Split('\\').Length - 1]}", fontParagraph);
                    Paragraph dateTime = new Paragraph($"{DateTime.Now}", fontParagraph);
                    dateTime.Alignment = Element.ALIGN_RIGHT;
                    Paragraph forecasting = new Paragraph($"Прогнозирование: {forecastingCheck()}", fontParagraph);
                    Paragraph analysis = new Paragraph($"Анализ: ", fontParagraph);

                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(dateTime);
                        pdfDoc.Add(openCsvFile);
                        pdfDoc.Add(forecasting);
                        pdfDoc.Add(analysis);
                        pdfDoc.Add(pdfImage);
                        pdfDoc.Add(table);
                        pdfDoc.Close();
                        stream.Close();
                    }

                    //Удаление картинки
                    chartImage.Dispose();
                    File.Delete($"{filenameString}.png");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Текст ошибки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
