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
            { "IncreaseRate", "Темпы прироста, %:\nежегодные,\nк."},
            { "AbsoluteIncreaseValueOnePercent", "Абсолютное значение 1% прироста"},
            { "RelativeAcceleration", "Относительное ускорение, %"},
            { "LeadRatio", "Коэффициент опережения"}
        };

        private char separator = ';';
        private string openFileName = string.Empty;
        private string form1Name = "Временные ряды";
        private string pdfFileName = string.Empty;
        private DataTable dt;
        private double[][] parsedData;

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
                    this.parsedData = this.parseTimeSeries(openFileName);

                    double[] timeSeriesData = new double[parsedData.Length];
                    for (int i = 0; i < parsedData.Length; i++)
                    {
                        timeSeriesData[i] = parsedData[i][1];
                    }
                    this.timeSeries.TimeSeriesSet = timeSeriesData;
                    this.timeSeries.ForecastName = Convert.ToInt32(parsedData[parsedData.Length - 1][0]);

                    this.fillDataTable(parsedData);
                    this.plotGraph();

                    buttonAnalyzeAndForecast.Enabled = true;

                    this.Text = form1Name + " (" + openFileName.Split('\\')[openFileName.Split('\\').Length - 1] + ")";

                    foreach (DataGridViewColumn column in dataGridViewTimeSeries.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    buttonAnalyzeAndForecast.Enabled = true;
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

        private void initialColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = chartTimeSeries.Series[0].Color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                chartTimeSeries.Series[0].Color = colorDialog.Color;
            }
        }

        private void forecastColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = chartTimeSeries.Series[1].Color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                chartTimeSeries.Series[1].Color = colorDialog.Color;
            }
        }

        private void chartTypeChanged(int tag)
        {
            switch (tag)
            {
                case 0:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Spline;
                    chartTimeSeries.Series[1].ChartType = SeriesChartType.Spline;
                    break;
                case 1:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Line;
                    chartTimeSeries.Series[1].ChartType = SeriesChartType.Line;
                    break;
                case 2:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Bar;
                    chartTimeSeries.Series[1].ChartType = SeriesChartType.Bar;
                    break;
                case 3:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Column;
                    chartTimeSeries.Series[1].ChartType = SeriesChartType.Column;
                    break;
                case 4:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Radar;
                    chartTimeSeries.Series[1].ChartType = SeriesChartType.Radar;
                    break;
            }
        }

        private void graphTypeChanges(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in graphTypeToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            ((ToolStripMenuItem)sender).Checked = true;
            this.chartTypeChanged(Convert.ToInt32(((ToolStripMenuItem)sender).Tag));
        }

        private void forecastMethodChanged(int tag)
        {
            switch (tag)
            {
                case 0:
                    this.timeSeries.SelectedMethod = TimeSeries.Methods.AverageGrowthRate;
                    break;
                case 1:
                    this.timeSeries.SelectedMethod = TimeSeries.Methods.MovingAverage;
                    break;
                case 2:
                    this.timeSeries.SelectedMethod = TimeSeries.Methods.AveragePerformanceIndicators;
                    break;
            }
        }

        private void forecastingChanges(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in forecastingMethodsToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            ((ToolStripMenuItem)sender).Checked = true;
            this.forecastMethodChanged(Convert.ToInt32(((ToolStripMenuItem)sender).Tag));
        }

        private string forecastingCheck()
        {
            string itemText = string.Empty;
            foreach (ToolStripMenuItem item in forecastingMethodsToolStripMenuItem.DropDownItems)
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
            Font fontParagraphBlack = new Font(baseFont, 14, iTextSharp.text.Font.NORMAL);
            Font fontParagraphBlue = new Font(baseFont, 14, iTextSharp.text.Font.NORMAL);
            fontParagraphBlue.SetColor(0, 0, 255);
            for (int i = 0; i < dataGridViewTimeSeries.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dataGridViewTimeSeries.Columns[i].HeaderCell.Value.ToString(), fontParagraphBlack));
            }
            for (int i = 0; i < dataGridViewTimeSeries.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewTimeSeries.Columns.Count; j++)
                {
                    bool isForecastCell = dataGridViewTimeSeries.Rows[i].Cells[j].Style.ForeColor == System.Drawing.Color.Blue ||
                        dataGridViewTimeSeries.Rows[i].DefaultCellStyle.ForeColor == System.Drawing.Color.Blue;
                    table.AddCell(new Phrase(dataGridViewTimeSeries.Rows[i].Cells[j].Value.ToString(), isForecastCell ? fontParagraphBlue : fontParagraphBlack));

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
            Paragraph openCsvFile = new Paragraph($"Файл: {openFileName.Split('\\')[openFileName.Split('\\').Length - 1]}", fontParagraphBlack);
            Paragraph dateTime = new Paragraph($"{DateTime.Now}", fontParagraphBlack);
            dateTime.Alignment = Element.ALIGN_RIGHT;
            Paragraph forecasting = new Paragraph($"Прогнозирование: {forecastingCheck()}", fontParagraphBlack);


            //AverageRowLevelLabel
            Paragraph AvRowLevLabInf = new Paragraph(AverageRowLevelLabel.Text, fontParagraphBlack);
            //AverageAbsoluteIncreaseLabel
            Paragraph AvAbIncLabInf = new Paragraph(AverageAbsoluteIncreaseLabel.Text, fontParagraphBlack);
            //AverageChainGrowthRatePercent
            Paragraph AvChGrRaPerLabInf = new Paragraph(AverageChainGrowthRatePercent.Text, fontParagraphBlack);

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
                pdfDoc.Add(AvRowLevLabInf);
                pdfDoc.Add(AvAbIncLabInf);
                pdfDoc.Add(AvChGrRaPerLabInf);
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
            saveFileDialog.FileName = String.Empty;
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
                $@"\pdfFiles\Отчёт по файлу ({openFileName.Split('\\')[openFileName.Split('\\').Length - 1]} " +
                $@"{DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss")}).pdf";

            saveAsPdf(pathPDFFile);

            sendEmail.pathPDF = pathPDFFile;
            sendEmail.ShowDialog();

            File.Delete(pathPDFFile);
        }

        private void clearChartAndTable()
        {
            chartTimeSeries.Series[0].Points.Clear();
            chartTimeSeries.Series[1].Points.Clear();
            dt = new DataTable();
            dataGridViewTimeSeries.DataSource = dt;
            AverageRowLevelLabel.Text = string.Empty;
            AverageAbsoluteIncreaseLabel.Text = string.Empty;
            AverageChainGrowthRatePercent.Text = string.Empty;
        }


        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearChartAndTable();
        }

        private void fillAnalysisResults()
        {
            DataTable dataTable = (DataTable)dataGridViewTimeSeries.DataSource;

            foreach (string headerName in tableHeadersAnalyze.Values)
            {
                if (!dataTable.Columns.Contains(headerName))
                {
                    dataTable.Columns.Add(new DataColumn(headerName));
                }
            }

            for (int i = 0; i < this.timeSeries.TimeSeriesSet.Length - 1; i++)
            {
                dataTable.Rows[i + 1][tableHeadersAnalyze["AbsoluteIncrease"]] = $"{this.timeSeries.AbsoluteIncrease[i][0]}\t  {this.timeSeries.AbsoluteIncrease[i][1]}";
                dataTable.Rows[i + 1][tableHeadersAnalyze["ChainGrowthRate"]] = $"{this.timeSeries.ChainGrowthRate[i][0]}\t  {this.timeSeries.ChainGrowthRate[i][1]}";
                dataTable.Rows[i + 1][tableHeadersAnalyze["BaseGrowthRate"]] = $"{this.timeSeries.BaseGrowthRate[i][0]}\t  {this.timeSeries.BaseGrowthRate[i][1]}";
                dataTable.Rows[i + 1][tableHeadersAnalyze["IncreaseRate"]] = $"{this.timeSeries.IncreaseRate[i][0]}\t  {this.timeSeries.IncreaseRate[i][1]}";
                dataTable.Rows[i + 1][tableHeadersAnalyze["AbsoluteIncreaseValueOnePercent"]] = this.timeSeries.AbsoluteIncreaseValueOnePercent[i];

                if (i < this.timeSeries.TimeSeriesSet.Length - 2)
                {
                    dataTable.Rows[i + 2][tableHeadersAnalyze["RelativeAcceleration"]] = this.timeSeries.RelativeAcceleration[i];
                    dataTable.Rows[i + 2][tableHeadersAnalyze["LeadRatio"]] = this.timeSeries.LeadRatio[i];
                }
            }

            AverageRowLevelLabel.Text = "Средний уровень ряда: " + Math.Round(this.timeSeries.AverageRowLevel, 2);
            AverageAbsoluteIncreaseLabel.Text = "Средний абсолютный прирост: " + Math.Round(this.timeSeries.AverageAbsoluteIncrease, 2);
            AverageChainGrowthRatePercent.Text = "Средний темп роста, %: " + Math.Round(this.timeSeries.AverageChainGrowthRatePercent, 2);
        }

        private void clearForecastResults()
        {
            DataTable dataTable = (DataTable)dataGridViewTimeSeries.DataSource;

            if (dataGridViewTimeSeries.Columns.Contains("Скользящая средняя из 3-х уровней"))
            {
                dataTable.Columns.Remove("Скользящая средняя из 3-х уровней");
            }

            if (dataTable.Rows.Count > this.timeSeries.TimeSeriesSet.Length)
            {
                for (int i = this.timeSeries.TimeSeriesSet.Length; i < dataTable.Rows.Count; i++)
                {
                    this.fillDataTable(this.parsedData);
                }
            }
        }

        private void fillForecastResultsIntoTable()
        {
            DataTable dataTable = (DataTable)dataGridViewTimeSeries.DataSource;

            if (this.timeSeries.SelectedMethod == TimeSeries.Methods.MovingAverage)
            {
                dataTable.Columns.Add(new DataColumn("Скользящая средняя из 3-х уровней"));

                for (int i = 1; i < this.timeSeries.TimeSeriesSet.Length - 1; i++)
                {
                    dataTable.Rows[i]["Скользящая средняя из 3-х уровней"] = Math.Round(this.timeSeries.ForecastValues[i][1], 2);
                    dataGridViewTimeSeries.Rows[i].Cells[dataTable.Columns.IndexOf("Скользящая средняя из 3-х уровней")].Style.ForeColor = System.Drawing.Color.Blue;
                }
            }
            else
            {
                foreach (double[] forecastPair in this.timeSeries.ForecastValues)
                {
                    DataRow forecastRow = dataTable.NewRow();
                    forecastRow[0] = forecastPair[0];
                    forecastRow[1] = Math.Round(forecastPair[1], 2);

                    dataTable.Rows.Add(forecastRow);
                }

                for (int i = this.timeSeries.TimeSeriesSet.Length; i < dataGridViewTimeSeries.Rows.Count; i++)
                {
                    dataGridViewTimeSeries.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                }
            }
        }

        private void plotForecastChart()
        {
            bool isMovingAverage = this.timeSeries.SelectedMethod == TimeSeries.Methods.MovingAverage;
            chartTimeSeries.Series[1].Points.Clear();

            if (!isMovingAverage)
            {
                chartTimeSeries.Series[1].Points.AddXY(
                    processValueForChart(dataGridViewTimeSeries[0, this.timeSeries.TimeSeriesSet.Length - 1].Value), 
                    processValueForChart(dataGridViewTimeSeries[1, this.timeSeries.TimeSeriesSet.Length - 1].Value)
                );
            }

            int startingIndex = isMovingAverage ? 1 : 0;

            for (int i = startingIndex; i < this.timeSeries.ForecastValues.Length - 1; i++)
            {
                chartTimeSeries.Series[1].Points.AddXY(processValueForChart(this.timeSeries.ForecastValues[i][0]), processValueForChart(this.timeSeries.ForecastValues[i][1]));
            }
        }

        private void buttonAnalyzeAndForecast_Click(object sender, EventArgs e)
        {
            try
            {
                this.clearForecastResults();
                this.timeSeries.analyzeAndForecast();
                this.fillAnalysisResults();
                this.fillForecastResultsIntoTable();
                this.plotForecastChart();
                foreach (DataGridViewColumn column in dataGridViewTimeSeries.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTimeSeries_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds,
                DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            if (e.Value != null)

            {

                e.Graphics.DrawString(e.Value.ToString(),

                    e.CellStyle.Font,

                    new System.Drawing.SolidBrush(e.CellStyle.ForeColor),

                    e.CellBounds.X, e.CellBounds.Y);

            }

            e.Handled = true;
        }

        private void NumberOfPredictedValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberOfPredictedValues numberValues = new NumberOfPredictedValues();
            numberValues.number = this.timeSeries.ForecastCount;

            DialogResult result = numberValues.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.timeSeries.ForecastCount = numberValues.number;
            }
        }
    }
}
