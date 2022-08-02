using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Luminescence.Engine.Devices;
using System.Text.RegularExpressions;
using Luminescence.DesktopUI.WinForm.Code;

namespace Luminescence.DesktopUI.WinForm
{
    public partial class StepMotorCalibration : Form
    {
        #region Constants

        private string BTN_START_CALIBRATION_TEXT = "start calibration";
        private string BTN_STOP_CALIBRATION_TEXT = "stop calibration";
        private string BTN_NEW_CALIBRATION_TEXT = "new calibration";
        private readonly CultureInfo CULTURE = CultureInfo.CreateSpecificCulture("en-US");

        // The regular expression for check entering value for wavelengths.
        private const string WAVELENGTH_REG = "^[1-9][0-9]{0,3}([.][0-9]{0,2})?$|^[0]([.][0-9]{0,2})?$";
        private const byte COUNT_VALUES_AFTER_POINT = 1;

        #endregion

        #region Fields

        private readonly IDevice _device;
        private float _beginPosition;
        private float _thereticalEndPosition;
        private readonly Regex _regex = new Regex(WAVELENGTH_REG);

        #endregion

        public StepMotorCalibration(IDevice device)
        {
            InitializeComponent();

            _device = device;
            _device.WindStarted += _device_ActiveStepMotorStarted;
            _device.WindAborted += _device_ActiveStepMotorAborted;
            _device.WindCompleted += _device_WindCompleted;
            _device.ActiveStepMotorSettings.CurrentWavelengthChanged += this.RefreshCurrentWavelength;

            this.InitFields();
        }

        private void _device_ActiveStepMotorAborted(object sender, EventArgs e)
        {
            this.SetEnabledStatusControls(true);
            this.Invoke(new Action(() =>
            {
                btn_startCalibration.Text = BTN_START_CALIBRATION_TEXT;
                gb_realEndPosition.Enabled = false;
                btn_startCalibration.BackColor = Color.LightGreen;
            }));
        }

        private void _device_ActiveStepMotorStarted(object sender, EventArgs e)
        {
            this.SetEnabledStatusControls(false);
            this.Invoke(new Action(() =>
            {
                this.Enabled = true;
                btn_startCalibration.Text = BTN_STOP_CALIBRATION_TEXT;
                btn_startCalibration.BackColor = Color.LightCoral;
            }));
        }

        private void _device_WindCompleted(object sender, EventArgs e)
        {
            this.SetEnabledStatusControls(false);
            this.Invoke(new Action(() =>
            {
                btn_startCalibration.Text = BTN_NEW_CALIBRATION_TEXT;
                btn_startCalibration.Click -= btn_startCalibration_Click;
                btn_startCalibration.Click += btn_newCalibration_Click;
                gb_realEndPosition.Enabled = true;
                gb_realEndPosition.BackColor = Color.DarkSeaGreen;
                btn_startCalibration.BackColor = Color.LightGreen;
            }));
        }

        private void RefreshCurrentWavelength(object sender, EventArgs e)
        {
            InvokeControls.InvokeIfRequired(this, () =>
            {
                tb_currentWavelength.Text =
                    Math.Round(_device.ActiveStepMotorSettings.CurrentWavelength, COUNT_VALUES_AFTER_POINT)
                        .ToString(CULTURE);
                btn_currentWavelengthApply.ShowApllayedButton();
            });
        }

        private void btn_newCalibration_Click(object sender, EventArgs e)
        {
            this.SetEnabledStatusControls(true);
            this.Invoke(new Action(() =>
            {
                btn_startCalibration.Click -= btn_newCalibration_Click;
                btn_startCalibration.Click += btn_startCalibration_Click;
                btn_startCalibration.Text = BTN_START_CALIBRATION_TEXT;
                gb_realEndPosition.Enabled = false;
                gb_realEndPosition.BackColor = Color.WhiteSmoke;
            }));
        }

        private void SetEnabledStatusControls(bool enabled)
        {
            this.Invoke(new Action<bool>(status =>
            {
                gb_countNmPer1Step.Enabled = status;
                gb_countStepPer1Nm.Enabled = status;
                gb_currentWavelenght.Enabled = status;
                gb_delayMsPer1Step.Enabled = status;
                gb_theoreticalEndPosition.Enabled = status;
            }), enabled);
        }

        private void InitFields()
        {
            tb_theoreticalEndPosition.Text = _device.DimensionSettings.EndPosition.ToString(CULTURE);
            tb_currentWavelength.Text =
                Math.Round(_device.ActiveStepMotorSettings.CurrentWavelength, COUNT_VALUES_AFTER_POINT).ToString(CULTURE);
            tb_countStepsPer1Nm.Text = _device.ActiveStepMotorSettings.CountStepsPer1Nm.ToString(CULTURE);
            tb_delayMsPer1StepApply.Text = _device.ActiveStepMotorSettings.DelayMsPer1Step.ToString();
            lbl_countNmPer1Step.Text = _device.ActiveStepMotorSettings.CountNmPer1Step.ToString(CULTURE);

            gb_realEndPosition.Enabled = false;
            gb_realEndPosition.BackColor = Color.WhiteSmoke;

            // Perform click on the buttons.
            btn_theoreticalEndPositionApply.PerformClick();
        }

