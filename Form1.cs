using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                string[] lines = File.ReadAllLines(path);
                DataTable dt = new DataTable();
                dataGridView1.Columns.Clear();
                if (lines.Length > 0)
                {
                    for (int i = 0; i < lines[0].Split(';').Length; i++)
                    {
                        dt.Columns.Add(new DataColumn(""));
                    }
                    foreach(string line in lines)
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
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                chart1.Series[0].Points.AddXY(dataGridView1[0, i].Value.ToString(), dataGridView1[1, i].Value.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    chart1.Series[0].ChartType = SeriesChartType.Spline;
                    break;
                case 1:
                    chart1.Series[0].ChartType = SeriesChartType.Line;
                    break;
                case 2:
                    chart1.Series[0].ChartType = SeriesChartType.Bar;
                    break;
                case 3:
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                    break;
                case 4:
                    chart1.Series[0].ChartType = SeriesChartType.Pie;
                    break;
                case 5:
                    chart1.Series[0].ChartType = SeriesChartType.Radar;
                    break;
            }
        }

        private void графикToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
