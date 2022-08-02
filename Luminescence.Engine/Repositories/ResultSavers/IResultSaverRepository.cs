using System.Collections.Generic;

namespace Luminescence.Engine.Repositories.ResultSavers
{
    public interface IResultSaverRepository
    {
        void SaveResult(string filePath, IEnumerable<string> values);
    }
}