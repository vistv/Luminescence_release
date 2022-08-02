using System.Collections.Generic;
using Luminescence.Engine.Managers.Settings;
using Luminescence.Engine.Models;

namespace Luminescence.Engine.Managers.Saver
{
    public interface IResultSaverManager
    {
        List<Results> Results { get; }
        IDimensionSettingsManager DimensionSettings { get; set; }
        void SaveData(string filePath);
    }
}