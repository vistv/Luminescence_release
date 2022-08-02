using Luminescence.Engine.Controllers.DimensionControllers;

namespace Luminescence.Engine.Models
{
    public class Results
    {
        public IDataDimension Data { get; set; }
        public float SM1Position { get; set; }
        public float SM2Position { get; set; }

        public Results(IDataDimension data, float sM1Position, float sM2Position)
        {
            this.Data = data;
            this.SM1Position = sM1Position;
            this.SM2Position = sM2Position;
        }
    }
}
