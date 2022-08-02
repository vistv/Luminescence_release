using System;
using System.Globalization;
using System.Threading;

namespace Luminescence.Engine.Repositories.Settings.DimensionSettings
{
    public class DimensionRepository : Repository, IDimensionRepository
    {
        #region Constants

        private const string DELAY_SEC = "delaySec";
        private const string END_WAVELENGTH = "endWavelength";
        private const string BEGIN_WAVELENGTH = "beginWavelength";
        private const string STEPS_NMs = "stepNms";

        #endregion

        #region Constructors

        public DimensionRepository(string filePath, string fileName, byte theFindedInXmlFileNumber)
            : base(filePath, fileName, theFindedInXmlFileNumber)
        { }

        #endregion

        #region Properties

        public byte DelaySec
        {
            get
            {
                return byte.Parse(base.GetValue(DELAY_SEC), CultureInfo.CurrentCulture.NumberFormat);
            }
            set
            {
                base.SaveValue(DELAY_SEC, value.ToString());
            }
        }

        public float BeginWavelength
        {
            get
            {
                return float.Parse(base.GetValue(BEGIN_WAVELENGTH), CultureInfo.CurrentCulture.NumberFormat);
            }
            set
            {
                base.SaveValue(BEGIN_WAVELENGTH, value.ToString(CultureInfo.CurrentCulture));
            }
        }

        public float EndWavelength
        {
            get
            {
                return float.Parse(base.GetValue(END_WAVELENGTH), CultureInfo.CurrentCulture.NumberFormat);
            }
            set
            {
                base.SaveValue(END_WAVELENGTH, value.ToString(CultureInfo.CurrentCulture));
            }
        }

        public float StepNms
        {
            get
            {
                return float.Parse(base.GetValue(STEPS_NMs), CultureInfo.CurrentCulture.NumberFormat);
            }
            set
            {
                base.SaveValue(STEPS_NMs, value.ToString(CultureInfo.CurrentCulture));
            }
        }

        #endregion
    }
}
