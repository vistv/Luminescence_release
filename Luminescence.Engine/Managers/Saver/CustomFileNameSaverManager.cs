using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Luminescence.Engine.Managers.Settings;
using Luminescence.Engine.Models;
using Luminescence.Engine.Repositories.ResultSavers;

namespace Luminescence.Engine.Managers.Saver
{
    public class CustomFileNameSaverManager : ICustomFileNameSaverManager
    {
        private const string NM = "nm";
        private const string CHANNEL_A = "CHANNEL_A";
        private const string CHANNEL_B = "CHANNEL_B";

        private readonly ILastFileNameSaverRepository _resultSaverRepository;

        public List<Results> Results { get; } = new List<Results>();

        public IDimensionSettingsManager DimensionSettings { get; set; }

        public string LastFileName
        {
            get => _resultSaverRepository.LastFileName;
            set => _resultSaverRepository.LastFileName = value;
        }

        public CustomFileNameSaverManager(ILastFileNameSaverRepository resultSaverRepository)
        {
            _resultSaverRepository = resultSaverRepository;
        }

        public void SaveData(string filePath)
        {
            var currentChannelName = Path.GetFileNameWithoutExtension(filePath);
            _resultSaverRepository.SaveResult(filePath, GetStrings(currentChannelName));
        }

        private IEnumerable<string> GetStrings(string currentChannelName)
        {
            var channelADiffCount = Results.GroupBy(x => x.SM1Position).Count();
            var channelBDiffCount = Results.GroupBy(x => x.SM2Position).Count();
            var firstStepMotorExecuted = channelADiffCount > channelBDiffCount;
            var channelAName = firstStepMotorExecuted ? currentChannelName : CHANNEL_A;
            var channelBName = !firstStepMotorExecuted ? currentChannelName : CHANNEL_B;

            yield return String.Format("{0,-10:#######}    {1,-10:#######}    {2,-10:#######}",
                NM, channelAName, channelBName);
            foreach (var x in Results)
            {
                yield return String.Format("{0,-10}    {1,-10}    {2,-10}",
                    firstStepMotorExecuted ? x.SM1Position : x.SM2Position,
                    x.Data.ChannelA,
                    x.Data.ChannelB);
            }
        }
    }
}
