namespace Luminescence.Engine.Repositories.Settings.DimensionSettings
{
    public interface IDimensionRepository
    {
        byte DelaySec { get; set; }
        float BeginWavelength { get; set; }
        float EndWavelength { get; set; }
        float StepNms { get; set; }
    }
}
