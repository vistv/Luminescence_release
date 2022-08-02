using Luminescence.Engine.Repositories.ResultSavers;

namespace Luminescence.Engine.Managers.Saver
{
    public interface ICustomFileNameSaverManager
        : IResultSaverManager
    {
        string LastFileName { get; set; }
    }
}
