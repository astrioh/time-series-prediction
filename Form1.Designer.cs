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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewTimeSeries = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AverageChainGrowthRatePercent = new System.Windows.Forms.Label();
            this.AverageAbsoluteIncreaseLabel = new System.Windows.Forms.Label();
            this.AverageRowLevelLabel = new System.Windows.Forms.Label();
            this.buttonAnalyzeAndForecast = new System.Windows.Forms.Button();
            this.chartTimeSeries = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sendToMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исходныеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прогнозированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curvedLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.straightLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastingMethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поСреднемуКоэффициентуРостаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наОсновеМетодаСкользящейСреднейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наОсновеСреднихПоказателейДинамикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NumberOfPredictedValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimeSeries)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeSeries)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartTimeSeries);
            this.splitContainer1.Size = new System.Drawing.Size(1011, 560);
            this.splitContainer1.SplitterDistance = 399;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridViewTimeSeries);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Controls.Add(this.buttonAnalyzeAndForecast);
            this.splitContainer2.Panel2MinSize = 125;
            this.splitContainer2.Size = new System.Drawing.Size(399, 560);
            this.splitContainer2.SplitterDistance = 429;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridViewTimeSeries
            // 
            this.dataGridViewTimeSeries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewTimeSeries.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTimeSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTimeSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTimeSeries.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTimeSeries.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewTimeSeries.MultiSelect = false;
            this.dataGridViewTimeSeries.Name = "dataGridViewTimeSeries";
            this.dataGridViewTimeSeries.ReadOnly = true;
            this.dataGridViewTimeSeries.RowHeadersVisible = false;
            this.dataGridViewTimeSeries.RowHeadersWidth = 51;
            this.dataGridViewTimeSeries.RowTemplate.Height = 24;
            this.dataGridViewTimeSeries.Size = new System.Drawing.Size(399, 429);
            this.dataGridViewTimeSeries.TabIndex = 4;
            this.dataGridViewTimeSeries.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewTimeSeries_CellPainting);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AverageChainGrowthRatePercent);
            this.panel1.Controls.Add(this.AverageAbsoluteIncreaseLabel);
            this.panel1.Controls.Add(this.AverageRowLevelLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(399, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 96);
            this.panel1.TabIndex = 5;
            // 
            // AverageChainGrowthRatePercent
            // 
            this.AverageChainGrowthRatePercent.AutoSize = true;
            this.AverageChainGrowthRatePercent.Dock = System.Windows.Forms.DockStyle.Top;
            this.AverageChainGrowthRatePercent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AverageChainGrowthRatePercent.Location = new System.Drawing.Point(0, 58);
            this.AverageChainGrowthRatePercent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AverageChainGrowthRatePercent.Name = "AverageChainGrowthRatePercent";
            this.AverageChainGrowthRatePercent.Padding = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.AverageChainGrowthRatePercent.Size = new System.Drawing.Size(10, 24);
            this.AverageChainGrowthRatePercent.TabIndex = 10;
            // 
            // AverageAbsoluteIncreaseLabel
            // 
            this.AverageAbsoluteIncreaseLabel.AutoSize = true;
            this.AverageAbsoluteIncreaseLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AverageAbsoluteIncreaseLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AverageAbsoluteIncreaseLabel.Location = new System.Drawing.Point(0, 34);
            this.AverageAbsoluteIncreaseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AverageAbsoluteIncreaseLabel.Name = "AverageAbsoluteIncreaseLabel";
            this.AverageAbsoluteIncreaseLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.AverageAbsoluteIncreaseLabel.Size = new System.Drawing.Size(10, 24);
            this.AverageAbsoluteIncreaseLabel.TabIndex = 9;
            // 
            // AverageRowLevelLabel
            // 
            this.AverageRowLevelLabel.AutoSize = true;
            this.AverageRowLevelLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AverageRowLevelLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AverageRowLevelLabel.Location = new System.Drawing.Point(0, 0);
            this.AverageRowLevelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AverageRowLevelLabel.Name = "AverageRowLevelLabel";
            this.AverageRowLevelLabel.Padding = new System.Windows.Forms.Padding(10, 10, 0, 5);
            this.AverageRowLevelLabel.Size = new System.Drawing.Size(10, 34);
            this.AverageRowLevelLabel.TabIndex = 8;
            // 
            // buttonAnalyzeAndForecast
            // 
            this.buttonAnalyzeAndForecast.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAnalyzeAndForecast.Enabled = false;
            this.buttonAnalyzeAndForecast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAnalyzeAndForecast.Location = new System.Drawing.Point(0, 96);
            this.buttonAnalyzeAndForecast.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAnalyzeAndForecast.Name = "buttonAnalyzeAndForecast";
            this.buttonAnalyzeAndForecast.Size = new System.Drawing.Size(399, 32);
            this.buttonAnalyzeAndForecast.TabIndex = 4;
            this.buttonAnalyzeAndForecast.Text = "Проанализировать и спрогнозировать";
            this.buttonAnalyzeAndForecast.UseVisualStyleBackColor = true;
            this.buttonAnalyzeAndForecast.Click += new System.EventHandler(this.buttonAnalyzeAndForecast_Click);
            // 
            // chartTimeSeries
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTimeSeries.ChartAreas.Add(chartArea1);
            this.chartTimeSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTimeSeries.Location = new System.Drawing.Point(0, 0);
            this.chartTimeSeries.Margin = new System.Windows.Forms.Padding(2);
            this.chartTimeSeries.Name = "chartTimeSeries";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "Series2";
            this.chartTimeSeries.Series.Add(series1);
            this.chartTimeSeries.Series.Add(series2);
            this.chartTimeSeries.Size = new System.Drawing.Size(611, 560);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1011, 24);
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
            this.toolStripSeparator3,
            this.sendToMailToolStripMenuItem,
            this.toolStripSeparator2,
            this.очиститьToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.openToolStripMenuItem.Text = "&Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(180, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveToolStripMenuItem.Text = "&Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.printToolStripMenuItem.Text = "&Печать";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // sendToMailToolStripMenuItem
            // 
            this.sendToMailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendToMailToolStripMenuItem.Image")));
            this.sendToMailToolStripMenuItem.Name = "sendToMailToolStripMenuItem";
            this.sendToMailToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.sendToMailToolStripMenuItem.Text = "&Отправить на почту";
            this.sendToMailToolStripMenuItem.Click += new System.EventHandler(this.sendToMailToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.очиститьToolStripMenuItem.Text = "&Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(180, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.exitToolStripMenuItem.Text = "Вы&ход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // графикToolStripMenuItem
            // 
            this.графикToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.graphTypeToolStripMenuItem});
            this.графикToolStripMenuItem.Name = "графикToolStripMenuItem";
            this.графикToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.графикToolStripMenuItem.Text = "&График";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.исходныеДанныеToolStripMenuItem,
            this.прогнозированиеToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.colorToolStripMenuItem.Text = "&Цвет";
            // 
            // исходныеДанныеToolStripMenuItem
            // 
            this.исходныеДанныеToolStripMenuItem.Name = "исходныеДанныеToolStripMenuItem";
            this.исходныеДанныеToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.исходныеДанныеToolStripMenuItem.Text = "&Исходные данные";
            this.исходныеДанныеToolStripMenuItem.Click += new System.EventHandler(this.initialColorToolStripMenuItem_Click);
            // 
            // прогнозированиеToolStripMenuItem
            // 
            this.прогнозированиеToolStripMenuItem.Name = "прогнозированиеToolStripMenuItem";
            this.прогнозированиеToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.прогнозированиеToolStripMenuItem.Text = "&Прогнозирование";
            this.прогнозированиеToolStripMenuItem.Click += new System.EventHandler(this.forecastColorToolStripMenuItem_Click);
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
            this.graphTypeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.graphTypeToolStripMenuItem.Text = "&Тип";
            // 
            // curvedLineToolStripMenuItem
            // 
            this.curvedLineToolStripMenuItem.Checked = true;
            this.curvedLineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.curvedLineToolStripMenuItem.Name = "curvedLineToolStripMenuItem";
            this.curvedLineToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.curvedLineToolStripMenuItem.Tag = "0";
            this.curvedLineToolStripMenuItem.Text = "Кривая линия";
            this.curvedLineToolStripMenuItem.Click += new System.EventHandler(this.graphTypeChanges);
            // 
            // straightLineToolStripMenuItem
            // 
            this.straightLineToolStripMenuItem.Name = "straightLineToolStripMenuItem";
            this.straightLineToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.straightLineToolStripMenuItem.Tag = "1";
            this.straightLineToolStripMenuItem.Text = "Прямая линия";
            this.straightLineToolStripMenuItem.Click += new System.EventHandler(this.graphTypeChanges);
            // 
            // barToolStripMenuItem
            // 
            this.barToolStripMenuItem.Name = "barToolStripMenuItem";
            this.barToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.barToolStripMenuItem.Tag = "2";
            this.barToolStripMenuItem.Text = "Бар";
            this.barToolStripMenuItem.Click += new System.EventHandler(this.graphTypeChanges);
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.columnsToolStripMenuItem.Tag = "3";
            this.columnsToolStripMenuItem.Text = "Колонны";
            this.columnsToolStripMenuItem.Click += new System.EventHandler(this.graphTypeChanges);
            // 
            // radarToolStripMenuItem
            // 
            this.radarToolStripMenuItem.Name = "radarToolStripMenuItem";
            this.radarToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.radarToolStripMenuItem.Tag = "4";
            this.radarToolStripMenuItem.Text = "Радар";
            this.radarToolStripMenuItem.Click += new System.EventHandler(this.graphTypeChanges);
            // 
            // forecastingToolStripMenuItem
            // 
            this.forecastingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forecastingMethodsToolStripMenuItem,
            this.NumberOfPredictedValuesToolStripMenuItem});
            this.forecastingToolStripMenuItem.Name = "forecastingToolStripMenuItem";
            this.forecastingToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.forecastingToolStripMenuItem.Text = "&Прогнозирование";
            // 
            // forecastingMethodsToolStripMenuItem
            // 
            this.forecastingMethodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поСреднемуКоэффициентуРостаToolStripMenuItem,
            this.наОсновеМетодаСкользящейСреднейToolStripMenuItem,
            this.наОсновеСреднихПоказателейДинамикиToolStripMenuItem});
            this.forecastingMethodsToolStripMenuItem.Name = "forecastingMethodsToolStripMenuItem";
            this.forecastingMethodsToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.forecastingMethodsToolStripMenuItem.Text = "&Метод прогнозирования";
            // 
            // поСреднемуКоэффициентуРостаToolStripMenuItem
            // 
            this.поСреднемуКоэффициентуРостаToolStripMenuItem.Checked = true;
            this.поСреднемуКоэффициентуРостаToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.поСреднемуКоэффициентуРостаToolStripMenuItem.Name = "поСреднемуКоэффициентуРостаToolStripMenuItem";
            this.поСреднемуКоэффициентуРостаToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.поСреднемуКоэффициентуРостаToolStripMenuItem.Tag = "0";
            this.поСреднемуКоэффициентуРостаToolStripMenuItem.Text = "По среднему коэффициенту роста";
            this.поСреднемуКоэффициентуРостаToolStripMenuItem.Click += new System.EventHandler(this.forecastingChanges);
            // 
            // наОсновеМетодаСкользящейСреднейToolStripMenuItem
            // 
            this.наОсновеМетодаСкользящейСреднейToolStripMenuItem.Name = "наОсновеМетодаСкользящейСреднейToolStripMenuItem";
            this.наОсновеМетодаСкользящейСреднейToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.наОсновеМетодаСкользящейСреднейToolStripMenuItem.Tag = "1";
            this.наОсновеМетодаСкользящейСреднейToolStripMenuItem.Text = "На основе метода скользящей средней";
            this.наОсновеМетодаСкользящейСреднейToolStripMenuItem.Click += new System.EventHandler(this.forecastingChanges);
            // 
            // наОсновеСреднихПоказателейДинамикиToolStripMenuItem
            // 
            this.наОсновеСреднихПоказателейДинамикиToolStripMenuItem.Name = "наОсновеСреднихПоказателейДинамикиToolStripMenuItem";
            this.наОсновеСреднихПоказателейДинамикиToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.наОсновеСреднихПоказателейДинамикиToolStripMenuItem.Tag = "2";
            this.наОсновеСреднихПоказателейДинамикиToolStripMenuItem.Text = "На основе средних показателей динамики";
            this.наОсновеСреднихПоказателейДинамикиToolStripMenuItem.Click += new System.EventHandler(this.forecastingChanges);
            // 
            // NumberOfPredictedValuesToolStripMenuItem
            // 
            this.NumberOfPredictedValuesToolStripMenuItem.Name = "NumberOfPredictedValuesToolStripMenuItem";
            this.NumberOfPredictedValuesToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.NumberOfPredictedValuesToolStripMenuItem.Text = "&Количество прогнозируемых значений";
            this.NumberOfPredictedValuesToolStripMenuItem.Click += new System.EventHandler(this.NumberOfPredictedValuesToolStripMenuItem_Click);
            // 
            // таблицаToolStripMenuItem
            // 
            this.таблицаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.separatorToolStripMenuItem});
            this.таблицаToolStripMenuItem.Name = "таблицаToolStripMenuItem";
            this.таблицаToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.таблицаToolStripMenuItem.Text = "&Данные";
            // 
            // separatorToolStripMenuItem
            // 
            this.separatorToolStripMenuItem.Name = "separatorToolStripMenuItem";
            this.separatorToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.separatorToolStripMenuItem.Text = "&Разделитель CSV файла";
            this.separatorToolStripMenuItem.Click += new System.EventHandler(this.separatorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "Спра&вка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 584);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Временные ряды";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimeSeries)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
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
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem sendToMailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridViewTimeSeries;
        private System.Windows.Forms.Button buttonAnalyzeAndForecast;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label AverageChainGrowthRatePercent;
        private System.Windows.Forms.Label AverageAbsoluteIncreaseLabel;
        private System.Windows.Forms.Label AverageRowLevelLabel;
        private System.Windows.Forms.ToolStripMenuItem NumberOfPredictedValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forecastingMethodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поСреднемуКоэффициентуРостаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наОсновеМетодаСкользящейСреднейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наОсновеСреднихПоказателейДинамикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исходныеДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прогнозированиеToolStripMenuItem;
    }
}

