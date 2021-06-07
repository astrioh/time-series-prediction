using System;
using System.Windows.Forms;

namespace vremRyad
{
    public partial class NumberOfPredictedValues : Form
    {
        public NumberOfPredictedValues()
        {
            InitializeComponent();
        }

        public int number { get; set; }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NumberOfPredictedValues_Load(object sender, EventArgs e)
        {
            textBoxNumber.Text = number.ToString();
            textBoxNumber.Select();
            textBoxNumber.SelectionStart = textBoxNumber.Text.Length;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNumber.Text))
            {
                MessageBox.Show("Заполните поле количества!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(textBoxNumber.Text, out int num))
            {
                MessageBox.Show("Введённое значение не является числом!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.number = int.Parse(textBoxNumber.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
