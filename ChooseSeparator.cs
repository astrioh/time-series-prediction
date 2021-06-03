using System;
using System.Windows.Forms;

namespace vremRyad
{
    public partial class ChooseSeparator : Form
    {
        public ChooseSeparator()
        {
            InitializeComponent();
        }

        public char Separator { get; set; }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxSeparator.Text == "")
            {
                MessageBox.Show("Заполните поле разделителя!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxSeparator.Text.Length > 1)
            {
                MessageBox.Show("Длина разделителя не может\nбыть больше единицы!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Separator = char.Parse(textBoxSeparator.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ChooseSeparator_Load(object sender, EventArgs e)
        {
            textBoxSeparator.Text = Separator.ToString();
            textBoxSeparator.Select();
            textBoxSeparator.SelectionStart = textBoxSeparator.Text.Length;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
