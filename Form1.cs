using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;

namespace vremRyad
{
    public partial class Form1 : Form
    {
        TimeSeries timeSeries;
        private char separator = ';';

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

                string path = openFileDialog.FileName;
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
    }
}
