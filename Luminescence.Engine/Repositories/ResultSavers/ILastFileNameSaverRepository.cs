using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luminescence.Engine.Repositories.ResultSavers
{
    public interface ILastFileNameSaverRepository
        : IResultSaverRepository
    {
        string LastFileName { get; set; }
    }
}
