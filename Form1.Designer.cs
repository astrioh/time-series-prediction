namespace vremRyad
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewTimeSeries = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPlotGraph = new System.Windows.Forms.Button();
            this.chartTimeSeries = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curvedLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.straightLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimeSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeSeries)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewTimeSeries);
            this.splitContainer1.Panel1.Controls.Add(this.buttonPlotGraph);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartTimeSeries);
            this.splitContainer1.Size = new System.Drawing.Size(1348, 691);
            this.splitContainer1.SplitterDistance = 532;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridViewTimeSeries
            // 
            this.dataGridViewTimeSeries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTimeSeries.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTimeSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTimeSeries.ColumnHeadersVisible = false;
            this.dataGridViewTimeSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridViewTimeSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTimeSeries.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTimeSeries.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewTimeSeries.MultiSelect = false;
            this.dataGridViewTimeSeries.Name = "dataGridViewTimeSeries";
            this.dataGridViewTimeSeries.ReadOnly = true;
            this.dataGridViewTimeSeries.RowHeadersVisible = false;
            this.dataGridViewTimeSeries.RowHeadersWidth = 51;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTimeSeries.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTimeSeries.RowTemplate.Height = 24;
            this.dataGridViewTimeSeries.Size = new System.Drawing.Size(532, 652);
            this.dataGridViewTimeSeries.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // buttonPlotGraph
            // 
            this.buttonPlotGraph.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPlotGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlotGraph.Location = new System.Drawing.Point(0, 652);
            this.buttonPlotGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPlotGraph.Name = "buttonPlotGraph";
            this.buttonPlotGraph.Size = new System.Drawing.Size(532, 39);
            this.buttonPlotGraph.TabIndex = 1;
            this.buttonPlotGraph.Text = "Построить график";
            this.buttonPlotGraph.UseVisualStyleBackColor = true;
            this.buttonPlotGraph.Click += new System.EventHandler(this.buttonPlotGraph_Click);
            // 
            // chartTimeSeries
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTimeSeries.ChartAreas.Add(chartArea1);
            this.chartTimeSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTimeSeries.Location = new System.Drawing.Point(0, 0);
            this.chartTimeSeries.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartTimeSeries.Name = "chartTimeSeries";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "Series1";
            this.chartTimeSeries.Series.Add(series1);
            this.chartTimeSeries.Size = new System.Drawing.Size(815, 691);
            this.chartTimeSeries.TabIndex = 11;
            this.chartTimeSeries.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.графикToolStripMenuItem,
            this.forecastingToolStripMenuItem,
            this.таблицаToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1348, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openToolStripMenuItem.Text = "&Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(213, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.saveToolStripMenuItem.Text = "&Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.printToolStripMenuItem.Text = "&Печать";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exitToolStripMenuItem.Text = "Вы&ход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.helpToolStripMenuItem.Text = "Спра&вка";
            // 
            // contentToolStripMenuItem
            // 
            this.contentToolStripMenuItem.Name = "contentToolStripMenuItem";
            this.contentToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.contentToolStripMenuItem.Text = "&Содержание";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(193, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.aboutToolStripMenuItem.Text = "&О программе...";
            // 
            // графикToolStripMenuItem
            // 
            this.графикToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.graphTypeToolStripMenuItem});
            this.графикToolStripMenuItem.Name = "графикToolStripMenuItem";
            this.графикToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.графикToolStripMenuItem.Text = "&График";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.colorToolStripMenuItem.Text = "&Цвет";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // graphTypeToolStripMenuItem
            // 
            this.graphTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curvedLineToolStripMenuItem,
            this.straightLineToolStripMenuItem,
            this.barToolStripMenuItem,
            this.columnsToolStripMenuItem,
            this.radarToolStripMenuItem});
            this.graphTypeToolStripMenuItem.Name = "graphTypeToolStripMenuItem";
            this.graphTypeToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.graphTypeToolStripMenuItem.Text = "&Тип";
            // 
            // curvedLineToolStripMenuItem
            // 
            this.curvedLineToolStripMenuItem.Checked = true;
            this.curvedLineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.curvedLineToolStripMenuItem.Name = "curvedLineToolStripMenuItem";
            this.curvedLineToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.curvedLineToolStripMenuItem.Tag = "0";
            this.curvedLineToolStripMenuItem.Text = "Кривая линия";
            this.curvedLineToolStripMenuItem.Click += new System.EventHandler(this.graphTypeChanges);
            // 
            // straightLineToolStripMenuItem
            // 
            this.straightLineToolStripMenuItem.Name = "straightLineToolStripMenuItem";
            this.straightLineToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.straightLineToolStripMenuItem.Tag = "1";
            this.straightLineToolStripMenuItem.Text = "Прямая линия";
            this.straightLineToolStripMenuItem.Click += new System.EventHandler(this.graphTypeChanges);
            // 
            // barToolStripMenuItem
            // 
            this.barToolStripMenuItem.Name = "barToolStripMenuItem";
            this.barToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.barToolStripMenuItem.Tag = "2";
            this.barToolStripMenuItem.Text = "Бар";
            this.barToolStripMenuItem.Click += new System.EventHandler(this.graphTypeChanges);
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.columnsToolStripMenuItem.Tag = "3";
            this.columnsToolStripMenuItem.Text = "Колонны";
            this.columnsToolStripMenuItem.Click += new System.EventHandler(this.graphTypeChanges);
            // 
            // radarToolStripMenuItem
            // 
            this.radarToolStripMenuItem.Name = "radarToolStripMenuItem";
            this.radarToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.radarToolStripMenuItem.Tag = "4";
            this.radarToolStripMenuItem.Text = "Радар";
            this.radarToolStripMenuItem.Click += new System.EventHandler(this.graphTypeChanges);
            // 
            // forecastingToolStripMenuItem
            // 
            this.forecastingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.forecastingToolStripMenuItem.Name = "forecastingToolStripMenuItem";
            this.forecastingToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.forecastingToolStripMenuItem.Text = "&Прогнозирование";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(403, 26);
            this.toolStripMenuItem1.Text = "По среднему коэффициенту роста";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.forecastingChanges);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(403, 26);
            this.toolStripMenuItem2.Text = "На основе стационарного временного ряда";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.forecastingChanges);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(403, 26);
            this.toolStripMenuItem3.Text = "На основе средних показателей динамики";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.forecastingChanges);
            // 
            // таблицаToolStripMenuItem
            // 
            this.таблицаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.separatorToolStripMenuItem});
            this.таблицаToolStripMenuItem.Name = "таблицаToolStripMenuItem";
            this.таблицаToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.таблицаToolStripMenuItem.Text = "&Таблица";
            // 
            // separatorToolStripMenuItem
            // 
            this.separatorToolStripMenuItem.Name = "separatorToolStripMenuItem";
            this.separatorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.separatorToolStripMenuItem.Text = "&Разделитель";
            this.separatorToolStripMenuItem.Click += new System.EventHandler(this.separatorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.helpToolStripMenuItem.Text = "Спра&вка";
            // 
            // contentToolStripMenuItem
            // 
            this.contentToolStripMenuItem.Name = "contentToolStripMenuItem";
            this.contentToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.contentToolStripMenuItem.Text = "&Содержание";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(193, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.aboutToolStripMenuItem.Text = "&О программе...";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "PDF file|*.pdf";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 719);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Временные ряды";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimeSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeSeries)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonPlotGraph;
        private System.Windows.Forms.DataGridView dataGridViewTimeSeries;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTimeSeries;
        private System.Windows.Forms.ToolStripMenuItem графикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forecastingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curvedLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem straightLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radarToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

