using Luminescence.DesktopUI.WinForm.Code;

namespace Luminescence.DesktopUI.WinForm
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepMotorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_connectionStatus = new System.Windows.Forms.Label();
            this.gb_mainForm = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_fileName = new System.Windows.Forms.TextBox();
            this.gb_proccessInformation = new System.Windows.Forms.GroupBox();
            this.lbl_elapsedTime = new System.Windows.Forms.Label();
            this.lbl_elapsedTimeInfo = new System.Windows.Forms.Label();
            this.lbl_remainingTime = new System.Windows.Forms.Label();
            this.lbl_remainingTimeInfo = new System.Windows.Forms.Label();
            this.prBar_dimensionProgress = new Luminescence.DesktopUI.WinForm.Code.ColorfulProgressBar();
            this.lbl_statusComplete = new System.Windows.Forms.Label();
            this.gb_controlPanel = new System.Windows.Forms.GroupBox();
            this.btn_saveDim = new System.Windows.Forms.Button();
            this.btn_pauseDimensions = new System.Windows.Forms.Button();
            this.btn_startDimensions = new System.Windows.Forms.Button();
            this.chart_dimensions = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gb_currentValues = new System.Windows.Forms.GroupBox();
            this.gb_stepMotor2 = new System.Windows.Forms.GroupBox();
            this.tb_sm2GoTo = new System.Windows.Forms.TextBox();
            this.btn_sm2Decr = new System.Windows.Forms.Button();
            this.btn_sm2Set = new System.Windows.Forms.Button();
            this.lbl_stepMotor2Wavelength = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_sm2CurrentWavelength = new System.Windows.Forms.TextBox();
            this.btn_sm2Incr = new System.Windows.Forms.Button();
            this.btn_sm2Go = new System.Windows.Forms.Button();
            this.gb_setSM = new System.Windows.Forms.GroupBox();
            this.rb_activeStepMotor2 = new System.Windows.Forms.RadioButton();
            this.rb_activeStepMotor1 = new System.Windows.Forms.RadioButton();
            this.gb_dimSettings = new System.Windows.Forms.GroupBox();
            this.tb_dimStopAt = new System.Windows.Forms.TextBox();
            this.tb_dimStep = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_dimApply = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nm_dimTime = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_currentStatus = new System.Windows.Forms.GroupBox();
            this.lbl_channelB = new System.Windows.Forms.Label();
            this.lbl_ChannelAInfo = new System.Windows.Forms.Label();
            this.lbl_currentWavelengthInfo = new System.Windows.Forms.Label();
            this.lbl_currentWavelength = new System.Windows.Forms.Label();
            this.lbl_channelA = new System.Windows.Forms.Label();
            this.lbl_ChannelBInfo = new System.Windows.Forms.Label();
            this.gb_stepMotor1 = new System.Windows.Forms.GroupBox();
            this.tb_sm1GoTo = new System.Windows.Forms.TextBox();
            this.btn_sm1Decr = new System.Windows.Forms.Button();
            this.btn_sm1Set = new System.Windows.Forms.Button();
            this.lbl_stepMotor1Wavelength = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_sm1CurrentWavelength = new System.Windows.Forms.TextBox();
            this.btn_sm1Incr = new System.Windows.Forms.Button();
            this.btn_sm1Go = new System.Windows.Forms.Button();
            this.pb_connectionStatus = new System.Windows.Forms.PictureBox();
            this.sfd_saveDim = new System.Windows.Forms.SaveFileDialog();
            this.dadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edhjkhjkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.gb_mainForm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb_proccessInformation.SuspendLayout();
            this.gb_controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_dimensions)).BeginInit();
            this.gb_currentValues.SuspendLayout();
            this.gb_stepMotor2.SuspendLayout();
            this.gb_setSM.SuspendLayout();
            this.gb_dimSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_dimTime)).BeginInit();
            this.gb_currentStatus.SuspendLayout();
            this.gb_stepMotor1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_connectionStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Dock = System.Windows.Forms.DockStyle.None;
            this.menu.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(12, 1);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(409, 47);
            this.menu.TabIndex = 8;
            this.menu.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepMotorToolStripMenuItem});
            this.settingsToolStripMenuItem.Image = global::Luminescence.DesktopUI.WinForm.Properties.Resources.menu_settings;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(130, 43);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // stepMotorToolStripMenuItem
            // 
            this.stepMotorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calibrationToolStripMenuItem,
            this.dadToolStripMenuItem});
            this.stepMotorToolStripMenuItem.Name = "stepMotorToolStripMenuItem";
            this.stepMotorToolStripMenuItem.Size = new System.Drawing.Size(196, 28);
            this.stepMotorToolStripMenuItem.Text = "Step motor";
            // 
            // calibrationToolStripMenuItem
            // 
            this.calibrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edhjkhjkToolStripMenuItem});
            this.calibrationToolStripMenuItem.Name = "calibrationToolStripMenuItem";
            this.calibrationToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.calibrationToolStripMenuItem.Text = "Calibration";
            this.calibrationToolStripMenuItem.Click += new System.EventHandler(this.calibrationToolStripMenuItem_Click);
            // 
            // lbl_connectionStatus
            // 
            this.lbl_connectionStatus.BackColor = System.Drawing.Color.Red;
            this.lbl_connectionStatus.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_connectionStatus.Location = new System.Drawing.Point(941, 9);
            this.lbl_connectionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_connectionStatus.Name = "lbl_connectionStatus";
            this.lbl_connectionStatus.Size = new System.Drawing.Size(289, 31);
            this.lbl_connectionStatus.TabIndex = 10;
            this.lbl_connectionStatus.Text = "disconnected";
            this.lbl_connectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_mainForm
            // 
            this.gb_mainForm.Controls.Add(this.groupBox1);
            this.gb_mainForm.Controls.Add(this.gb_proccessInformation);
            this.gb_mainForm.Controls.Add(this.prBar_dimensionProgress);
            this.gb_mainForm.Controls.Add(this.lbl_statusComplete);
            this.gb_mainForm.Controls.Add(this.gb_controlPanel);
            this.gb_mainForm.Controls.Add(this.chart_dimensions);
            this.gb_mainForm.Controls.Add(this.gb_currentValues);
            this.gb_mainForm.Location = new System.Drawing.Point(1, 39);
            this.gb_mainForm.Margin = new System.Windows.Forms.Padding(4);
            this.gb_mainForm.Name = "gb_mainForm";
            this.gb_mainForm.Padding = new System.Windows.Forms.Padding(4);
            this.gb_mainForm.Size = new System.Drawing.Size(1249, 695);
            this.gb_mainForm.TabIndex = 11;
            this.gb_mainForm.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_fileName);
            this.groupBox1.Location = new System.Drawing.Point(476, 493);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 49);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "file name";
            // 
            // tb_fileName
            // 
            this.tb_fileName.Location = new System.Drawing.Point(88, 21);
            this.tb_fileName.Name = "tb_fileName";
            this.tb_fileName.Size = new System.Drawing.Size(351, 22);
            this.tb_fileName.TabIndex = 0;
            // 
            // gb_proccessInformation
            // 
            this.gb_proccessInformation.Controls.Add(this.lbl_elapsedTime);
            this.gb_proccessInformation.Controls.Add(this.lbl_elapsedTimeInfo);
            this.gb_proccessInformation.Controls.Add(this.lbl_remainingTime);
            this.gb_proccessInformation.Controls.Add(this.lbl_remainingTimeInfo);
            this.gb_proccessInformation.Location = new System.Drawing.Point(965, 505);
            this.gb_proccessInformation.Margin = new System.Windows.Forms.Padding(4);
            this.gb_proccessInformation.Name = "gb_proccessInformation";
            this.gb_proccessInformation.Padding = new System.Windows.Forms.Padding(4);
            this.gb_proccessInformation.Size = new System.Drawing.Size(264, 152);
            this.gb_proccessInformation.TabIndex = 8;
            this.gb_proccessInformation.TabStop = false;
            this.gb_proccessInformation.Text = "proccess information";
            // 
            // lbl_elapsedTime
            // 
            this.lbl_elapsedTime.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_elapsedTime.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_elapsedTime.Location = new System.Drawing.Point(27, 59);
            this.lbl_elapsedTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_elapsedTime.Name = "lbl_elapsedTime";
            this.lbl_elapsedTime.Size = new System.Drawing.Size(237, 23);
            this.lbl_elapsedTime.TabIndex = 5;
            this.lbl_elapsedTime.Text = "14 h";
            this.lbl_elapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_elapsedTimeInfo
            // 
            this.lbl_elapsedTimeInfo.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_elapsedTimeInfo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_elapsedTimeInfo.Location = new System.Drawing.Point(17, 33);
            this.lbl_elapsedTimeInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_elapsedTimeInfo.Name = "lbl_elapsedTimeInfo";
            this.lbl_elapsedTimeInfo.Size = new System.Drawing.Size(247, 23);
            this.lbl_elapsedTimeInfo.TabIndex = 4;
            this.lbl_elapsedTimeInfo.Text = "elapsed time";
            this.lbl_elapsedTimeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_remainingTime
            // 
            this.lbl_remainingTime.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_remainingTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_remainingTime.Location = new System.Drawing.Point(31, 125);
            this.lbl_remainingTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_remainingTime.Name = "lbl_remainingTime";
            this.lbl_remainingTime.Size = new System.Drawing.Size(233, 23);
            this.lbl_remainingTime.TabIndex = 3;
            this.lbl_remainingTime.Text = "14 h";
            this.lbl_remainingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_remainingTime.Click += new System.EventHandler(this.lbl_remainingTime_Click);
            // 
            // lbl_remainingTimeInfo
            // 
            this.lbl_remainingTimeInfo.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_remainingTimeInfo.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_remainingTimeInfo.Location = new System.Drawing.Point(27, 99);
            this.lbl_remainingTimeInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_remainingTimeInfo.Name = "lbl_remainingTimeInfo";
            this.lbl_remainingTimeInfo.Size = new System.Drawing.Size(237, 23);
            this.lbl_remainingTimeInfo.TabIndex = 1;
            this.lbl_remainingTimeInfo.Text = "remaining time";
            this.lbl_remainingTimeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prBar_dimensionProgress
            // 
            this.prBar_dimensionProgress.Location = new System.Drawing.Point(468, 665);
            this.prBar_dimensionProgress.Margin = new System.Windows.Forms.Padding(4);
            this.prBar_dimensionProgress.Name = "prBar_dimensionProgress";
            this.prBar_dimensionProgress.Size = new System.Drawing.Size(761, 20);
            this.prBar_dimensionProgress.TabIndex = 11;
            // 
            // lbl_statusComplete
            // 
            this.lbl_statusComplete.AutoSize = true;
            this.lbl_statusComplete.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_statusComplete.Location = new System.Drawing.Point(15, 662);
            this.lbl_statusComplete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_statusComplete.Name = "lbl_statusComplete";
            this.lbl_statusComplete.Size = new System.Drawing.Size(160, 22);
            this.lbl_statusComplete.TabIndex = 10;
            this.lbl_statusComplete.Text = "status complete";
            this.lbl_statusComplete.Visible = false;
            // 
            // gb_controlPanel
            // 
            this.gb_controlPanel.Controls.Add(this.btn_saveDim);
            this.gb_controlPanel.Controls.Add(this.btn_pauseDimensions);
            this.gb_controlPanel.Controls.Add(this.btn_startDimensions);
            this.gb_controlPanel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_controlPanel.Location = new System.Drawing.Point(468, 550);
            this.gb_controlPanel.Margin = new System.Windows.Forms.Padding(4);
            this.gb_controlPanel.Name = "gb_controlPanel";
            this.gb_controlPanel.Padding = new System.Windows.Forms.Padding(4);
            this.gb_controlPanel.Size = new System.Drawing.Size(761, 107);
            this.gb_controlPanel.TabIndex = 7;
            this.gb_controlPanel.TabStop = false;
            this.gb_controlPanel.Text = "control panel";
            // 
            // btn_saveDim
            // 
            this.btn_saveDim.BackgroundImage = global::Luminescence.DesktopUI.WinForm.Properties.Resources.save_button;
            this.btn_saveDim.Location = new System.Drawing.Point(329, 43);
            this.btn_saveDim.Margin = new System.Windows.Forms.Padding(4);
            this.btn_saveDim.Name = "btn_saveDim";
            this.btn_saveDim.Size = new System.Drawing.Size(160, 39);
            this.btn_saveDim.TabIndex = 9;
            this.btn_saveDim.UseVisualStyleBackColor = true;
            this.btn_saveDim.Visible = false;
            this.btn_saveDim.Click += new System.EventHandler(this.btn_saveDim_Click);
            // 
            // btn_pauseDimensions
            // 
            this.btn_pauseDimensions.Enabled = false;
            this.btn_pauseDimensions.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_pauseDimensions.Location = new System.Drawing.Point(193, 37);
            this.btn_pauseDimensions.Margin = new System.Windows.Forms.Padding(4);
            this.btn_pauseDimensions.Name = "btn_pauseDimensions";
            this.btn_pauseDimensions.Size = new System.Drawing.Size(128, 54);
            this.btn_pauseDimensions.TabIndex = 1;
            this.btn_pauseDimensions.Text = "pause \r\nproccess";
            this.btn_pauseDimensions.UseVisualStyleBackColor = true;
            this.btn_pauseDimensions.Click += new System.EventHandler(this.btn_pauseDimensions_Click);
            // 
            // btn_startDimensions
            // 
            this.btn_startDimensions.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_startDimensions.Location = new System.Drawing.Point(8, 37);
            this.btn_startDimensions.Margin = new System.Windows.Forms.Padding(4);
            this.btn_startDimensions.Name = "btn_startDimensions";
            this.btn_startDimensions.Size = new System.Drawing.Size(129, 54);
            this.btn_startDimensions.TabIndex = 0;
            this.btn_startDimensions.Text = "start \r\nproccess";
            this.btn_startDimensions.UseVisualStyleBackColor = true;
            this.btn_startDimensions.Click += new System.EventHandler(this.btn_startDimensions_Click);
            // 
            // chart_dimensions
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.Title = "time, sec";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX2.IsInterlaced = true;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Red;
            chartArea1.AxisX2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            stripLine1.ForeColor = System.Drawing.Color.LimeGreen;
            chartArea1.AxisY.StripLines.Add(stripLine1);
            chartArea1.AxisY.Title = "count input impulses";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.CursorX.LineColor = System.Drawing.Color.Black;
            chartArea1.Name = "area";
            this.chart_dimensions.ChartAreas.Add(chartArea1);
            this.chart_dimensions.Location = new System.Drawing.Point(468, 23);
            this.chart_dimensions.Margin = new System.Windows.Forms.Padding(4);
            this.chart_dimensions.Name = "chart_dimensions";
            this.chart_dimensions.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BackSecondaryColor = System.Drawing.Color.White;
            series1.BorderWidth = 2;
            series1.ChartArea = "area";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.MarkerBorderColor = System.Drawing.Color.Crimson;
            series1.MarkerBorderWidth = 5;
            series1.MarkerColor = System.Drawing.Color.Red;
            series1.MarkerSize = 2;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "channelA";
            series2.BorderWidth = 2;
            series2.ChartArea = "area";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.RoyalBlue;
            series2.MarkerBorderColor = System.Drawing.Color.MediumBlue;
            series2.MarkerBorderWidth = 3;
            series2.MarkerSize = 3;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "channelB";
            this.chart_dimensions.Series.Add(series1);
            this.chart_dimensions.Series.Add(series2);
            this.chart_dimensions.Size = new System.Drawing.Size(761, 519);
            this.chart_dimensions.TabIndex = 1;
            this.chart_dimensions.Text = "chart1";
            // 
            // gb_currentValues
            // 
            this.gb_currentValues.Controls.Add(this.gb_stepMotor2);
            this.gb_currentValues.Controls.Add(this.gb_setSM);
            this.gb_currentValues.Controls.Add(this.gb_dimSettings);
            this.gb_currentValues.Controls.Add(this.gb_currentStatus);
            this.gb_currentValues.Controls.Add(this.gb_stepMotor1);
            this.gb_currentValues.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_currentValues.Location = new System.Drawing.Point(8, 23);
            this.gb_currentValues.Margin = new System.Windows.Forms.Padding(4);
            this.gb_currentValues.Name = "gb_currentValues";
            this.gb_currentValues.Padding = new System.Windows.Forms.Padding(4);
            this.gb_currentValues.Size = new System.Drawing.Size(452, 634);
            this.gb_currentValues.TabIndex = 0;
            this.gb_currentValues.TabStop = false;
            this.gb_currentValues.Text = "setted values";
            // 
            // gb_stepMotor2
            // 
            this.gb_stepMotor2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gb_stepMotor2.Controls.Add(this.tb_sm2GoTo);
            this.gb_stepMotor2.Controls.Add(this.btn_sm2Decr);
            this.gb_stepMotor2.Controls.Add(this.btn_sm2Set);
            this.gb_stepMotor2.Controls.Add(this.lbl_stepMotor2Wavelength);
            this.gb_stepMotor2.Controls.Add(this.label4);
            this.gb_stepMotor2.Controls.Add(this.tb_sm2CurrentWavelength);
            this.gb_stepMotor2.Controls.Add(this.btn_sm2Incr);
            this.gb_stepMotor2.Controls.Add(this.btn_sm2Go);
            this.gb_stepMotor2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_stepMotor2.Location = new System.Drawing.Point(45, 160);
            this.gb_stepMotor2.Margin = new System.Windows.Forms.Padding(4);
            this.gb_stepMotor2.Name = "gb_stepMotor2";
            this.gb_stepMotor2.Padding = new System.Windows.Forms.Padding(4);
            this.gb_stepMotor2.Size = new System.Drawing.Size(384, 126);
            this.gb_stepMotor2.TabIndex = 12;
            this.gb_stepMotor2.TabStop = false;
            this.gb_stepMotor2.Text = "step motor 2";
            // 
            // tb_sm2GoTo
            // 
            this.tb_sm2GoTo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_sm2GoTo.Location = new System.Drawing.Point(111, 32);
            this.tb_sm2GoTo.Margin = new System.Windows.Forms.Padding(4);
            this.tb_sm2GoTo.Name = "tb_sm2GoTo";
            this.tb_sm2GoTo.Size = new System.Drawing.Size(80, 31);
            this.tb_sm2GoTo.TabIndex = 10;
            this.tb_sm2GoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_sm2GoTo.TextChanged += new System.EventHandler(this.tb_sm2GoTo_TextChanged);
            // 
            // btn_sm2Decr
            // 
            this.btn_sm2Decr.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sm2Decr.Location = new System.Drawing.Point(208, 75);
            this.btn_sm2Decr.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sm2Decr.Name = "btn_sm2Decr";
            this.btn_sm2Decr.Size = new System.Drawing.Size(64, 37);
            this.btn_sm2Decr.TabIndex = 9;
            this.btn_sm2Decr.Text = "-1";
            this.btn_sm2Decr.UseVisualStyleBackColor = true;
            this.btn_sm2Decr.Click += new System.EventHandler(this.btn_sm2Decr_Click);
            // 
            // btn_sm2Set
            // 
            this.btn_sm2Set.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sm2Set.Location = new System.Drawing.Point(19, 78);
            this.btn_sm2Set.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sm2Set.Name = "btn_sm2Set";
            this.btn_sm2Set.Size = new System.Drawing.Size(81, 33);
            this.btn_sm2Set.TabIndex = 8;
            this.btn_sm2Set.Text = "Set";
            this.btn_sm2Set.UseVisualStyleBackColor = true;
            this.btn_sm2Set.Click += new System.EventHandler(this.btn_sm2Set_Click);
            // 
            // lbl_stepMotor2Wavelength
            // 
            this.lbl_stepMotor2Wavelength.AutoSize = true;
            this.lbl_stepMotor2Wavelength.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_stepMotor2Wavelength.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_stepMotor2Wavelength.Location = new System.Drawing.Point(283, 75);
            this.lbl_stepMotor2Wavelength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_stepMotor2Wavelength.Name = "lbl_stepMotor2Wavelength";
            this.lbl_stepMotor2Wavelength.Size = new System.Drawing.Size(90, 32);
            this.lbl_stepMotor2Wavelength.TabIndex = 7;
            this.lbl_stepMotor2Wavelength.Text = "125.7";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(280, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 40);
            this.label4.TabIndex = 6;
            this.label4.Text = "current\r\nwavelength";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_sm2CurrentWavelength
            // 
            this.tb_sm2CurrentWavelength.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_sm2CurrentWavelength.Location = new System.Drawing.Point(19, 32);
            this.tb_sm2CurrentWavelength.Margin = new System.Windows.Forms.Padding(4);
            this.tb_sm2CurrentWavelength.Name = "tb_sm2CurrentWavelength";
            this.tb_sm2CurrentWavelength.Size = new System.Drawing.Size(80, 31);
            this.tb_sm2CurrentWavelength.TabIndex = 4;
            this.tb_sm2CurrentWavelength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_sm2CurrentWavelength.TextChanged += new System.EventHandler(this.tb_sm2CurrentWavelength_TextChanged);
            // 
            // btn_sm2Incr
            // 
            this.btn_sm2Incr.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sm2Incr.Location = new System.Drawing.Point(208, 26);
            this.btn_sm2Incr.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sm2Incr.Name = "btn_sm2Incr";
            this.btn_sm2Incr.Size = new System.Drawing.Size(64, 37);
            this.btn_sm2Incr.TabIndex = 2;
            this.btn_sm2Incr.Text = "+1";
            this.btn_sm2Incr.UseVisualStyleBackColor = true;
            this.btn_sm2Incr.Click += new System.EventHandler(this.btn_sm2Incr_Click);
            // 
            // btn_sm2Go
            // 
            this.btn_sm2Go.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sm2Go.Location = new System.Drawing.Point(108, 78);
            this.btn_sm2Go.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sm2Go.Name = "btn_sm2Go";
            this.btn_sm2Go.Size = new System.Drawing.Size(84, 33);
            this.btn_sm2Go.TabIndex = 1;
            this.btn_sm2Go.Text = "Go";
            this.btn_sm2Go.UseVisualStyleBackColor = true;
            this.btn_sm2Go.Click += new System.EventHandler(this.btn_sm2Go_Click);
            // 
            // gb_setSM
            // 
            this.gb_setSM.BackColor = System.Drawing.Color.Moccasin;
            this.gb_setSM.Controls.Add(this.rb_activeStepMotor2);
            this.gb_setSM.Controls.Add(this.rb_activeStepMotor1);
            this.gb_setSM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb_setSM.Location = new System.Drawing.Point(8, 34);
            this.gb_setSM.Margin = new System.Windows.Forms.Padding(4);
            this.gb_setSM.Name = "gb_setSM";
            this.gb_setSM.Padding = new System.Windows.Forms.Padding(4);
            this.gb_setSM.Size = new System.Drawing.Size(37, 251);
            this.gb_setSM.TabIndex = 11;
            this.gb_setSM.TabStop = false;
            // 
            // rb_activeStepMotor2
            // 
            this.rb_activeStepMotor2.AutoSize = true;
            this.rb_activeStepMotor2.Location = new System.Drawing.Point(11, 174);
            this.rb_activeStepMotor2.Margin = new System.Windows.Forms.Padding(4);
            this.rb_activeStepMotor2.Name = "rb_activeStepMotor2";
            this.rb_activeStepMotor2.Size = new System.Drawing.Size(17, 16);
            this.rb_activeStepMotor2.TabIndex = 1;
            this.rb_activeStepMotor2.TabStop = true;
            this.rb_activeStepMotor2.UseVisualStyleBackColor = true;
            this.rb_activeStepMotor2.CheckedChanged += new System.EventHandler(this.rb_activeStepMotor2_CheckedChanged);
            // 
            // rb_activeStepMotor1
            // 
            this.rb_activeStepMotor1.AutoSize = true;
            this.rb_activeStepMotor1.Checked = true;
            this.rb_activeStepMotor1.Location = new System.Drawing.Point(11, 60);
            this.rb_activeStepMotor1.Margin = new System.Windows.Forms.Padding(4);
            this.rb_activeStepMotor1.Name = "rb_activeStepMotor1";
            this.rb_activeStepMotor1.Size = new System.Drawing.Size(17, 16);
            this.rb_activeStepMotor1.TabIndex = 0;
            this.rb_activeStepMotor1.TabStop = true;
            this.rb_activeStepMotor1.UseVisualStyleBackColor = true;
            this.rb_activeStepMotor1.CheckedChanged += new System.EventHandler(this.rb_activeStepMotor1_CheckedChanged);
            // 
            // gb_dimSettings
            // 
            this.gb_dimSettings.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gb_dimSettings.Controls.Add(this.tb_dimStopAt);
            this.gb_dimSettings.Controls.Add(this.tb_dimStep);
            this.gb_dimSettings.Controls.Add(this.label9);
            this.gb_dimSettings.Controls.Add(this.label10);
            this.gb_dimSettings.Controls.Add(this.btn_dimApply);
            this.gb_dimSettings.Controls.Add(this.label8);
            this.gb_dimSettings.Controls.Add(this.nm_dimTime);
            this.gb_dimSettings.Controls.Add(this.label7);
            this.gb_dimSettings.Controls.Add(this.label6);
            this.gb_dimSettings.Controls.Add(this.label5);
            this.gb_dimSettings.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_dimSettings.Location = new System.Drawing.Point(8, 305);
            this.gb_dimSettings.Margin = new System.Windows.Forms.Padding(4);
            this.gb_dimSettings.Name = "gb_dimSettings";
            this.gb_dimSettings.Padding = new System.Windows.Forms.Padding(4);
            this.gb_dimSettings.Size = new System.Drawing.Size(427, 129);
            this.gb_dimSettings.TabIndex = 11;
            this.gb_dimSettings.TabStop = false;
            this.gb_dimSettings.Text = "settings";
            // 
            // tb_dimStopAt
            // 
            this.tb_dimStopAt.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_dimStopAt.Location = new System.Drawing.Point(117, 86);
            this.tb_dimStopAt.Margin = new System.Windows.Forms.Padding(4);
            this.tb_dimStopAt.Name = "tb_dimStopAt";
            this.tb_dimStopAt.Size = new System.Drawing.Size(80, 31);
            this.tb_dimStopAt.TabIndex = 18;
            this.tb_dimStopAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_dimStopAt.TextChanged += new System.EventHandler(this.tb_dimStopAt_TextChanged);
            // 
            // tb_dimStep
            // 
            this.tb_dimStep.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_dimStep.Location = new System.Drawing.Point(76, 30);
            this.tb_dimStep.Margin = new System.Windows.Forms.Padding(4);
            this.tb_dimStep.Name = "tb_dimStep";
            this.tb_dimStep.Size = new System.Drawing.Size(80, 31);
            this.tb_dimStep.TabIndex = 17;
            this.tb_dimStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_dimStep.TextChanged += new System.EventHandler(this.tb_dimStep_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(212, 90);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "nm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 90);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 23);
            this.label10.TabIndex = 15;
            this.label10.Text = "Stop at";
            // 
            // btn_dimApply
            // 
            this.btn_dimApply.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_dimApply.Location = new System.Drawing.Point(280, 82);
            this.btn_dimApply.Margin = new System.Windows.Forms.Padding(4);
            this.btn_dimApply.Name = "btn_dimApply";
            this.btn_dimApply.Size = new System.Drawing.Size(128, 38);
            this.btn_dimApply.TabIndex = 8;
            this.btn_dimApply.Text = "apply";
            this.btn_dimApply.UseVisualStyleBackColor = true;
            this.btn_dimApply.Click += new System.EventHandler(this.btn_dimApply_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(364, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "sec";
            // 
            // nm_dimTime
            // 
            this.nm_dimTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.nm_dimTime.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nm_dimTime.Location = new System.Drawing.Point(280, 31);
            this.nm_dimTime.Margin = new System.Windows.Forms.Padding(4);
            this.nm_dimTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_dimTime.Name = "nm_dimTime";
            this.nm_dimTime.ReadOnly = true;
            this.nm_dimTime.Size = new System.Drawing.Size(81, 31);
            this.nm_dimTime.TabIndex = 12;
            this.nm_dimTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_dimTime.ValueChanged += new System.EventHandler(this.nm_dimTime_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 33);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "nm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Step";
            // 
            // gb_currentStatus
            // 
            this.gb_currentStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gb_currentStatus.Controls.Add(this.lbl_channelB);
            this.gb_currentStatus.Controls.Add(this.lbl_ChannelAInfo);
            this.gb_currentStatus.Controls.Add(this.lbl_currentWavelengthInfo);
            this.gb_currentStatus.Controls.Add(this.lbl_currentWavelength);
            this.gb_currentStatus.Controls.Add(this.lbl_channelA);
            this.gb_currentStatus.Controls.Add(this.lbl_ChannelBInfo);
            this.gb_currentStatus.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_currentStatus.Location = new System.Drawing.Point(8, 479);
            this.gb_currentStatus.Margin = new System.Windows.Forms.Padding(4);
            this.gb_currentStatus.Name = "gb_currentStatus";
            this.gb_currentStatus.Padding = new System.Windows.Forms.Padding(4);
            this.gb_currentStatus.Size = new System.Drawing.Size(427, 132);
            this.gb_currentStatus.TabIndex = 10;
            this.gb_currentStatus.TabStop = false;
            this.gb_currentStatus.Text = "current status";
            // 
            // lbl_channelB
            // 
            this.lbl_channelB.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_channelB.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_channelB.Location = new System.Drawing.Point(209, 59);
            this.lbl_channelB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_channelB.Name = "lbl_channelB";
            this.lbl_channelB.Size = new System.Drawing.Size(133, 28);
            this.lbl_channelB.TabIndex = 9;
            this.lbl_channelB.Text = "--";
            this.lbl_channelB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ChannelAInfo
            // 
            this.lbl_ChannelAInfo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_ChannelAInfo.ForeColor = System.Drawing.Color.Red;
            this.lbl_ChannelAInfo.Location = new System.Drawing.Point(35, 31);
            this.lbl_ChannelAInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ChannelAInfo.Name = "lbl_ChannelAInfo";
            this.lbl_ChannelAInfo.Size = new System.Drawing.Size(133, 28);
            this.lbl_ChannelAInfo.TabIndex = 3;
            this.lbl_ChannelAInfo.Text = "Channel A ";
            this.lbl_ChannelAInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_currentWavelengthInfo
            // 
            this.lbl_currentWavelengthInfo.AutoSize = true;
            this.lbl_currentWavelengthInfo.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_currentWavelengthInfo.Location = new System.Drawing.Point(68, 101);
            this.lbl_currentWavelengthInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_currentWavelengthInfo.Name = "lbl_currentWavelengthInfo";
            this.lbl_currentWavelengthInfo.Size = new System.Drawing.Size(210, 22);
            this.lbl_currentWavelengthInfo.TabIndex = 6;
            this.lbl_currentWavelengthInfo.Text = "current wavelength: ";
            // 
            // lbl_currentWavelength
            // 
            this.lbl_currentWavelength.AutoSize = true;
            this.lbl_currentWavelength.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_currentWavelength.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_currentWavelength.Location = new System.Drawing.Point(300, 96);
            this.lbl_currentWavelength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_currentWavelength.Name = "lbl_currentWavelength";
            this.lbl_currentWavelength.Size = new System.Drawing.Size(90, 32);
            this.lbl_currentWavelength.TabIndex = 5;
            this.lbl_currentWavelength.Text = "125.7";
            // 
            // lbl_channelA
            // 
            this.lbl_channelA.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_channelA.ForeColor = System.Drawing.Color.Red;
            this.lbl_channelA.Location = new System.Drawing.Point(35, 59);
            this.lbl_channelA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_channelA.Name = "lbl_channelA";
            this.lbl_channelA.Size = new System.Drawing.Size(133, 28);
            this.lbl_channelA.TabIndex = 8;
            this.lbl_channelA.Text = "--";
            this.lbl_channelA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ChannelBInfo
            // 
            this.lbl_ChannelBInfo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_ChannelBInfo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_ChannelBInfo.Location = new System.Drawing.Point(203, 31);
            this.lbl_ChannelBInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ChannelBInfo.Name = "lbl_ChannelBInfo";
            this.lbl_ChannelBInfo.Size = new System.Drawing.Size(133, 28);
            this.lbl_ChannelBInfo.TabIndex = 4;
            this.lbl_ChannelBInfo.Text = "Channel B";
            this.lbl_ChannelBInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_stepMotor1
            // 
            this.gb_stepMotor1.BackColor = System.Drawing.Color.Moccasin;
            this.gb_stepMotor1.Controls.Add(this.tb_sm1GoTo);
            this.gb_stepMotor1.Controls.Add(this.btn_sm1Decr);
            this.gb_stepMotor1.Controls.Add(this.btn_sm1Set);
            this.gb_stepMotor1.Controls.Add(this.lbl_stepMotor1Wavelength);
            this.gb_stepMotor1.Controls.Add(this.label1);
            this.gb_stepMotor1.Controls.Add(this.tb_sm1CurrentWavelength);
            this.gb_stepMotor1.Controls.Add(this.btn_sm1Incr);
            this.gb_stepMotor1.Controls.Add(this.btn_sm1Go);
            this.gb_stepMotor1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_stepMotor1.Location = new System.Drawing.Point(45, 34);
            this.gb_stepMotor1.Margin = new System.Windows.Forms.Padding(4);
            this.gb_stepMotor1.Name = "gb_stepMotor1";
            this.gb_stepMotor1.Padding = new System.Windows.Forms.Padding(4);
            this.gb_stepMotor1.Size = new System.Drawing.Size(384, 126);
            this.gb_stepMotor1.TabIndex = 0;
            this.gb_stepMotor1.TabStop = false;
            this.gb_stepMotor1.Text = "step motor 1";
            // 
            // tb_sm1GoTo
            // 
            this.tb_sm1GoTo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_sm1GoTo.Location = new System.Drawing.Point(111, 32);
            this.tb_sm1GoTo.Margin = new System.Windows.Forms.Padding(4);
            this.tb_sm1GoTo.Name = "tb_sm1GoTo";
            this.tb_sm1GoTo.Size = new System.Drawing.Size(80, 31);
            this.tb_sm1GoTo.TabIndex = 10;
            this.tb_sm1GoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_sm1GoTo.TextChanged += new System.EventHandler(this.tb_sm1GoTo_TextChanged);
            // 
            // btn_sm1Decr
            // 
            this.btn_sm1Decr.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sm1Decr.Location = new System.Drawing.Point(208, 75);
            this.btn_sm1Decr.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sm1Decr.Name = "btn_sm1Decr";
            this.btn_sm1Decr.Size = new System.Drawing.Size(64, 37);
            this.btn_sm1Decr.TabIndex = 9;
            this.btn_sm1Decr.Text = "-1";
            this.btn_sm1Decr.UseVisualStyleBackColor = true;
            this.btn_sm1Decr.Click += new System.EventHandler(this.btn_sm1Decr_Click);
            // 
            // btn_sm1Set
            // 
            this.btn_sm1Set.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sm1Set.Location = new System.Drawing.Point(19, 78);
            this.btn_sm1Set.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sm1Set.Name = "btn_sm1Set";
            this.btn_sm1Set.Size = new System.Drawing.Size(81, 33);
            this.btn_sm1Set.TabIndex = 8;
            this.btn_sm1Set.Text = "Set";
            this.btn_sm1Set.UseVisualStyleBackColor = true;
            this.btn_sm1Set.Click += new System.EventHandler(this.btn_sm1Set_Click);
            // 
            // lbl_stepMotor1Wavelength
            // 
            this.lbl_stepMotor1Wavelength.AutoSize = true;
            this.lbl_stepMotor1Wavelength.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_stepMotor1Wavelength.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_stepMotor1Wavelength.Location = new System.Drawing.Point(283, 75);
            this.lbl_stepMotor1Wavelength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_stepMotor1Wavelength.Name = "lbl_stepMotor1Wavelength";
            this.lbl_stepMotor1Wavelength.Size = new System.Drawing.Size(90, 32);
            this.lbl_stepMotor1Wavelength.TabIndex = 7;
            this.lbl_stepMotor1Wavelength.Text = "125.7";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(280, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "current\r\nwavelength";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_sm1CurrentWavelength
            // 
            this.tb_sm1CurrentWavelength.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_sm1CurrentWavelength.Location = new System.Drawing.Point(19, 32);
            this.tb_sm1CurrentWavelength.Margin = new System.Windows.Forms.Padding(4);
            this.tb_sm1CurrentWavelength.Name = "tb_sm1CurrentWavelength";
            this.tb_sm1CurrentWavelength.Size = new System.Drawing.Size(80, 31);
            this.tb_sm1CurrentWavelength.TabIndex = 4;
            this.tb_sm1CurrentWavelength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_sm1CurrentWavelength.TextChanged += new System.EventHandler(this.tb_sm1CurrentWavelength_TextChanged);
            // 
            // btn_sm1Incr
            // 
            this.btn_sm1Incr.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sm1Incr.Location = new System.Drawing.Point(208, 26);
            this.btn_sm1Incr.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sm1Incr.Name = "btn_sm1Incr";
            this.btn_sm1Incr.Size = new System.Drawing.Size(64, 37);
            this.btn_sm1Incr.TabIndex = 2;
            this.btn_sm1Incr.Text = "+1";
            this.btn_sm1Incr.UseVisualStyleBackColor = true;
            this.btn_sm1Incr.Click += new System.EventHandler(this.btn_sm1Incr_Click);
            // 
            // btn_sm1Go
            // 
            this.btn_sm1Go.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_sm1Go.Location = new System.Drawing.Point(108, 78);
            this.btn_sm1Go.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sm1Go.Name = "btn_sm1Go";
            this.btn_sm1Go.Size = new System.Drawing.Size(84, 33);
            this.btn_sm1Go.TabIndex = 1;
            this.btn_sm1Go.Text = "Go";
            this.btn_sm1Go.UseVisualStyleBackColor = true;
            this.btn_sm1Go.Click += new System.EventHandler(this.btn_sm1Go_Click);
            // 
            // pb_connectionStatus
            // 
            this.pb_connectionStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_connectionStatus.Image = global::Luminescence.DesktopUI.WinForm.Properties.Resources.usb_fail;
            this.pb_connectionStatus.Location = new System.Drawing.Point(870, 9);
            this.pb_connectionStatus.Margin = new System.Windows.Forms.Padding(4);
            this.pb_connectionStatus.Name = "pb_connectionStatus";
            this.pb_connectionStatus.Size = new System.Drawing.Size(71, 31);
            this.pb_connectionStatus.TabIndex = 9;
            this.pb_connectionStatus.TabStop = false;
            // 
            // sfd_saveDim
            // 
            this.sfd_saveDim.Filter = "*.txt|";
            // 
            // dadToolStripMenuItem
            // 
            this.dadToolStripMenuItem.Name = "dadToolStripMenuItem";
            this.dadToolStripMenuItem.Size = new System.Drawing.Size(207, 28);
            this.dadToolStripMenuItem.Text = "dad.";
            // 
            // edhjkhjkToolStripMenuItem
            // 
            this.edhjkhjkToolStripMenuItem.Name = "edhjkhjkToolStripMenuItem";
            this.edhjkhjkToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.edhjkhjkToolStripMenuItem.Text = "ed.hjkhjk";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1256, 738);
            this.Controls.Add(this.gb_mainForm);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.lbl_connectionStatus);
            this.Controls.Add(this.pb_connectionStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Luminescence";
            this.Load += new System.EventHandler(this.Luminescence_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.gb_mainForm.ResumeLayout(false);
            this.gb_mainForm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_proccessInformation.ResumeLayout(false);
            this.gb_controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_dimensions)).EndInit();
            this.gb_currentValues.ResumeLayout(false);
            this.gb_stepMotor2.ResumeLayout(false);
            this.gb_stepMotor2.PerformLayout();
            this.gb_setSM.ResumeLayout(false);
            this.gb_setSM.PerformLayout();
            this.gb_dimSettings.ResumeLayout(false);
            this.gb_dimSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_dimTime)).EndInit();
            this.gb_currentStatus.ResumeLayout(false);
            this.gb_currentStatus.PerformLayout();
            this.gb_stepMotor1.ResumeLayout(false);
            this.gb_stepMotor1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_connectionStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepMotorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibrationToolStripMenuItem;
        private System.Windows.Forms.Label lbl_connectionStatus;
        private System.Windows.Forms.PictureBox pb_connectionStatus;
        private System.Windows.Forms.GroupBox gb_mainForm;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_dimensions;
        private System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1;
        private System.Windows.Forms.GroupBox gb_currentValues;
        private System.Windows.Forms.Label lbl_ChannelAInfo;
        private System.Windows.Forms.GroupBox gb_controlPanel;
        private System.Windows.Forms.GroupBox gb_proccessInformation;
        private System.Windows.Forms.Label lbl_elapsedTime;
        private System.Windows.Forms.Label lbl_elapsedTimeInfo;
        private System.Windows.Forms.Label lbl_remainingTime;
        private System.Windows.Forms.Label lbl_remainingTimeInfo;
        private System.Windows.Forms.Button btn_pauseDimensions;
        private System.Windows.Forms.Button btn_startDimensions;
        private System.Windows.Forms.Label lbl_currentWavelengthInfo;
        private System.Windows.Forms.Label lbl_currentWavelength;
        private System.Windows.Forms.Label lbl_ChannelBInfo;
        private System.Windows.Forms.GroupBox gb_currentStatus;
        private System.Windows.Forms.Label lbl_channelB;
        private System.Windows.Forms.Label lbl_channelA;
        private System.Windows.Forms.Label lbl_statusComplete;
        private System.Windows.Forms.GroupBox gb_setSM;
        private System.Windows.Forms.RadioButton rb_activeStepMotor2;
        private System.Windows.Forms.RadioButton rb_activeStepMotor1;
        private System.Windows.Forms.GroupBox gb_dimSettings;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_dimApply;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nm_dimTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gb_stepMotor1;
        private System.Windows.Forms.Button btn_sm1Decr;
        private System.Windows.Forms.Button btn_sm1Set;
        private System.Windows.Forms.Label lbl_stepMotor1Wavelength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_sm1CurrentWavelength;
        private System.Windows.Forms.Button btn_sm1Incr;
        private System.Windows.Forms.Button btn_sm1Go;
        private System.Windows.Forms.GroupBox gb_stepMotor2;
        private System.Windows.Forms.TextBox tb_sm2GoTo;
        private System.Windows.Forms.Button btn_sm2Decr;
        private System.Windows.Forms.Button btn_sm2Set;
        private System.Windows.Forms.Label lbl_stepMotor2Wavelength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_sm2CurrentWavelength;
        private System.Windows.Forms.Button btn_sm2Incr;
        private System.Windows.Forms.Button btn_sm2Go;
        private System.Windows.Forms.TextBox tb_dimStopAt;
        private System.Windows.Forms.TextBox tb_dimStep;
        private System.Windows.Forms.TextBox tb_sm1GoTo;
        private System.Windows.Forms.Button btn_saveDim;
        private System.Windows.Forms.SaveFileDialog sfd_saveDim;
        private Code.ColorfulProgressBar prBar_dimensionProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_fileName;
        private System.Windows.Forms.ToolStripMenuItem edhjkhjkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dadToolStripMenuItem;
    }
}

