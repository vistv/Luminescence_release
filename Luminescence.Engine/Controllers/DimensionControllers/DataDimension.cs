namespace Luminescence.Engine.Controllers.DimensionControllers
{
    public struct DataDimension : IDataDimension
    {
        public int ChannelA { get; private set; }
        public int ChannelB { get; private set; }

        public DataDimension(int channelA, int channelB)
        {
            this.ChannelA = channelA;
            this.ChannelB = channelB;
        }
    }
}
