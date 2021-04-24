using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace vremRyad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxChartType.SelectedIndex = 0;
            comboBoxPredictionMethod.SelectedIndex = 0;
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
                string[] lines = File.ReadAllLines(path);
                try
                {
                    dataGridViewTimeSeries.DataSource = this.parseTimeSeries(lines);
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

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewTimeSeries.Rows.Count - 1; i++)
            {
                chartTimeSeries.Series[0].Points.AddXY(dataGridViewTimeSeries[0, i].Value.ToString(), dataGridViewTimeSeries[1, i].Value.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private DataTable parseTimeSeries(string[] lines)
        {
            if (lines.Length <= 0)
            {
                throw new Exception("Пустой файл");
            }

            DataTable dt = new DataTable();
            for (int i = 0; i < lines[0].Split(';').Length; i++)
            {
                dt.Columns.Add(new DataColumn(""));
            }

            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                DataRow dr = dt.NewRow();
                bool check = true;
                for (int j = 0; j < words.Length; j++)
                {
                    dr[j] = words[j];
                    try
                    {
                        double.Parse(words[j]);
                    }
                    catch
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    dt.Rows.Add(dr);
                }
            }

            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                throw new Exception("Ошибка чтения файла");
            }
        }
    }
}
