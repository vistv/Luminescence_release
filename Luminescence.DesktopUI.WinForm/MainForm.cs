using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Luminescence.DesktopUI.WinForm.Code;
using Luminescence.DesktopUI.WinForm.Properties;
using Luminescence.Engine.Devices;
using Luminescence.Engine.Managers.Device;
using Luminescence.Engine.Models;


namespace Luminescence.DesktopUI.WinForm
{
    public partial class MainForm : Form
    {
        #region Constants

        private const string SM_BTN_GO = "Go";
        private const string SM_BTN_STOP = "Stop";
        private const string CONNECTED = "connected";
        private const string DISCONECTED = "disconnected";
        private const string CHANNEL_OFF = "--";

        private const string START_DIMENSIONS = "start\nproccess";
        private const string STOP_DIMENSIONS = "abort\nproccess";
        private const string PAUSE_DIMENSIONS = "pause\nproccess";
        private const string RESUME_DIMENSIONS = "resume\nproccess";
        private const string STATUS_BAR = " % completed";
        private const string STATUS_BAR_PAUSED = " (paused)";
        private const string STATUS_BAR_ABORTED = "ABORTED (";
        private const byte COUNT_DECIMAL_PLACES = 1;
        private const byte TIME_COUNT_DECIMAL_PLACES = 1;

        private const string PAUSE = "PAUSE";
        private const string ABORTED = "ABORTED";

        // The regular expression for check entering value for wavelengths.
        private const string WAVELENGTH_REG = "^[1-9][0-9]{0,3}([.][0-9]?)?$|^[0]([.][0-9]?)?$";

        #region Graph Constants

        private const string IDLING_AREA = "area";
        private const string IDLIND_SESSION_CHANNEL_A = "channelA";
        private const string IDLIND_SESSION_CHANNEL_B = "channelB";

        #region Idling Mode
        
        private const string IDLING_OX_TITLE = "time, ";
        private const byte COUNT_MAX_POINT_ON_GRAPH = 10;

        #endregion

        #region Workflow Mode

        private const string WOKFLOW_OX_TITLE = "nanometers (nm)";

        #endregion

        #endregion

        #endregion

        #region Fields

        private readonly IDevice _device;
        private readonly CultureInfo CULTURE = CultureInfo.CreateSpecificCulture("en-US");
        private readonly Regex _regex = new Regex(WAVELENGTH_REG);

        #endregion

        #region Form Methods

        public MainForm(IDevice device)
        {
            InitializeComponent();

            _device = device;
        }

