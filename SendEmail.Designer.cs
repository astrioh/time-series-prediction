
namespace vremRyad
{
    partial class SendEmail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendEmail));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mailBt = new System.Windows.Forms.Button();
            this.textLetterBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.themeBox = new System.Windows.Forms.TextBox();
            this.mailToBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.senderNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(20, 394);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 22);
            this.label6.TabIndex = 58;
            this.label6.Text = "Файл:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(129, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 57;
            // 
            // mailBt
            // 
            this.mailBt.BackColor = System.Drawing.Color.White;
            this.mailBt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mailBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mailBt.Location = new System.Drawing.Point(447, 477);
            this.mailBt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mailBt.Name = "mailBt";
            this.mailBt.Size = new System.Drawing.Size(104, 32);
            this.mailBt.TabIndex = 56;
            this.mailBt.Text = "Отправить";
            this.mailBt.UseVisualStyleBackColor = false;
            this.mailBt.Click += new System.EventHandler(this.mailBt_Click);
            // 
            // textLetterBox
            // 
            this.textLetterBox.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLetterBox.ForeColor = System.Drawing.Color.Gray;
            this.textLetterBox.Location = new System.Drawing.Point(24, 196);
            this.textLetterBox.Multiline = true;
            this.textLetterBox.Name = "textLetterBox";
            this.textLetterBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLetterBox.Size = new System.Drawing.Size(527, 176);
            this.textLetterBox.TabIndex = 55;
            this.textLetterBox.Text = " содержание письма ";
            this.textLetterBox.Enter += new System.EventHandler(this.textLetterBox_Enter);
            this.textLetterBox.Leave += new System.EventHandler(this.textLetterBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(20, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 22);
            this.label4.TabIndex = 54;
            this.label4.Text = "Сообщение:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(20, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 22);
            this.label3.TabIndex = 53;
            this.label3.Text = "Тема:";
            // 
            // themeBox
            // 
            this.themeBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.themeBox.ForeColor = System.Drawing.Color.Gray;
            this.themeBox.Location = new System.Drawing.Point(84, 114);
            this.themeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.themeBox.Name = "themeBox";
            this.themeBox.Size = new System.Drawing.Size(467, 30);
            this.themeBox.TabIndex = 52;
            this.themeBox.Text = " тема письма ";
            this.themeBox.Enter += new System.EventHandler(this.themeBox_Enter);
            this.themeBox.Leave += new System.EventHandler(this.themeBox_Leave);
            // 
            // mailToBox
            // 
            this.mailToBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mailToBox.ForeColor = System.Drawing.Color.Gray;
            this.mailToBox.Location = new System.Drawing.Point(84, 69);
            this.mailToBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mailToBox.Name = "mailToBox";
            this.mailToBox.Size = new System.Drawing.Size(467, 30);
            this.mailToBox.TabIndex = 51;
            this.mailToBox.Text = " e-mail получателя ";
            this.mailToBox.Enter += new System.EventHandler(this.mailToBox_Enter);
            this.mailToBox.Leave += new System.EventHandler(this.mailToBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 50;
            this.label2.Text = "Кому:";
            // 
            // senderNameBox
            // 
            this.senderNameBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.senderNameBox.ForeColor = System.Drawing.Color.Gray;
            this.senderNameBox.Location = new System.Drawing.Point(84, 24);
            this.senderNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.senderNameBox.Name = "senderNameBox";
            this.senderNameBox.Size = new System.Drawing.Size(467, 30);
            this.senderNameBox.TabIndex = 49;
            this.senderNameBox.Text = " ФИО отправителя ";
            this.senderNameBox.Enter += new System.EventHandler(this.senderNameBox_Enter);
            this.senderNameBox.Leave += new System.EventHandler(this.senderNameBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(39, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 22);
            this.label1.TabIndex = 48;
            this.label1.Text = "От:";
            // 
            // fileLabel
            // 
            this.fileLabel.BackColor = System.Drawing.Color.Transparent;
            this.fileLabel.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileLabel.Location = new System.Drawing.Point(21, 425);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(530, 40);
            this.fileLabel.TabIndex = 59;
            // 
            // SendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(572, 520);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mailBt);
            this.Controls.Add(this.textLetterBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.themeBox);
            this.Controls.Add(this.mailToBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.senderNameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отправить на почту";
            this.Load += new System.EventHandler(this.SendEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button mailBt;
        private System.Windows.Forms.TextBox textLetterBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox themeBox;
        private System.Windows.Forms.TextBox mailToBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox senderNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fileLabel;
    }
}