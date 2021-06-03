using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Threading;
//using LiveCharts;
//using LiveCharts.WinForms;


namespace vremRyad
{
    public partial class Form1 : Form
    {
        TimeSeries timeSeries;
        Dictionary<string, string> tableHeadersAnalyze = new Dictionary<string, string>
        {
            { "AbsoluteIncrease", "Абсолютный прирост:\nцепной,\nбазисный\n"},
            { "ChainGrowthRate", "Цепной темп роста:\nкоэффициент,\nпроцент"},
            { "BaseGrowthRate", "Базисный темп роста:\nкоэффициент,\nпроцент"},
            { "Null", "Нету"},
            { "AbsoluteIncreaseValueOnePercent", "Абсолютное значение 1% прироста"},
            { "RelativeAcceleration", "Относительное ускорение, %"},
            { "LeadRatio", "Коэффициент опережения"}
        };

        private char separator = ';';
        private string openFileName = string.Empty;
        private string form1Name = "Временные ряды";
        private string pdfFileName = string.Empty;
        private DataTable dt;

        public char Separator { get => separator; set => separator = value; }

        public Form1()
        {
            InitializeComponent();
            this.timeSeries = new TimeSeries();
            timeSeries.SelectedMethod = TimeSeries.Methods.AverageGrowthRate;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                clearChartAndTable();
                dataGridViewTimeSeries.Columns.Clear();
                openFileName = openFileDialog.FileName;
                try
                {
                    double[][] parsedData = this.parseTimeSeries(openFileName);

                    double[] timeSeriesData = new double[parsedData.Length];
                    for (int i = 0; i < parsedData.Length; i++)
                    {
                        timeSeriesData[i] = parsedData[i][1];
                    }
                    this.timeSeries.Data = timeSeriesData;

                    this.fillDataTable(parsedData);
                    this.plotGraph();
                    buttonAnalyzeAndForecast.Enabled = true;
                    this.Text = form1Name + " (" + openFileName.Split('\\')[openFileName.Split('\\').Length - 1] + ")";
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
        private double processValueForChart(object value)
        {
            return double.Parse(value.ToString());
        }
        private void plotGraph()
        {
            chartTimeSeries.Series[0].Points.Clear();

            for (int i = 0; i < dataGridViewTimeSeries.Rows.Count - 1; i++)
            {
                chartTimeSeries.Series[0].Points.AddXY(processValueForChart(dataGridViewTimeSeries[0, i].Value), processValueForChart(dataGridViewTimeSeries[1, i].Value));
                //chartTimeSeries1.Series[0].Values.Add(100, 100);
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
        private double[][] parseTimeSeries(string path)
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

            List<double[]> linesList = new List<double[]>();

            foreach (string line in lines)
            {
                List<double> lineList = new List<double>();

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

                    lineList.Add(parsedWord);
                }

                if (isValid)
                {
                    linesList.Add(lineList.ToArray());
                }
            }

            return linesList.ToArray();
        }
        private void fillDataTable(double[][] values)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Время"));
            dt.Columns.Add(new DataColumn("Данные"));

            foreach (double[] line in values)
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
            ChooseSeparator chooseSeparator = new ChooseSeparator();
            chooseSeparator.Separator = this.separator;

            DialogResult result = chooseSeparator.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Separator = chooseSeparator.Separator;
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
            foreach (ToolStripMenuItem item in graphTypeToolStripMenuItem.DropDownItems)
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

        private void analyzeTimeSeries()
        {
            DataTable dataTable = (DataTable)dataGridViewTimeSeries.DataSource;

            foreach (string headerName in tableHeadersAnalyze.Values)
            {
                dataTable.Columns.Add(new DataColumn(headerName));
            }
            try
            {
                double[][] absoluteIncrease = this.timeSeries.absoluteIncrease();
                double[][] growthRate = this.timeSeries.growthRate();
                
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {

                    dataTable.Rows[i][tableHeadersAnalyze["AbsoluteIncrease"]] = $"{absoluteIncrease[i][0]}\t\n{absoluteIncrease[i][1]}";
                }
            }
            catch
            {
                throw new Exception("Ошибка анализа");
            }


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

        private void saveAsPdf(string pdfPath)
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

            // Создание документа
            Document pdfDoc;

            using (FileStream stream = new FileStream(pdfPath, FileMode.Create))
            {
                pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
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

            pdfFileName = pdfPath;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewTimeSeries.Rows.Count < 1 || openFileName == string.Empty)
            {
                MessageBox.Show($"Файл не открыт!\nОткройте файл и повторите попытку!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    saveAsPdf(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Текст ошибки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pdfFileName))
            {
                string Filepath = pdfFileName;
                using (PrintDialog Dialog = new PrintDialog())
                {
                    Dialog.ShowDialog();
                    ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                    {
                        Verb = "print",
                        CreateNoWindow = true,
                        FileName = Filepath,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                    Process printProcess = new Process();
                    printProcess.StartInfo = printProcessInfo;
                    printProcess.Start();
                    printProcess.WaitForInputIdle();
                    Thread.Sleep(3000);
                    if (false == printProcess.CloseMainWindow())
                    {
                        printProcess.Kill();
                    }
                }
            }
            else
            {
                saveToolStripMenuItem_Click(null, null);
            }





            /*if (!string.IsNullOrWhiteSpace(pdfFileName))
            {
                Process process = new Process();
                process.StartInfo.FileName = "";
                process.StartInfo.Verb = "printto";

                process.Start();

                process.WaitForInputIdle();
                process.Kill();
            }
            else
            {
                saveToolStripMenuItem_Click(null, null);
            }*/
        }

        private void sendToMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewTimeSeries.Rows.Count < 1 || openFileName == string.Empty)
            {
                MessageBox.Show($"Файл не открыт!\nОткройте файл и повторите попытку!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SendEmail sendEmail = new SendEmail();

            string pathPDFFile = System.Reflection.Assembly.GetExecutingAssembly().Location.
                Substring(0, System.Reflection.Assembly.GetExecutingAssembly().Location.LastIndexOf('\\')) +
                $@"\pdfFiles\Отчёт по файлу ({openFileName.Split('\\')[openFileName.Split('\\').Length - 1]} "+
                $@"{DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss")}).pdf";

            saveAsPdf(pathPDFFile);

            sendEmail.pathPDF = pathPDFFile;
            sendEmail.ShowDialog();

            File.Delete(pathPDFFile);
        }

        private void clearChartAndTable()
        {
            chartTimeSeries.Series[0].Points.Clear();
            dt = new DataTable();
            dataGridViewTimeSeries.DataSource = dt;
        }


        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearChartAndTable();
        }

        private void buttonAnalyzeAndForecast_Click(object sender, EventArgs e)
        {
            analyzeTimeSeries();
        }
    }
}