        private void Luminescence_Load(object sender, EventArgs e)
        {
            #region SignToEvents

            _device.DeviceManager.Connected += (o, args) => { InvokeControls.InvokeIfRequired(this, this.ShowConnectedStatus); };
            _device.DeviceManager.Disconnected += (o, args) => { InvokeControls.InvokeIfRequired(this, this.ShowDisconnectedStatus); };
            
            EventHandler<EventArgs> refreshCurrentWavelength = (o, args) => { InvokeControls.InvokeIfRequired(lbl_currentWavelength, this.RefreshCurrentWavelenght); };
            _device.StepMotor1Settings.CurrentWavelengthChanged += refreshCurrentWavelength;
            _device.StepMotor2Settings.CurrentWavelengthChanged += refreshCurrentWavelength;
            _device.StepMotor1Settings.CurrentWavelengthChanged += (o, args) => { InvokeControls.InvokeIfRequired(lbl_stepMotor1Wavelength, this.RefreshStepMotor1Wavelenght); };
            _device.StepMotor2Settings.CurrentWavelengthChanged += (o, args) => { InvokeControls.InvokeIfRequired(lbl_stepMotor2Wavelength, this.RefreshStepMotor2Wavelenght); };
            _device.ActiveStepMotorChanged += refreshCurrentWavelength;
            
            _device.ActiveStepMotorChanged += (o, args) => { InvokeControls.InvokeIfRequired(this, ShowActiveStepMotor); };

            _device.IdlingDimensionCompleted += (o, args) =>
            {
                InvokeControls.InvokeIfRequired(chart_dimensions, this.DisplayIdlingMode);
                InvokeControls.InvokeIfRequired(gb_currentStatus, this.RefreshChannels);
            };
            _device.WorkflowOneDimensionCompleted += (o, args) => { InvokeControls.InvokeIfRequired(chart_dimensions, this.DisplayWorkflowMode); };
            _device.WorkflowOneDimensionCompleted += (o, args) => { InvokeControls.InvokeIfRequired(this, new Action(() => { this.MonitorProgressBar(); })); };
            _device.WorkflowOneDimensionCompleted += (o, args) => { InvokeControls.InvokeIfRequired(gb_currentStatus, RefreshChannels); };

            _device.WorkflowDimensionsCompleted += (o, args) =>
            {
                InvokeControls.InvokeIfRequired(this, () =>
                {
                    this.MonitorProgressBar();
                    btn_saveDim.Visible = true;
                });
            };

            _device.WorkflowDimensionsAborted += (o, args) => 
            {
                InvokeControls.InvokeIfRequired(this, () =>
                {
                    lbl_statusComplete.Text = STATUS_BAR_ABORTED + _device.PercenteCompleted + STATUS_BAR + " )";
                    prBar_dimensionProgress.ForeColor = Color.Red;
                    lbl_remainingTime.Text = ABORTED;
                    btn_saveDim.Visible = true;
                });
            };

            _device.IdlingDimensionsStarted += (o, args) =>
            {
                InvokeControls.InvokeIfRequired(this, () =>
                {
                    this.RefreshGraphOxTitle();
                    this.lbl_elapsedTime.Text = CHANNEL_OFF;
                    this.lbl_remainingTime.Text = CHANNEL_OFF;
                });
            };
            
            _device.WorkflowDimensionsStarted += (o, args) =>
            {
                InvokeControls.InvokeIfRequired(chart_dimensions, this.InitWorkflowGraphOxTitle);
                InvokeControls.InvokeIfRequired(btn_pauseDimensions, new Action(() =>
                {
                    btn_pauseDimensions.Enabled = true;
                }));
                InvokeControls.InvokeIfRequired(lbl_statusComplete, () => { lbl_statusComplete.Visible = true; });
                InvokeControls.InvokeIfRequired(this, () =>
                {
                    prBar_dimensionProgress.ForeColor = Color.Green;
                    btn_saveDim.Visible = false;
                });
            };
            _device.WorkflowDimensionsPaused += (o, args) =>
            {
                InvokeControls.InvokeIfRequired(this, () =>
                {
                    prBar_dimensionProgress.ForeColor = Color.Yellow;
                    btn_saveDim.Visible = true;
                });
            };

            EventHandler<EventArgs> dimensionsEnded = (o, args) =>
            {
                InvokeControls.InvokeIfRequired(this, new Action(() =>
                {
                    btn_startDimensions.Text = START_DIMENSIONS;
                    btn_pauseDimensions.Enabled = false;
                    btn_pauseDimensions.Text = PAUSE_DIMENSIONS;

                    gb_stepMotor2.Enabled = true;
                    gb_stepMotor1.Enabled = true;
                    settingsToolStripMenuItem.Enabled = true;
                }));
            };

            _device.WorkflowDimensionsCompleted += dimensionsEnded;
            _device.WorkflowDimensionsAborted += dimensionsEnded;

            _device.WorkflowDimensionsPaused += (o, args) =>
            {
                InvokeControls.InvokeIfRequired(this, new Action(() => 
                {
                    lbl_remainingTime.Text = PAUSE;
                    lbl_statusComplete.Text += STATUS_BAR_PAUSED;
                }));
            };
            _device.WorkflowDimensionsResumed += (o, args) =>
            {
                InvokeControls.InvokeIfRequired(this, () =>
                {
                    btn_pauseDimensions.Text = PAUSE_DIMENSIONS;
                    btn_startDimensions.Enabled = true;
                    prBar_dimensionProgress.ForeColor = Color.Green;
                    btn_saveDim.Visible = false;
                });
            };


            Action windEnded = () =>
            {
                if (_device.CurrentActiveStepMotor == ActiveStepMotor.StepMotor1)
                {
                    btn_sm1Go.Text = SM_BTN_GO;
                    btn_sm1Incr.Enabled = true;
                    btn_sm1Decr.Enabled = true;
                    btn_sm1Set.Enabled = true;

                    gb_stepMotor2.Enabled = true;
                    gb_setSM.Enabled = true;
                }
                else
                { 
                    btn_sm2Go.Text = SM_BTN_GO;

                    btn_sm2Incr.Enabled = true;
                    btn_sm2Decr.Enabled = true;
                    btn_sm2Set.Enabled = true;

                    gb_stepMotor1.Enabled = true;
                    gb_setSM.Enabled = true;
                }
                gb_controlPanel.Enabled = true;
                settingsToolStripMenuItem.Enabled = true;
            };
            _device.WindCompleted += (o, args) => { InvokeControls.InvokeIfRequired(this, windEnded); };
            _device.WindAborted += (o, args) => { InvokeControls.InvokeIfRequired(this, windEnded); };

            Action setEnabledGoButton = () =>
            {
                if (_device.CurrentActiveStepMotor == ActiveStepMotor.StepMotor1)
                {
                    btn_sm1Go.Enabled = true;
                }
                else
                {
                    btn_sm2Go.Enabled = true;
                }
            };

            _device.WindStarted += (o, args) => { InvokeControls.InvokeIfRequired(this, setEnabledGoButton); };

            #endregion


            #region Init Fields

            InitLastFileNameField();

            this.SM1Init();
            this.SM2Init();

            this.RefreshDimTime();
            this.RefreshDimStep();
            this.RefreshDimEndPosition();

            this.RefreshConnectedStatus();
            this.RefreshCurrentWavelenght();
            this.RefreshStepMotor1Wavelenght();
            this.RefreshStepMotor2Wavelenght();
            this.RefreshGraphOxTitle();

            #endregion

            // start device
            _device.StartDevice();
        }

