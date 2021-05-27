using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                return;
            }

            this.Separator = Char.Parse(textBoxSeparator.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ChooseSeparator_Load(object sender, EventArgs e)
        {
            textBoxSeparator.Text = Separator.ToString();
        }
    }
}
