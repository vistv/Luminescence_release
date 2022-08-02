using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luminescence.Engine.Repositories.ResultSavers
{
    public class LastFileNameSaverRepository:
        ResultSaverRepository,
        ILastFileNameSaverRepository
    {
        private const string LAST_FILE_NAME = "lastFileName";

        public LastFileNameSaverRepository(string confFilePath, string confFileName)
            : base(confFilePath, confFileName)
        {
        }

        public string LastFileName
        {
            get => GetValue(LAST_FILE_NAME);
            set => SaveValue(LAST_FILE_NAME, value);
        }
    }
}
