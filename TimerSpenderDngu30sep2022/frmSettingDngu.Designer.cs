using System.Windows.Forms;

namespace TimerSpenderDngu30sep2022
{
    partial class frmSettingDngu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettingDngu));
            this.lblAddTaskDngu = new System.Windows.Forms.Label();
            this.btnAddStandartTaskDngu = new System.Windows.Forms.Button();
            this.txbAddStandartTaskDngu = new System.Windows.Forms.TextBox();
            this.lblDeleteTask = new System.Windows.Forms.Label();
            this.btnDeleteTaskDngu = new System.Windows.Forms.Button();
            this.lsbTaskDngu = new System.Windows.Forms.ListBox();
            this.btnFinishedDngu = new System.Windows.Forms.Button();
            this.btnCloseSettingDngu = new System.Windows.Forms.Button();
            this.btnSaveSetttingDngu = new System.Windows.Forms.Button();
            this.btnFileLocationDngu = new System.Windows.Forms.Button();
            this.lblFileLocation = new System.Windows.Forms.Label();
            this.txbFilelocationDngu = new System.Windows.Forms.TextBox();
            this.nudLogIntervalDngu = new System.Windows.Forms.NumericUpDown();
            this.lblLogInteralDngu = new System.Windows.Forms.Label();
            this.ofdOpenLogDngu = new System.Windows.Forms.OpenFileDialog();
            this.crtTaskDngu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnShowChart = new System.Windows.Forms.Button();
            this.cmbChartTypesDngu = new System.Windows.Forms.ComboBox();
            this.btnShowExcelDngu = new System.Windows.Forms.Button();
            this.btnSaveExcelDngu = new System.Windows.Forms.Button();
            this.btnDisplayExcel = new System.Windows.Forms.Button();
            this.dgvExcelDngu = new System.Windows.Forms.DataGridView();
            this.task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSpend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDefaultTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbChartDate = new System.Windows.Forms.ComboBox();
            this.lblDateSlectionDngu = new System.Windows.Forms.Label();
            this.lblChartType = new System.Windows.Forms.Label();
            this.cmbChartSortDngu = new System.Windows.Forms.ComboBox();
            this.lblPastDays = new System.Windows.Forms.Label();
            this.btnPastDays = new System.Windows.Forms.Button();
            this.nudPastdays = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudLogIntervalDngu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtTaskDngu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelDngu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPastdays)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddTaskDngu
            // 
            this.lblAddTaskDngu.AutoSize = true;
            this.lblAddTaskDngu.BackColor = System.Drawing.Color.Transparent;
            this.lblAddTaskDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblAddTaskDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblAddTaskDngu.Location = new System.Drawing.Point(289, 111);
            this.lblAddTaskDngu.Name = "lblAddTaskDngu";
            this.lblAddTaskDngu.Size = new System.Drawing.Size(200, 26);
            this.lblAddTaskDngu.TabIndex = 5;
            this.lblAddTaskDngu.Text = "Adding standart task";
            // 
            // btnAddStandartTaskDngu
            // 
            this.btnAddStandartTaskDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddStandartTaskDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnAddStandartTaskDngu.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnAddStandartTaskDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStandartTaskDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddStandartTaskDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnAddStandartTaskDngu.Location = new System.Drawing.Point(553, 146);
            this.btnAddStandartTaskDngu.Name = "btnAddStandartTaskDngu";
            this.btnAddStandartTaskDngu.Size = new System.Drawing.Size(124, 36);
            this.btnAddStandartTaskDngu.TabIndex = 4;
            this.btnAddStandartTaskDngu.Text = "Add";
            this.btnAddStandartTaskDngu.UseVisualStyleBackColor = false;
            this.btnAddStandartTaskDngu.Click += new System.EventHandler(this.btnAddStandartTaskDngu_Click);
            // 
            // txbAddStandartTaskDngu
            // 
            this.txbAddStandartTaskDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.txbAddStandartTaskDngu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbAddStandartTaskDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txbAddStandartTaskDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.txbAddStandartTaskDngu.Location = new System.Drawing.Point(294, 146);
            this.txbAddStandartTaskDngu.Multiline = true;
            this.txbAddStandartTaskDngu.Name = "txbAddStandartTaskDngu";
            this.txbAddStandartTaskDngu.Size = new System.Drawing.Size(254, 36);
            this.txbAddStandartTaskDngu.TabIndex = 3;
            // 
            // lblDeleteTask
            // 
            this.lblDeleteTask.AutoSize = true;
            this.lblDeleteTask.BackColor = System.Drawing.Color.Transparent;
            this.lblDeleteTask.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblDeleteTask.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblDeleteTask.Location = new System.Drawing.Point(289, 185);
            this.lblDeleteTask.Name = "lblDeleteTask";
            this.lblDeleteTask.Size = new System.Drawing.Size(191, 26);
            this.lblDeleteTask.TabIndex = 2;
            this.lblDeleteTask.Text = "Delete standart task";
            // 
            // btnDeleteTaskDngu
            // 
            this.btnDeleteTaskDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDeleteTaskDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnDeleteTaskDngu.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnDeleteTaskDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTaskDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteTaskDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnDeleteTaskDngu.Location = new System.Drawing.Point(554, 214);
            this.btnDeleteTaskDngu.Name = "btnDeleteTaskDngu";
            this.btnDeleteTaskDngu.Size = new System.Drawing.Size(124, 144);
            this.btnDeleteTaskDngu.TabIndex = 1;
            this.btnDeleteTaskDngu.Text = "Delete Task";
            this.btnDeleteTaskDngu.UseVisualStyleBackColor = false;
            this.btnDeleteTaskDngu.Click += new System.EventHandler(this.btnDeleteTaskDngu_Click);
            // 
            // lsbTaskDngu
            // 
            this.lsbTaskDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lsbTaskDngu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsbTaskDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lsbTaskDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.lsbTaskDngu.FormattingEnabled = true;
            this.lsbTaskDngu.ItemHeight = 16;
            this.lsbTaskDngu.Location = new System.Drawing.Point(294, 214);
            this.lsbTaskDngu.Name = "lsbTaskDngu";
            this.lsbTaskDngu.Size = new System.Drawing.Size(254, 144);
            this.lsbTaskDngu.TabIndex = 6;
            // 
            // btnFinishedDngu
            // 
            this.btnFinishedDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnFinishedDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnFinishedDngu.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnFinishedDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinishedDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFinishedDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnFinishedDngu.Location = new System.Drawing.Point(294, 364);
            this.btnFinishedDngu.Name = "btnFinishedDngu";
            this.btnFinishedDngu.Size = new System.Drawing.Size(124, 46);
            this.btnFinishedDngu.TabIndex = 7;
            this.btnFinishedDngu.Text = "Finish for today";
            this.btnFinishedDngu.UseVisualStyleBackColor = false;
            this.btnFinishedDngu.Click += new System.EventHandler(this.btnFinishedDngu_Click);
            // 
            // btnCloseSettingDngu
            // 
            this.btnCloseSettingDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCloseSettingDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnCloseSettingDngu.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnCloseSettingDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSettingDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCloseSettingDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnCloseSettingDngu.Location = new System.Drawing.Point(424, 364);
            this.btnCloseSettingDngu.Name = "btnCloseSettingDngu";
            this.btnCloseSettingDngu.Size = new System.Drawing.Size(124, 46);
            this.btnCloseSettingDngu.TabIndex = 8;
            this.btnCloseSettingDngu.Text = "Close";
            this.btnCloseSettingDngu.UseVisualStyleBackColor = false;
            this.btnCloseSettingDngu.Click += new System.EventHandler(this.btnCloseSettingDngu_Click);
            // 
            // btnSaveSetttingDngu
            // 
            this.btnSaveSetttingDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSaveSetttingDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnSaveSetttingDngu.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnSaveSetttingDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSetttingDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSaveSetttingDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnSaveSetttingDngu.Location = new System.Drawing.Point(554, 364);
            this.btnSaveSetttingDngu.Name = "btnSaveSetttingDngu";
            this.btnSaveSetttingDngu.Size = new System.Drawing.Size(124, 46);
            this.btnSaveSetttingDngu.TabIndex = 9;
            this.btnSaveSetttingDngu.Text = "Save";
            this.btnSaveSetttingDngu.UseVisualStyleBackColor = false;
            this.btnSaveSetttingDngu.Click += new System.EventHandler(this.btnSaveSetttingDngu_Click);
            // 
            // btnFileLocationDngu
            // 
            this.btnFileLocationDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnFileLocationDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnFileLocationDngu.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnFileLocationDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileLocationDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnFileLocationDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnFileLocationDngu.Location = new System.Drawing.Point(554, 31);
            this.btnFileLocationDngu.Name = "btnFileLocationDngu";
            this.btnFileLocationDngu.Size = new System.Drawing.Size(124, 43);
            this.btnFileLocationDngu.TabIndex = 10;
            this.btnFileLocationDngu.Text = "Brows";
            this.btnFileLocationDngu.UseVisualStyleBackColor = false;
            this.btnFileLocationDngu.Click += new System.EventHandler(this.btnFileLocationDngu_Click);
            // 
            // lblFileLocation
            // 
            this.lblFileLocation.AutoSize = true;
            this.lblFileLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblFileLocation.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblFileLocation.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblFileLocation.Location = new System.Drawing.Point(10, 8);
            this.lblFileLocation.Name = "lblFileLocation";
            this.lblFileLocation.Size = new System.Drawing.Size(147, 24);
            this.lblFileLocation.TabIndex = 12;
            this.lblFileLocation.Text = "Log File location";
            // 
            // txbFilelocationDngu
            // 
            this.txbFilelocationDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.txbFilelocationDngu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbFilelocationDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilelocationDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.txbFilelocationDngu.Location = new System.Drawing.Point(10, 31);
            this.txbFilelocationDngu.Multiline = true;
            this.txbFilelocationDngu.Name = "txbFilelocationDngu";
            this.txbFilelocationDngu.Size = new System.Drawing.Size(538, 43);
            this.txbFilelocationDngu.TabIndex = 13;
            // 
            // nudLogIntervalDngu
            // 
            this.nudLogIntervalDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.nudLogIntervalDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.nudLogIntervalDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.nudLogIntervalDngu.Location = new System.Drawing.Point(14, 140);
            this.nudLogIntervalDngu.Name = "nudLogIntervalDngu";
            this.nudLogIntervalDngu.Size = new System.Drawing.Size(159, 24);
            this.nudLogIntervalDngu.TabIndex = 14;
            this.nudLogIntervalDngu.ValueChanged += new System.EventHandler(this.nudLogIntervalDngu_ValueChanged);
            this.nudLogIntervalDngu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudLogIntervalDngu_KeyPress);
            // 
            // lblLogInteralDngu
            // 
            this.lblLogInteralDngu.AutoSize = true;
            this.lblLogInteralDngu.BackColor = System.Drawing.Color.Transparent;
            this.lblLogInteralDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblLogInteralDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblLogInteralDngu.Location = new System.Drawing.Point(9, 111);
            this.lblLogInteralDngu.Name = "lblLogInteralDngu";
            this.lblLogInteralDngu.Size = new System.Drawing.Size(208, 26);
            this.lblLogInteralDngu.TabIndex = 15;
            this.lblLogInteralDngu.Text = "Log interval ( minute)";
            // 
            // ofdOpenLogDngu
            // 
            this.ofdOpenLogDngu.FileName = "openFileDialog1";
            // 
            // crtTaskDngu
            // 
            chartArea1.Name = "ChartArea1";
            this.crtTaskDngu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.crtTaskDngu.Legends.Add(legend1);
            this.crtTaskDngu.Location = new System.Drawing.Point(10, 531);
            this.crtTaskDngu.Name = "crtTaskDngu";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            series1.Legend = "Legend1";
            series1.Name = "Time spend";
            this.crtTaskDngu.Series.Add(series1);
            this.crtTaskDngu.Size = new System.Drawing.Size(668, 308);
            this.crtTaskDngu.TabIndex = 16;
            this.crtTaskDngu.Text = "chart1";
            // 
            // btnShowChart
            // 
            this.btnShowChart.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnShowChart.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnShowChart.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnShowChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowChart.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnShowChart.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnShowChart.Location = new System.Drawing.Point(10, 364);
            this.btnShowChart.Name = "btnShowChart";
            this.btnShowChart.Size = new System.Drawing.Size(124, 46);
            this.btnShowChart.TabIndex = 17;
            this.btnShowChart.Text = "Show chart";
            this.btnShowChart.UseVisualStyleBackColor = false;
            this.btnShowChart.Click += new System.EventHandler(this.btnShowChart_Click);
            // 
            // cmbChartTypesDngu
            // 
            this.cmbChartTypesDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cmbChartTypesDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChartTypesDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.cmbChartTypesDngu.FormattingEnabled = true;
            this.cmbChartTypesDngu.Location = new System.Drawing.Point(282, 446);
            this.cmbChartTypesDngu.Name = "cmbChartTypesDngu";
            this.cmbChartTypesDngu.Size = new System.Drawing.Size(121, 23);
            this.cmbChartTypesDngu.TabIndex = 18;
            this.cmbChartTypesDngu.SelectedIndexChanged += new System.EventHandler(this.cmbChartTypesDngu_SelectedIndexChanged);
            // 
            // btnShowExcelDngu
            // 
            this.btnShowExcelDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnShowExcelDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnShowExcelDngu.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnShowExcelDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowExcelDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnShowExcelDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnShowExcelDngu.Location = new System.Drawing.Point(10, 312);
            this.btnShowExcelDngu.Name = "btnShowExcelDngu";
            this.btnShowExcelDngu.Size = new System.Drawing.Size(124, 46);
            this.btnShowExcelDngu.TabIndex = 19;
            this.btnShowExcelDngu.Text = "Show Excel";
            this.btnShowExcelDngu.UseVisualStyleBackColor = false;
            this.btnShowExcelDngu.Click += new System.EventHandler(this.btnShowExcelDngu_Click);
            // 
            // btnSaveExcelDngu
            // 
            this.btnSaveExcelDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSaveExcelDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnSaveExcelDngu.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnSaveExcelDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveExcelDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSaveExcelDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnSaveExcelDngu.Location = new System.Drawing.Point(881, 31);
            this.btnSaveExcelDngu.Name = "btnSaveExcelDngu";
            this.btnSaveExcelDngu.Size = new System.Drawing.Size(124, 46);
            this.btnSaveExcelDngu.TabIndex = 20;
            this.btnSaveExcelDngu.Text = "Save task in Excel";
            this.btnSaveExcelDngu.UseVisualStyleBackColor = false;
            this.btnSaveExcelDngu.Click += new System.EventHandler(this.btnSaveExcelDngu_Click);
            // 
            // btnDisplayExcel
            // 
            this.btnDisplayExcel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDisplayExcel.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnDisplayExcel.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnDisplayExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplayExcel.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDisplayExcel.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnDisplayExcel.Location = new System.Drawing.Point(751, 31);
            this.btnDisplayExcel.Name = "btnDisplayExcel";
            this.btnDisplayExcel.Size = new System.Drawing.Size(124, 46);
            this.btnDisplayExcel.TabIndex = 21;
            this.btnDisplayExcel.Text = "Display Excel";
            this.btnDisplayExcel.UseVisualStyleBackColor = false;
            this.btnDisplayExcel.Click += new System.EventHandler(this.btnDisplayExcel_Click);
            // 
            // dgvExcelDngu
            // 
            this.dgvExcelDngu.AllowUserToAddRows = false;
            this.dgvExcelDngu.AllowUserToDeleteRows = false;
            this.dgvExcelDngu.AllowUserToResizeColumns = false;
            this.dgvExcelDngu.AllowUserToResizeRows = false;
            this.dgvExcelDngu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvExcelDngu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcelDngu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.task,
            this.timeSpend,
            this.date,
            this.isDefaultTask});
            this.dgvExcelDngu.Location = new System.Drawing.Point(751, 83);
            this.dgvExcelDngu.Name = "dgvExcelDngu";
            this.dgvExcelDngu.RowHeadersVisible = false;
            this.dgvExcelDngu.RowTemplate.ReadOnly = true;
            this.dgvExcelDngu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExcelDngu.Size = new System.Drawing.Size(467, 327);
            this.dgvExcelDngu.TabIndex = 22;
            // 
            // task
            // 
            this.task.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.task.HeaderText = "Task";
            this.task.Name = "task";
            this.task.ReadOnly = true;
            // 
            // timeSpend
            // 
            this.timeSpend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeSpend.HeaderText = "Time spend ( minute )";
            this.timeSpend.Name = "timeSpend";
            this.timeSpend.ReadOnly = true;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.date.HeaderText = "Date of task";
            this.date.Name = "date";
            // 
            // isDefaultTask
            // 
            this.isDefaultTask.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.isDefaultTask.HeaderText = "Is default task";
            this.isDefaultTask.Name = "isDefaultTask";
            this.isDefaultTask.ReadOnly = true;
            // 
            // cmbChartDate
            // 
            this.cmbChartDate.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cmbChartDate.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChartDate.ForeColor = System.Drawing.Color.Goldenrod;
            this.cmbChartDate.FormattingEnabled = true;
            this.cmbChartDate.Items.AddRange(new object[] {
            "All"});
            this.cmbChartDate.Location = new System.Drawing.Point(553, 446);
            this.cmbChartDate.Name = "cmbChartDate";
            this.cmbChartDate.Size = new System.Drawing.Size(121, 23);
            this.cmbChartDate.TabIndex = 23;
            this.cmbChartDate.SelectedIndexChanged += new System.EventHandler(this.cmbChartDate_SelectedIndexChanged);
            // 
            // lblDateSlectionDngu
            // 
            this.lblDateSlectionDngu.AutoSize = true;
            this.lblDateSlectionDngu.BackColor = System.Drawing.Color.Transparent;
            this.lblDateSlectionDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblDateSlectionDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblDateSlectionDngu.Location = new System.Drawing.Point(409, 444);
            this.lblDateSlectionDngu.Name = "lblDateSlectionDngu";
            this.lblDateSlectionDngu.Size = new System.Drawing.Size(145, 26);
            this.lblDateSlectionDngu.TabIndex = 24;
            this.lblDateSlectionDngu.Text = "Date selection:";
            // 
            // lblChartType
            // 
            this.lblChartType.AutoSize = true;
            this.lblChartType.BackColor = System.Drawing.Color.Transparent;
            this.lblChartType.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblChartType.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblChartType.Location = new System.Drawing.Point(157, 444);
            this.lblChartType.Name = "lblChartType";
            this.lblChartType.Size = new System.Drawing.Size(119, 26);
            this.lblChartType.TabIndex = 25;
            this.lblChartType.Text = "Chart Type:";
            // 
            // cmbChartSortDngu
            // 
            this.cmbChartSortDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cmbChartSortDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChartSortDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.cmbChartSortDngu.FormattingEnabled = true;
            this.cmbChartSortDngu.Location = new System.Drawing.Point(10, 444);
            this.cmbChartSortDngu.Name = "cmbChartSortDngu";
            this.cmbChartSortDngu.Size = new System.Drawing.Size(121, 23);
            this.cmbChartSortDngu.TabIndex = 26;
            this.cmbChartSortDngu.SelectedIndexChanged += new System.EventHandler(this.cmbChartSortDngu_SelectedIndexChanged);
            // 
            // lblPastDays
            // 
            this.lblPastDays.AutoSize = true;
            this.lblPastDays.BackColor = System.Drawing.Color.Transparent;
            this.lblPastDays.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPastDays.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblPastDays.Location = new System.Drawing.Point(157, 492);
            this.lblPastDays.Name = "lblPastDays";
            this.lblPastDays.Size = new System.Drawing.Size(101, 26);
            this.lblPastDays.TabIndex = 28;
            this.lblPastDays.Text = "Past days:";
            // 
            // btnPastDays
            // 
            this.btnPastDays.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnPastDays.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnPastDays.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.btnPastDays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPastDays.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPastDays.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnPastDays.Location = new System.Drawing.Point(427, 496);
            this.btnPastDays.Name = "btnPastDays";
            this.btnPastDays.Size = new System.Drawing.Size(127, 24);
            this.btnPastDays.TabIndex = 29;
            this.btnPastDays.Text = "Check";
            this.btnPastDays.UseVisualStyleBackColor = false;
            this.btnPastDays.Click += new System.EventHandler(this.btnPastDays_Click);
            // 
            // nudPastdays
            // 
            this.nudPastdays.BackColor = System.Drawing.Color.DarkSlateGray;
            this.nudPastdays.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.nudPastdays.ForeColor = System.Drawing.Color.Goldenrod;
            this.nudPastdays.Location = new System.Drawing.Point(262, 496);
            this.nudPastdays.Name = "nudPastdays";
            this.nudPastdays.Size = new System.Drawing.Size(159, 24);
            this.nudPastdays.TabIndex = 30;
            // 
            // frmSettingDngu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TimerSpenderDngu30sep2022.Properties.Resources.brackets_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1224, 850);
            this.Controls.Add(this.nudPastdays);
            this.Controls.Add(this.btnPastDays);
            this.Controls.Add(this.lblPastDays);
            this.Controls.Add(this.cmbChartSortDngu);
            this.Controls.Add(this.lblChartType);
            this.Controls.Add(this.lblDateSlectionDngu);
            this.Controls.Add(this.cmbChartDate);
            this.Controls.Add(this.dgvExcelDngu);
            this.Controls.Add(this.btnDisplayExcel);
            this.Controls.Add(this.btnSaveExcelDngu);
            this.Controls.Add(this.btnShowExcelDngu);
            this.Controls.Add(this.cmbChartTypesDngu);
            this.Controls.Add(this.btnShowChart);
            this.Controls.Add(this.crtTaskDngu);
            this.Controls.Add(this.lblLogInteralDngu);
            this.Controls.Add(this.nudLogIntervalDngu);
            this.Controls.Add(this.txbFilelocationDngu);
            this.Controls.Add(this.lblFileLocation);
            this.Controls.Add(this.btnFileLocationDngu);
            this.Controls.Add(this.btnSaveSetttingDngu);
            this.Controls.Add(this.btnCloseSettingDngu);
            this.Controls.Add(this.btnFinishedDngu);
            this.Controls.Add(this.lsbTaskDngu);
            this.Controls.Add(this.btnDeleteTaskDngu);
            this.Controls.Add(this.lblDeleteTask);
            this.Controls.Add(this.btnAddStandartTaskDngu);
            this.Controls.Add(this.lblAddTaskDngu);
            this.Controls.Add(this.txbAddStandartTaskDngu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettingDngu";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettingDngu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLogIntervalDngu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtTaskDngu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelDngu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPastdays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblAddTaskDngu;
        private Button btnAddStandartTaskDngu;
        private TextBox txbAddStandartTaskDngu;
        private Label lblDeleteTask;
        private Button btnDeleteTaskDngu;
        private ListBox lsbTaskDngu;
        private Button btnFinishedDngu;
        private Button btnCloseSettingDngu;
        private Button btnSaveSetttingDngu;
        private Button btnFileLocationDngu;
        private Label lblFileLocation;
        private TextBox txbFilelocationDngu;
        private NumericUpDown nudLogIntervalDngu;
        private Label lblLogInteralDngu;
        private OpenFileDialog ofdOpenLogDngu;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtTaskDngu;
        private Button btnShowChart;
        private ComboBox cmbChartTypesDngu;
        private Button btnShowExcelDngu;
        private Button btnSaveExcelDngu;
        private Button btnDisplayExcel;
        private DataGridView dgvExcelDngu;
        private DataGridViewTextBoxColumn task;
        private DataGridViewTextBoxColumn timeSpend;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn isDefaultTask;
        private ComboBox cmbChartDate;
        private Label lblDateSlectionDngu;
        private Label lblChartType;
        private ComboBox cmbChartSortDngu;
        private Label lblPastDays;
        private Button btnPastDays;
        private NumericUpDown nudPastdays;
    }
}