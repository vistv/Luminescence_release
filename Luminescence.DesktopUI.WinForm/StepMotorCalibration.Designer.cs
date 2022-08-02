namespace Luminescence.DesktopUI.WinForm
{
    partial class StepMotorCalibration
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
            this.btn_startCalibration = new System.Windows.Forms.Button();
            this.gb_theoreticalEndPosition = new System.Windows.Forms.GroupBox();
            this.btn_theoreticalEndPositionApply = new System.Windows.Forms.Button();
            this.tb_theoreticalEndPosition = new System.Windows.Forms.TextBox();
            this.gb_realEndPosition = new System.Windows.Forms.GroupBox();
            this.btn_realEndPositionApply = new System.Windows.Forms.Button();
            this.tb_realEndPosition = new System.Windows.Forms.TextBox();
            this.gb_currentWavelenght = new System.Windows.Forms.GroupBox();
            this.btn_currentWavelengthApply = new System.Windows.Forms.Button();
            this.tb_currentWavelength = new System.Windows.Forms.TextBox();
            this.gb_countNmPer1Step = new System.Windows.Forms.GroupBox();
            this.lbl_countNmPer1Step = new System.Windows.Forms.Label();
            this.gb_countStepPer1Nm = new System.Windows.Forms.GroupBox();
            this.btn_countStepsPer1NmApply = new System.Windows.Forms.Button();
            this.tb_countStepsPer1Nm = new System.Windows.Forms.TextBox();
            this.gb_delayMsPer1Step = new System.Windows.Forms.GroupBox();
            this.btn_delayMsPer1StepApply = new System.Windows.Forms.Button();
            this.tb_delayMsPer1StepApply = new System.Windows.Forms.TextBox();
            this.gb_theoreticalEndPosition.SuspendLayout();
            this.gb_realEndPosition.SuspendLayout();
            this.gb_currentWavelenght.SuspendLayout();
            this.gb_countNmPer1Step.SuspendLayout();
            this.gb_countStepPer1Nm.SuspendLayout();
            this.gb_delayMsPer1Step.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_startCalibration
            // 
            this.btn_startCalibration.BackColor = System.Drawing.Color.LightGreen;
            this.btn_startCalibration.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_startCalibration.Location = new System.Drawing.Point(33, 323);
            this.btn_startCalibration.Name = "btn_startCalibration";
            this.btn_startCalibration.Size = new System.Drawing.Size(511, 90);
            this.btn_startCalibration.TabIndex = 13;
            this.btn_startCalibration.Text = "start calibration";
            this.btn_startCalibration.UseVisualStyleBackColor = false;
            this.btn_startCalibration.Click += new System.EventHandler(this.btn_startCalibration_Click);
            // 
            // gb_theoreticalEndPosition
            // 
            this.gb_theoreticalEndPosition.BackColor = System.Drawing.Color.Snow;
            this.gb_theoreticalEndPosition.Controls.Add(this.btn_theoreticalEndPositionApply);
            this.gb_theoreticalEndPosition.Controls.Add(this.tb_theoreticalEndPosition);
            this.gb_theoreticalEndPosition.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_theoreticalEndPosition.Location = new System.Drawing.Point(285, 231);
            this.gb_theoreticalEndPosition.Name = "gb_theoreticalEndPosition";
            this.gb_theoreticalEndPosition.Size = new System.Drawing.Size(259, 72);
            this.gb_theoreticalEndPosition.TabIndex = 12;
            this.gb_theoreticalEndPosition.TabStop = false;
            this.gb_theoreticalEndPosition.Text = "theoretical end position (nm)";
            // 
            // btn_theoreticalEndPositionApply
            // 
            this.btn_theoreticalEndPositionApply.Location = new System.Drawing.Point(165, 35);
            this.btn_theoreticalEndPositionApply.Name = "btn_theoreticalEndPositionApply";
            this.btn_theoreticalEndPositionApply.Size = new System.Drawing.Size(87, 29);
            this.btn_theoreticalEndPositionApply.TabIndex = 3;
            this.btn_theoreticalEndPositionApply.Text = "apply";
            this.btn_theoreticalEndPositionApply.UseVisualStyleBackColor = true;
            this.btn_theoreticalEndPositionApply.Click += new System.EventHandler(this.btn_theoreticalEndPositionApply_Click);
            // 
            // tb_theoreticalEndPosition
            // 
            this.tb_theoreticalEndPosition.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_theoreticalEndPosition.Location = new System.Drawing.Point(36, 33);
            this.tb_theoreticalEndPosition.Name = "tb_theoreticalEndPosition";
            this.tb_theoreticalEndPosition.Size = new System.Drawing.Size(99, 30);
            this.tb_theoreticalEndPosition.TabIndex = 2;
            this.tb_theoreticalEndPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_theoreticalEndPosition.TextChanged += new System.EventHandler(this.tb_theoreticalEndPosition_TextChanged);
            // 
            // gb_realEndPosition
            // 
            this.gb_realEndPosition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gb_realEndPosition.Controls.Add(this.btn_realEndPositionApply);
            this.gb_realEndPosition.Controls.Add(this.tb_realEndPosition);
            this.gb_realEndPosition.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_realEndPosition.Location = new System.Drawing.Point(33, 231);
            this.gb_realEndPosition.Name = "gb_realEndPosition";
            this.gb_realEndPosition.Size = new System.Drawing.Size(226, 72);
            this.gb_realEndPosition.TabIndex = 11;
            this.gb_realEndPosition.TabStop = false;
            this.gb_realEndPosition.Text = "real end position (nm)";
            // 
            // btn_realEndPositionApply
            // 
            this.btn_realEndPositionApply.Enabled = false;
            this.btn_realEndPositionApply.Location = new System.Drawing.Point(128, 33);
            this.btn_realEndPositionApply.Name = "btn_realEndPositionApply";
            this.btn_realEndPositionApply.Size = new System.Drawing.Size(87, 31);
            this.btn_realEndPositionApply.TabIndex = 3;
            this.btn_realEndPositionApply.Text = "apply";
            this.btn_realEndPositionApply.UseVisualStyleBackColor = true;
            this.btn_realEndPositionApply.Click += new System.EventHandler(this.btn_realEndPositionApply_Click);
            // 
            // tb_realEndPosition
            // 
            this.tb_realEndPosition.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_realEndPosition.Location = new System.Drawing.Point(19, 37);
            this.tb_realEndPosition.Name = "tb_realEndPosition";
            this.tb_realEndPosition.Size = new System.Drawing.Size(95, 30);
            this.tb_realEndPosition.TabIndex = 2;
            this.tb_realEndPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_realEndPosition.TextChanged += new System.EventHandler(this.tb_realEndPosition_TextChanged);
            // 
            // gb_currentWavelenght
            // 
            this.gb_currentWavelenght.BackColor = System.Drawing.Color.Snow;
            this.gb_currentWavelenght.Controls.Add(this.btn_currentWavelengthApply);
            this.gb_currentWavelenght.Controls.Add(this.tb_currentWavelength);
            this.gb_currentWavelenght.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_currentWavelenght.Location = new System.Drawing.Point(33, 137);
            this.gb_currentWavelenght.Name = "gb_currentWavelenght";
            this.gb_currentWavelenght.Size = new System.Drawing.Size(226, 76);
            this.gb_currentWavelenght.TabIndex = 9;
            this.gb_currentWavelenght.TabStop = false;
            this.gb_currentWavelenght.Text = "current wavelength";
            // 
            // btn_currentWavelengthApply
            // 
            this.btn_currentWavelengthApply.Location = new System.Drawing.Point(128, 37);
            this.btn_currentWavelengthApply.Name = "btn_currentWavelengthApply";
            this.btn_currentWavelengthApply.Size = new System.Drawing.Size(87, 30);
            this.btn_currentWavelengthApply.TabIndex = 3;
            this.btn_currentWavelengthApply.Text = "apply";
            this.btn_currentWavelengthApply.UseVisualStyleBackColor = true;
            this.btn_currentWavelengthApply.Click += new System.EventHandler(this.btn_currentWavelengthApply_Click);
            // 
            // tb_currentWavelength
            // 
            this.tb_currentWavelength.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_currentWavelength.Location = new System.Drawing.Point(19, 38);
            this.tb_currentWavelength.Name = "tb_currentWavelength";
            this.tb_currentWavelength.Size = new System.Drawing.Size(95, 30);
            this.tb_currentWavelength.TabIndex = 2;
            this.tb_currentWavelength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_currentWavelength.TextChanged += new System.EventHandler(this.tb_currentWavelength_TextChanged);
            // 
            // gb_countNmPer1Step
            // 
            this.gb_countNmPer1Step.BackColor = System.Drawing.Color.Snow;
            this.gb_countNmPer1Step.Controls.Add(this.lbl_countNmPer1Step);
            this.gb_countNmPer1Step.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_countNmPer1Step.Location = new System.Drawing.Point(33, 40);
            this.gb_countNmPer1Step.Name = "gb_countNmPer1Step";
            this.gb_countNmPer1Step.Size = new System.Drawing.Size(226, 72);
            this.gb_countNmPer1Step.TabIndex = 10;
            this.gb_countNmPer1Step.TabStop = false;
            this.gb_countNmPer1Step.Text = "count nm per 1 step";
            // 
            // lbl_countNmPer1Step
            // 
            this.lbl_countNmPer1Step.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_countNmPer1Step.Location = new System.Drawing.Point(7, 32);
            this.lbl_countNmPer1Step.Name = "lbl_countNmPer1Step";
            this.lbl_countNmPer1Step.Size = new System.Drawing.Size(208, 29);
            this.lbl_countNmPer1Step.TabIndex = 0;
            this.lbl_countNmPer1Step.Text = "1000";
            this.lbl_countNmPer1Step.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_countStepPer1Nm
            // 
            this.gb_countStepPer1Nm.BackColor = System.Drawing.Color.Snow;
            this.gb_countStepPer1Nm.Controls.Add(this.btn_countStepsPer1NmApply);
            this.gb_countStepPer1Nm.Controls.Add(this.tb_countStepsPer1Nm);
            this.gb_countStepPer1Nm.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_countStepPer1Nm.Location = new System.Drawing.Point(285, 137);
            this.gb_countStepPer1Nm.Name = "gb_countStepPer1Nm";
            this.gb_countStepPer1Nm.Size = new System.Drawing.Size(259, 76);
            this.gb_countStepPer1Nm.TabIndex = 8;
            this.gb_countStepPer1Nm.TabStop = false;
            this.gb_countStepPer1Nm.Text = "count steps per 1 nm";
            // 
            // btn_countStepsPer1NmApply
            // 
            this.btn_countStepsPer1NmApply.Location = new System.Drawing.Point(165, 39);
            this.btn_countStepsPer1NmApply.Name = "btn_countStepsPer1NmApply";
            this.btn_countStepsPer1NmApply.Size = new System.Drawing.Size(87, 30);
            this.btn_countStepsPer1NmApply.TabIndex = 3;
            this.btn_countStepsPer1NmApply.Text = "apply";
            this.btn_countStepsPer1NmApply.UseVisualStyleBackColor = true;
            this.btn_countStepsPer1NmApply.Click += new System.EventHandler(this.btn_countStepsPer1NmApply_Click);
            // 
            // tb_countStepsPer1Nm
            // 
            this.tb_countStepsPer1Nm.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_countStepsPer1Nm.Location = new System.Drawing.Point(17, 39);
            this.tb_countStepsPer1Nm.Name = "tb_countStepsPer1Nm";
            this.tb_countStepsPer1Nm.Size = new System.Drawing.Size(139, 30);
            this.tb_countStepsPer1Nm.TabIndex = 2;
            this.tb_countStepsPer1Nm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_countStepsPer1Nm.TextChanged += new System.EventHandler(this.tb_countStepsPer1Nm_TextChanged);
            // 
            // gb_delayMsPer1Step
            // 
            this.gb_delayMsPer1Step.BackColor = System.Drawing.Color.Snow;
            this.gb_delayMsPer1Step.Controls.Add(this.btn_delayMsPer1StepApply);
            this.gb_delayMsPer1Step.Controls.Add(this.tb_delayMsPer1StepApply);
            this.gb_delayMsPer1Step.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_delayMsPer1Step.Location = new System.Drawing.Point(285, 40);
            this.gb_delayMsPer1Step.Name = "gb_delayMsPer1Step";
            this.gb_delayMsPer1Step.Size = new System.Drawing.Size(259, 72);
            this.gb_delayMsPer1Step.TabIndex = 7;
            this.gb_delayMsPer1Step.TabStop = false;
            this.gb_delayMsPer1Step.Text = "delay ms per 1 step";
            // 
            // btn_delayMsPer1StepApply
            // 
            this.btn_delayMsPer1StepApply.Location = new System.Drawing.Point(165, 33);
            this.btn_delayMsPer1StepApply.Name = "btn_delayMsPer1StepApply";
            this.btn_delayMsPer1StepApply.Size = new System.Drawing.Size(87, 31);
            this.btn_delayMsPer1StepApply.TabIndex = 1;
            this.btn_delayMsPer1StepApply.Text = "apply";
            this.btn_delayMsPer1StepApply.UseVisualStyleBackColor = true;
            this.btn_delayMsPer1StepApply.Click += new System.EventHandler(this.btn_delayMsPer1StepApply_Click);
            // 
            // tb_delayMsPer1StepApply
            // 
            this.tb_delayMsPer1StepApply.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_delayMsPer1StepApply.Location = new System.Drawing.Point(36, 33);
            this.tb_delayMsPer1StepApply.Name = "tb_delayMsPer1StepApply";
            this.tb_delayMsPer1StepApply.Size = new System.Drawing.Size(99, 30);
            this.tb_delayMsPer1StepApply.TabIndex = 0;
            this.tb_delayMsPer1StepApply.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_delayMsPer1StepApply.TextChanged += new System.EventHandler(this.tb_delayMsPer1StepApply_TextChanged);
            // 
            // StepMotorCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(577, 434);
            this.Controls.Add(this.btn_startCalibration);
            this.Controls.Add(this.gb_theoreticalEndPosition);
            this.Controls.Add(this.gb_realEndPosition);
            this.Controls.Add(this.gb_currentWavelenght);
            this.Controls.Add(this.gb_countNmPer1Step);
            this.Controls.Add(this.gb_countStepPer1Nm);
            this.Controls.Add(this.gb_delayMsPer1Step);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "StepMotorCalibration";
            this.Text = "SM Calibrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StepMotorCalibration_FormClosing);
            this.Shown += new System.EventHandler(this.StepMotorCalibration_Shown);
            this.gb_theoreticalEndPosition.ResumeLayout(false);
            this.gb_theoreticalEndPosition.PerformLayout();
            this.gb_realEndPosition.ResumeLayout(false);
            this.gb_realEndPosition.PerformLayout();
            this.gb_currentWavelenght.ResumeLayout(false);
            this.gb_currentWavelenght.PerformLayout();
            this.gb_countNmPer1Step.ResumeLayout(false);
            this.gb_countStepPer1Nm.ResumeLayout(false);
            this.gb_countStepPer1Nm.PerformLayout();
            this.gb_delayMsPer1Step.ResumeLayout(false);
            this.gb_delayMsPer1Step.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_startCalibration;
        private System.Windows.Forms.GroupBox gb_theoreticalEndPosition;
        private System.Windows.Forms.Button btn_theoreticalEndPositionApply;
        private System.Windows.Forms.TextBox tb_theoreticalEndPosition;
        private System.Windows.Forms.GroupBox gb_realEndPosition;
        private System.Windows.Forms.Button btn_realEndPositionApply;
        private System.Windows.Forms.TextBox tb_realEndPosition;
        private System.Windows.Forms.GroupBox gb_currentWavelenght;
        private System.Windows.Forms.Button btn_currentWavelengthApply;
        private System.Windows.Forms.TextBox tb_currentWavelength;
        private System.Windows.Forms.GroupBox gb_countNmPer1Step;
        private System.Windows.Forms.Label lbl_countNmPer1Step;
        private System.Windows.Forms.GroupBox gb_countStepPer1Nm;
        private System.Windows.Forms.Button btn_countStepsPer1NmApply;
        private System.Windows.Forms.TextBox tb_countStepsPer1Nm;
        private System.Windows.Forms.GroupBox gb_delayMsPer1Step;
        private System.Windows.Forms.Button btn_delayMsPer1StepApply;
        private System.Windows.Forms.TextBox tb_delayMsPer1StepApply;
    }
}