        #endregion

        #region DisplayData

        private void DisplayIdlingMode()
        {
            //if (chart_dimensions.Series[IDLIND_SESSION_CHANNEL_A].Points.Count == COUNT_MAX_POINT_ON_GRAPH)
            //{
            //    chart_dimensions.Series[IDLIND_SESSION_CHANNEL_A].Points.Clear();
            //    chart_dimensions.Series[IDLIND_SESSION_CHANNEL_B].Points.Clear();
            //}
            //chart_dimensions.Series[IDLIND_SESSION_CHANNEL_A].Points.AddY(_device.LastDataOfDimension.ChannelA);
            //chart_dimensions.Series[IDLIND_SESSION_CHANNEL_B].Points.AddY(_device.LastDataOfDimension.ChannelB);
        }
        
        private void RefreshGraphOxTitle()
        {
            //chart_dimensions.ChartAreas[IDLING_AREA].AxisX.Title = IDLING_OX_TITLE;
            //chart_dimensions.ChartAreas[IDLING_AREA].AxisX.Title += _device.DimensionSettings.DimensionDelaySec + " Sec";

            //chart_dimensions.Series[IDLIND_SESSION_CHANNEL_A].Points.Clear();
            //chart_dimensions.Series[IDLIND_SESSION_CHANNEL_B].Points.Clear();
        }

        private void DisplayWorkflowMode()
        {
            chart_dimensions.Series[IDLIND_SESSION_CHANNEL_A].Points.AddXY(Math.Round(_device.ActiveStepMotorSettings.CurrentWavelength, COUNT_DECIMAL_PLACES).ToString(CULTURE), _device.LastDataOfDimension.ChannelA);
            chart_dimensions.Series[IDLIND_SESSION_CHANNEL_B].Points.AddXY(Math.Round(_device.ActiveStepMotorSettings.CurrentWavelength, COUNT_DECIMAL_PLACES).ToString(CULTURE), _device.LastDataOfDimension.ChannelB);
          //  chart_dimensions.ChartAreas[IDLING_AREA].AxisX.Minimum = 200;
          //  chart_dimensions.ChartAreas[IDLING_AREA].AxisX.Maximum = 800;
        }
        
        private void InitWorkflowGraphOxTitle()
        {
            chart_dimensions.ChartAreas[IDLING_AREA].AxisX.Title = WOKFLOW_OX_TITLE;

            chart_dimensions.Series[IDLIND_SESSION_CHANNEL_A].Points.Clear();
            chart_dimensions.Series[IDLIND_SESSION_CHANNEL_B].Points.Clear();
        }

