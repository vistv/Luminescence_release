using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace Luminescence.Engine.Repositories.Settings.StepMotorSettings
{
    public class StepMotorRepository : Repository, IStepMotorRepository
    {
        #region Constants

        private const string COUNT_STEPS_PER_1_NM = "countStepsPer1Nm";
        private const string DELAY_MS_PER_1_STEP = "delayMsPer1Step";
        private const string CURRENT_WAVELENGTH = "currentWavelength";

        #endregion

        #region Constructor

        public StepMotorRepository(string filePath, string fileName, byte theFindedInXmlFileNumber)
            : base(filePath, fileName, theFindedInXmlFileNumber)
        { }

        #endregion

        #region Properties

        public float CountStepsPer1Nm
        {
            get
            {
                return float.Parse(base.GetValue(COUNT_STEPS_PER_1_NM), CultureInfo.CurrentCulture.NumberFormat);
            }
            set
            {
                base.SaveValue(COUNT_STEPS_PER_1_NM, value.ToString(CultureInfo.CurrentCulture));
            }
        }

        public byte DelayMsPer1Step
        {
            get
            {
                return byte.Parse(base.GetValue(DELAY_MS_PER_1_STEP));
            }
            set
            {
                base.SaveValue(DELAY_MS_PER_1_STEP, value.ToString());
            }
        }

        public float CurrentWavelength
        {
            get
            {
                return float.Parse(base.GetValue(CURRENT_WAVELENGTH), CultureInfo.CurrentCulture.NumberFormat);
            }
            set { base.SaveValue(CURRENT_WAVELENGTH, value.ToString(CultureInfo.CurrentCulture)); }
        }

        #endregion
    }
}
