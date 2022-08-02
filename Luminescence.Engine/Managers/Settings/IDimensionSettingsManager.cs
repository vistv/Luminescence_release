using System;

namespace Luminescence.Engine.Managers.Settings
{
    public interface IDimensionSettingsManager
    {
        event EventHandler<EventArgs> BeginPositionChanged;
        event EventHandler<EventArgs> EndPositionChanged;
        event EventHandler<EventArgs> DimensionDelaySecChanged;
        event EventHandler<EventArgs> DimensionStepNmChanged;

        float BeginPosition { get; set; }
        float EndPosition { get; set; }
        byte DimensionDelaySec { get; set; }
        float DimensionStepNm { get; set; }
    }
}