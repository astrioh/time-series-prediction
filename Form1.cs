using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace vremRyad
{
    public partial class Form1 : Form
    {
        TimeSeries timeSeries;
        enum TableHeadersAnalyze {
            ChainedAbsoluteIncrease, 
            BasisAbsoluteIncrease
        };
        private char separator = ';';

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
            DialogResult res = openFileDialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                dataGridViewTimeSeries.Columns.Clear();

                string path = openFileDialog.FileName;
                try
                {
                    double[][] parsedData = this.parseTimeSeries(path);

                    double[] timeSeriesData = new double[parsedData.Length];
                    for (int i = 0; i < parsedData.Length; i++)
                    {
                        timeSeriesData[i] = parsedData[i][1];
                    }
                    this.timeSeries.Data = timeSeriesData;

                    this.fillDataTable(parsedData);
                    buttonAnalyze.Enabled = true;
                    buttonForecast.Enabled = true;
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
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Pie;
                    break;
                case 5:
                    chartTimeSeries.Series[0].ChartType = SeriesChartType.Radar;
                    break;
            }
        }

        private double processValueForChart(object value)
        {
            return double.Parse(value.ToString());
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
            
            for (int i = 0; i < values[0].Length; i++)
            {
                dt.Columns.Add(new DataColumn(""));
            }

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

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            double[][] absoluteIncreaseData = this.timeSeries.absoluteIncrease();
            analyzeTimeSeries();
        }

        private void analyzeTimeSeries()
        {
            DataTable dataTable = (DataTable) dataGridViewTimeSeries.DataSource;

            foreach (TableHeadersAnalyze tableHeader in Enum.GetValues(typeof(TableHeadersAnalyze)))
            {
                dataTable.Columns.Add(new DataColumn(tableHeader.ToString()));
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i][TableHeadersAnalyze.ChainedAbsoluteIncrease.ToString()] = 0; // TODO: сделать метод, возвращающий словарь, ключ - название параметра, значение - массив чисел
            }
        }
    }
}
