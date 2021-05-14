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
        public Form1()
        {
            InitializeComponent();
            comboBoxChartType.SelectedIndex = 0;
            comboBoxPredictionMethod.SelectedIndex = 0;
            dataGridViewTimeSeries.
            this.timeSeries = new TimeSeries();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                dataGridViewTimeSeries.Columns.Clear();

                string path = openFileDialog1.FileName;
                try
                {
                    string[][] parsedData = this.parseTimeSeries(path);
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

        private void comboBoxChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxChartType.SelectedIndex)
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

        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

            int lineLength = lines[0].Split(';').Length;

            if (lines[0][lines[0].Length - 1] == ';')
            {
                lineLength--;
            }

            List<string[]> linesList = new List<string[]>();

            foreach (string line in lines)
            {
                List<string> lineList = new List<string>();

                bool isValid = true;

                string[] words = line.Split(';');

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
    }
}