        private void btn_delayMsPer1StepApply_Click(object sender, EventArgs e)
        {
            _device.ActiveStepMotorSettings.DelayMsPer1Step = Byte.Parse(tb_delayMsPer1StepApply.Text);
            ((Button)sender).ShowApllayedButton();
        }

        private void btn_countStepsPer1NmApply_Click(object sender, EventArgs e)
        {
            _device.ActiveStepMotorSettings.CountStepsPer1Nm = Single.Parse(tb_countStepsPer1Nm.Text);
            ((Button)sender).ShowApllayedButton();
        }

        private void btn_theoreticalEndPositionApply_Click(object sender, EventArgs e)
        {
            _thereticalEndPosition = Single.Parse(tb_theoreticalEndPosition.Text);
            ((Button)sender).ShowApllayedButton();
        }

        private void btn_currentWavelengthApply_Click(object sender, EventArgs e)
        {
            _device.ActiveStepMotorSettings.CurrentWavelength = Single.Parse(tb_currentWavelength.Text);
            ((Button)sender).ShowApllayedButton();
        }

        private void btn_realEndPositionApply_Click(object sender, EventArgs e)
        {
            float realEndPosition = Single.Parse(tb_realEndPosition.Text);
            _device.CalibrateActiveStepMotor(_beginPosition, realEndPosition);
            tb_countStepsPer1Nm.Text = _device.ActiveStepMotorSettings.CountStepsPer1Nm.ToString(CULTURE);
            lbl_countNmPer1Step.Text = _device.ActiveStepMotorSettings.CountNmPer1Step.ToString(CULTURE);

            btn_startCalibration.PerformClick();
            ((Button)sender).ShowApllayedButton();
            gb_realEndPosition.BackColor = Color.WhiteSmoke;
        }

        private void btn_startCalibration_Click(object sender, EventArgs e)
        {
            if (!_device.IsWinding)
            {
                _beginPosition = _device.ActiveStepMotorSettings.CurrentWavelength;
                this.Enabled = !_device.StartWindAsync(_thereticalEndPosition);
            }
            else
            {
                _device.StopWind();
            }
        }

        private void StepMotorCalibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            _device.StopWind();
            _device.WindStarted -= _device_ActiveStepMotorStarted;
            _device.WindAborted -= _device_ActiveStepMotorAborted;
            _device.WindCompleted -= _device_WindCompleted;
            _device.ActiveStepMotorSettings.CurrentWavelengthChanged -= this.RefreshCurrentWavelength;
        }

        private void tb_delayMsPer1StepApply_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[1-9][0-9]{0,2}$");
            ((TextBox)sender).CheckAtReqular(regex);
            if (Int32.Parse(tb_delayMsPer1StepApply.Text) > Byte.MaxValue)
            {
                tb_delayMsPer1StepApply.Text = Byte.MaxValue.ToString();
            }
            btn_delayMsPer1StepApply.ShowNotApllayedButton();
        }

        private void tb_countStepsPer1Nm_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[1-9][0-9]*([.][0-9]*)?$");
            ((TextBox)sender).CheckAtReqular(regex);
            btn_countStepsPer1NmApply.ShowNotApllayedButton();
        }

        private void tb_theoreticalEndPosition_TextChanged(object sender, EventArgs e)
        {
            this.CheckTextBox(sender);
            btn_theoreticalEndPositionApply.ShowNotApllayedButton();
        }

        private void tb_realEndPosition_TextChanged(object sender, EventArgs e)
        {
            this.CheckTextBox(sender);
            btn_realEndPositionApply.ShowNotApllayedButton();
            btn_realEndPositionApply.Enabled = true;
        }

        private void tb_currentWavelength_TextChanged(object sender, EventArgs e)
        {
            this.CheckTextBox(sender);
            btn_currentWavelengthApply.ShowNotApllayedButton();
        }

        private void CheckTextBox(object senderTextBox)
        {
            ((TextBox) senderTextBox).CheckAtReqular(_regex);
        }

        private void StepMotorCalibration_Shown(object sender, EventArgs e)
        {
            btn_countStepsPer1NmApply.ShowApllayedButton();
            btn_currentWavelengthApply.ShowApllayedButton();
            btn_delayMsPer1StepApply.ShowApllayedButton();
            btn_realEndPositionApply.ShowApllayedButton();
            btn_theoreticalEndPositionApply.ShowApllayedButton();
        }
    }
}
