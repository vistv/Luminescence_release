using System;
using System.Collections.Generic;
using Luminescence.Engine.Managers.Settings;
using Luminescence.Engine.Models;
using Luminescence.Engine.Repositories.ResultSavers;

namespace Luminescence.Engine.Managers.Saver
{
    public class ResultSaverManager : IResultSaverManager
    {
        #region Constants

        private const string BEGIN_POSITION = "Begin position: ";
        private const string END_POSITION = "End position: ";
        private const string DELAY_SEC_PER_1_DIMENSION = "Delay sec per 1 dimension: ";
        private const string DIMENSION_STEP_NM = "Step nm per 1 dimension: ";
        private const string CURRENT_DATA = "Date: ";
        private const string STRIP = "----------------------------------------------------------";
        private const string SM1 = "SM1Position";
        private const string SM2 = "SM2Position";
        private const string CHANNEL_A = "CHANNEL_A";
        private const string CHANNEL_B = "CHANNEL_B";

        #endregion

        #region Fields

        private readonly IResultSaverRepository _resultSaverRepository;

        #endregion

        #region Ctors

        public ResultSaverManager(IResultSaverRepository resultSaverRepository)
        {
            _resultSaverRepository = resultSaverRepository;
        }

        #endregion

        #region Properties

        public List<Results> Results { get; } = new List<Results>();
        public IDimensionSettingsManager DimensionSettings { get; set; }

        #endregion

        #region Methods

        public void SaveData(string filePath)
        {
            _resultSaverRepository.SaveResult(filePath, GetStrings());
        }

        #endregion

        #region Helpers

        private IEnumerable<string> GetStrings()
        {
            yield return CURRENT_DATA + DateTime.Now;
            yield return STRIP;
            yield return BEGIN_POSITION + Math.Round(this.DimensionSettings.BeginPosition, 1) + "nm";
            yield return END_POSITION + Math.Round(this.DimensionSettings.EndPosition, 1) + "nm";
            yield return DELAY_SEC_PER_1_DIMENSION + this.DimensionSettings.DimensionDelaySec;
            yield return DIMENSION_STEP_NM + this.DimensionSettings.DimensionStepNm;
            yield return STRIP;
            yield return String.Format("{0,-10:#######}    {1,-10:#######}    {2,-10:####.000}    {3,-10:####.000}", CHANNEL_A, CHANNEL_B, SM1, SM2);
            foreach (var x in Results)
            {
                yield return String.Format("{0,-10:#######}    {1,-10:#######}    {2,-10:####.000}     {3,-10:####.000}",
                    x.Data.ChannelA.ToString(), x.Data.ChannelB.ToString(), x.SM1Position, x.SM2Position);
            }
        }

        #endregion
    }
}
