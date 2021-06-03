using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace vremRyad
{
    public partial class SendEmail : Form
    {
        public SendEmail()
        {
            InitializeComponent();
        }
        public string pathPDF { get; set; }

        private void SendEmail_Load(object sender, EventArgs e)
        {
            fileLabel.Text = $"{pathPDF.Split('\\')[pathPDF.Split('\\').Length - 1]}";
            label1.Select();
        }

        private void senderNameBox_Enter(object sender, EventArgs e)
        {
            if (senderNameBox.Text == " ФИО отправителя ")
            {
                senderNameBox.Clear();
                senderNameBox.ForeColor = Color.Black;
            }
        }

        private void senderNameBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(senderNameBox.Text))
            {
                senderNameBox.Text = " ФИО отправителя ";
                senderNameBox.ForeColor = Color.Gray;
            }
        }

        private void mailToBox_Enter(object sender, EventArgs e)
        {
            if (mailToBox.Text == " e-mail получателя ")
            {
                mailToBox.Clear();
                mailToBox.ForeColor = Color.Black;
            }
        }

        private void mailToBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mailToBox.Text))
            {
                mailToBox.Text = " e-mail получателя ";
                mailToBox.ForeColor = Color.Gray;
            }
        }

        private void themeBox_Enter(object sender, EventArgs e)
        {
            if (themeBox.Text == " тема письма ")
            {
                themeBox.Clear();
                themeBox.ForeColor = Color.Black;
            }
        }

        private void themeBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(themeBox.Text))
            {
                themeBox.Text = " тема письма ";
                themeBox.ForeColor = Color.Gray;
            }
        }

        private void textLetterBox_Enter(object sender, EventArgs e)
        {
            if (textLetterBox.Text == " содержание письма ")
            {
                textLetterBox.Clear();
                textLetterBox.ForeColor = Color.Black;
            }
        }

        private void textLetterBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textLetterBox.Text))
            {
                textLetterBox.Text = " содержание письма ";
                textLetterBox.ForeColor = Color.Gray;
            }
        }

        private void mailBt_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            label1.Select();
            if (mailToBox.Text == " e-mail получателя " || mailToBox.Text == "")
            {
                MessageBox.Show("Ошибка: поле e-mail получателя\nне заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                MailAddress from = new MailAddress("time.series.mail@yandex.ru", senderNameBox.Text == " ФИО отправителя " ? "" : senderNameBox.Text);

                MailAddress to = new MailAddress(mailToBox.Text);

                MailMessage message = new MailMessage(from, to);

                message.Subject = (themeBox.Text == " тема письма " ? "" : themeBox.Text);
                message.Body = (textLetterBox.Text == " содержание письма " ? "" : textLetterBox.Text);
                message.Attachments.Add(new Attachment(pathPDF));

                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587); //25, 587, 2525, 465
                smtp.Credentials = new NetworkCredential("time.series.mail@yandex.ru", "qnisqcdahygbqlpb");//timeSeries2021

                smtp.EnableSsl = true;

                smtp.Send(message);

                message.Dispose();
                
                MessageBox.Show("Письмо отправлено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                StreamWriter sw = new StreamWriter(@"C:\Users\babee\OneDrive\Desktop\Test.txt");
                sw.WriteLine(ex.Message);
                sw.Close();
            }
            this.Cursor = Cursors.Default;
        }
    }
}