        private void MonitorProgressBar()
        {
            if (_device.PercenteCompleted > 100)
            {
                prBar_dimensionProgress.Value = prBar_dimensionProgress.Maximum;
            }
            else
            {
                prBar_dimensionProgress.Value = _device.PercenteCompleted;
            }
            lbl_statusComplete.Text = prBar_dimensionProgress.Value + STATUS_BAR;

            lbl_elapsedTime.Text = _device.ElapsedTime.ToString("hh\\:mm\\:ss");
            lbl_remainingTime.Text = _device.RemainingTime.ToString("hh\\:mm\\:ss");
        }

        #endregion

        #region Menu

        private void calibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new StepMotorCalibration(_device)).ShowDialog();
        }

        #endregion

        #region Refreshers
        private void RefreshChannels()
        {
            lbl_channelA.Text = _device.LastDataOfDimension.ChannelA.ToString();
            lbl_channelB.Text = _device.LastDataOfDimension.ChannelB.ToString();
        }

        private void RefreshConnectedStatus()
        {
            if (_device.DeviceManager.IsConnected)
            {
                this.ShowConnectedStatus();
            }
            else
            {
                this.ShowDisconnectedStatus();
            }
        }

        private void ShowConnectedStatus()
        {
            lbl_connectionStatus.Text = CONNECTED;
            lbl_connectionStatus.BackColor = Color.LimeGreen;
            pb_connectionStatus.Image = Resources.usb_ok;
            SetAvailableFormActions(true);
        }

        private void ShowDisconnectedStatus()
        {
            lbl_connectionStatus.Text = DISCONECTED;
            lbl_connectionStatus.BackColor = Color.Red;
            pb_connectionStatus.Image = Resources.usb_fail;
            lbl_channelA.Text = lbl_channelB.Text = CHANNEL_OFF;
            SetAvailableFormActions(false);
        }

        private void SetAvailableFormActions(bool enable)
        {
            settingsToolStripMenuItem.Enabled = enable;
            gb_setSM.Enabled = enable;
            gb_stepMotor1.Enabled = enable;
            btn_pauseDimensions.Enabled = enable;
            btn_startDimensions.Enabled = enable;
        }

        private void RefreshCurrentWavelenght()
        {
            lbl_currentWavelength.Text = Math.Round(_device.ActiveStepMotorSettings.CurrentWavelength, COUNT_DECIMAL_PLACES).ToString(CULTURE);
        }

        private void RefreshStepMotor1Wavelenght()
        {
            lbl_stepMotor1Wavelength.Text = Math.Round(_device.StepMotor1Settings.CurrentWavelength, COUNT_DECIMAL_PLACES).ToString(CULTURE);
            tb_sm1CurrentWavelength.Text = lbl_stepMotor1Wavelength.Text;
        }

        private void RefreshStepMotor2Wavelenght()
        {
            lbl_stepMotor2Wavelength.Text = Math.Round(_device.StepMotor2Settings.CurrentWavelength, COUNT_DECIMAL_PLACES).ToString(CULTURE);
            tb_sm2CurrentWavelength.Text = lbl_stepMotor2Wavelength.Text;
        }

        private void ShowActiveStepMotor()
        {
            GroupBox active;
            GroupBox notActive;
            if (_device.CurrentActiveStepMotor == ActiveStepMotor.StepMotor1)
            {
                active = gb_stepMotor1;
                notActive = gb_stepMotor2;
            }
            else
            {
                active = gb_stepMotor2;
                notActive = gb_stepMotor1;
            }
            active.BackColor = Color.Moccasin;
            notActive.BackColor = Color.WhiteSmoke;
        }

        #endregion

        #region Initializators

        private void InitLastFileNameField()
        {
            tb_fileName.Text = _device.Saver.LastFileName;
        }

        private void SM1Init()
        {
            tb_sm1CurrentWavelength.Text = Math.Round(_device.StepMotor1Settings.CurrentWavelength, COUNT_DECIMAL_PLACES).ToString(CULTURE);
            tb_sm1GoTo.Text = tb_sm1CurrentWavelength.Text;
        }

        private void SM2Init()
        {
            tb_sm2CurrentWavelength.Text = Math.Round(_device.StepMotor2Settings.CurrentWavelength, COUNT_DECIMAL_PLACES).ToString(CULTURE);
            tb_sm2GoTo.Text = tb_sm2CurrentWavelength.Text;
        }

        #endregion

        #region Step Motor1 Controls

        private void rb_activeStepMotor1_CheckedChanged(object sender, EventArgs e)
        {
            _device.CurrentActiveStepMotor = ActiveStepMotor.StepMotor1;
            
        }

        private void btn_sm1Set_Click(object sender, EventArgs e)
        {
            _device.StepMotor1Settings.CurrentWavelength = Single.Parse(tb_sm1CurrentWavelength.Text, CULTURE);
        }

        private void btn_sm1Go_Click(object sender, EventArgs e)
        {
            if (_device.IsWinding)
            {
                _device.StopWind();
            }
            else
            {
                if (_device.CurrentActiveStepMotor != ActiveStepMotor.StepMotor1)
                {
                    rb_activeStepMotor1.PerformClick();
                }
                if (_device.StartWindAsync(Single.Parse(tb_sm1GoTo.Text, CULTURE)))
                {
                    btn_sm1Go.Enabled = false;
                    btn_sm1Incr.Enabled = false;
                    btn_sm1Decr.Enabled = false;
                    btn_sm1Set.Enabled = false;

                    gb_setSM.Enabled = false;

                    gb_controlPanel.Enabled = false;

                    btn_sm1Go.Text = SM_BTN_STOP;
                    settingsToolStripMenuItem.Enabled = false;
                }
            }
        }
        
        private void btn_sm1Incr_Click(object sender, EventArgs e)
        {
            if (_device.CurrentActiveStepMotor != ActiveStepMotor.StepMotor1)
            {
                rb_activeStepMotor1.PerformClick();
            }
            _device.Increment();
        }

        private void btn_sm1Decr_Click(object sender, EventArgs e)
        {
            if (_device.CurrentActiveStepMotor != ActiveStepMotor.StepMotor1)
            {
                rb_activeStepMotor1.PerformClick();
            }
            _device.Decrement();
        }

        private void RefreshDimStep()
        {
            tb_dimStep.Text = Math.Round(_device.DimensionSettings.DimensionStepNm, COUNT_DECIMAL_PLACES).ToString(CULTURE);
        }

        private void RefreshDimTime()
        {
            nm_dimTime.Text = Math.Round((decimal) _device.DimensionSettings.DimensionDelaySec, TIME_COUNT_DECIMAL_PLACES).ToString(CULTURE);
        }

        private void RefreshDimEndPosition()
        {
            tb_dimStopAt.Text = Math.Round(_device.DimensionSettings.EndPosition, COUNT_DECIMAL_PLACES).ToString(CULTURE);
        }

        #endregion

        #region Step Motor 2 Controls

        private void rb_activeStepMotor2_CheckedChanged(object sender, EventArgs e)
        {
            _device.CurrentActiveStepMotor = ActiveStepMotor.StepMotor2;
        }

        private void btn_sm2Go_Click(object sender, EventArgs e)
        {
            if (_device.IsWinding)
            {
                _device.StopWind();
            }
            else
            {
                if (_device.CurrentActiveStepMotor != ActiveStepMotor.StepMotor2)
                {
                    rb_activeStepMotor2.PerformClick();
                }
                if (_device.StartWindAsync(Single.Parse(tb_sm2GoTo.Text, CULTURE)))
                {
                    btn_sm2Go.Enabled = false;
                    btn_sm2Incr.Enabled = false;
                    btn_sm2Decr.Enabled = false;
                    btn_sm2Set.Enabled = false;

                    gb_stepMotor1.Enabled = false;
                    gb_setSM.Enabled = false;
                    btn_sm2Go.Text = SM_BTN_STOP;
                    settingsToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void btn_sm2Set_Click(object sender, EventArgs e)
        {
            _device.StepMotor2Settings.CurrentWavelength = Single.Parse(tb_sm2CurrentWavelength.Text, CULTURE);
        }

        private void btn_sm2Incr_Click(object sender, EventArgs e)
        {
            if (_device.CurrentActiveStepMotor != ActiveStepMotor.StepMotor2)
            {
                rb_activeStepMotor2.PerformClick();
            }
            _device.Increment();
        }

        private void btn_sm2Decr_Click(object sender, EventArgs e)
        {
            if (_device.CurrentActiveStepMotor != ActiveStepMotor.StepMotor2)
            {
                rb_activeStepMotor2.PerformClick();
            }
            _device.Decrement();
        }

        #endregion

        #region Dimension Controls

        private void btn_startDimensions_Click(object sender, EventArgs e)
        {
            if (!_device.IsWorkflowing)
            {
                btn_dimApply.PerformClick();
                if (_device.StartDimensions())
                {
                    btn_startDimensions.Text = STOP_DIMENSIONS;
                    gb_stepMotor2.Enabled = false;
                    gb_stepMotor1.Enabled = false;
                    settingsToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                _device.AbortDimensions();
            }
        }

        private void btn_pauseDimensions_Click(object sender, EventArgs e)
        {
            if (!_device.IsWorkflowingPaused)
            {
                _device.PauseDimensions();
                btn_startDimensions.Enabled = false;
                btn_pauseDimensions.Text = RESUME_DIMENSIONS;
            }
            else
            {
                _device.ResumeDimensions();
            }
        }

        #endregion

        #region General Controls

        private void btn_dimApply_Click(object sender, EventArgs e)
        {
            ApplyDimensionSettings();

            ((Button)sender).ShowApllayedButton();

            InvokeControls.InvokeIfRequired(chart_dimensions, this.RefreshGraphOxTitle);
        }

        private void ApplyDimensionSettings()
        {
            if (_device.IsWorkflowing)
            {
                _device.PauseDimensions();
            }
            _device.DimensionSettings.BeginPosition = _device.ActiveStepMotorSettings.CurrentWavelength;
            _device.DimensionSettings.DimensionDelaySec = (byte)Single.Parse(nm_dimTime.Text, CULTURE);
            _device.DimensionSettings.EndPosition = Single.Parse(tb_dimStopAt.Text, CULTURE);
            _device.DimensionSettings.DimensionStepNm = Single.Parse(tb_dimStep.Text, CULTURE);
            if (_device.IsWorkflowingPaused)
            {
                _device.ResumeDimensions();
            }
        }

        #endregion

        private void tb_dimStep_TextChanged(object sender, EventArgs e)
        {
            this.CheckTextBox(sender);
            btn_dimApply.ShowNotApllayedButton();
        }

        

        private void nm_dimTime_ValueChanged(object sender, EventArgs e)
        {
            btn_dimApply.ShowNotApllayedButton();
        }

        private void tb_dimStopAt_TextChanged(object sender, EventArgs e)
        {
            this.CheckTextBox(sender);
            btn_dimApply.ShowNotApllayedButton();
        }

        private void btn_saveDim_Click(object sender, EventArgs e)
        {
            sfd_saveDim.FileName = tb_fileName.Text;
            if (sfd_saveDim.ShowDialog() == DialogResult.OK)
            {
                
                _device.Saver.SaveData(sfd_saveDim.FileName);
                _device.Saver.LastFileName = tb_fileName.Text;
            }
        }

        private void tb_sm1CurrentWavelength_TextChanged(object sender, EventArgs e)
        {
            this.CheckTextBox(sender);
        }

        private void tb_sm1GoTo_TextChanged(object sender, EventArgs e)
        {
            this.CheckTextBox(sender);
        }

        private void tb_sm2CurrentWavelength_TextChanged(object sender, EventArgs e)
        {
            this.CheckTextBox(sender);
        }

        private void tb_sm2GoTo_TextChanged(object sender, EventArgs e)
        {
            this.CheckTextBox(sender);
        }

        private void CheckTextBox(object senderTextBox)
        {
            ((TextBox)senderTextBox).CheckAtReqular(_regex);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Show at not for pressed button.
            btn_dimApply.ShowApllayedButton();
        }

        private void lbl_remainingTime_Click(object sender, EventArgs e)
        {

        }
    }
}
