using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luminescence.Engine.Repositories.Settings;

namespace Luminescence.Engine.Repositories.ResultSavers
{
    public class ResultSaverRepository:
        Repository,
        IResultSaverRepository
    {
        #region Consts

        private const string EXTENSION = "extension";
        private const string ENCODING = "encoding";
        private const string APPEND_TO_EXIST_FILE = "appendToExistFile";

        #endregion

        #region Ctors

        public ResultSaverRepository(string confFilePath, string confFileName)
            : base(confFilePath, confFileName)
        {
        }

        #endregion

        #region Methods

        public void SaveResult(string filePath, IEnumerable<string> values)
        {
            var fileToWrite = CreatFile(GetFullPath(filePath));
            
            SaveToFile(fileToWrite, values);

            fileToWrite.Close();
        }

        #endregion

        #region Helpers

        private string GetFullPath(string filePath)
        {
            return string.Concat(filePath.Split('.')[0], '.', base.GetValue(EXTENSION));
        }

        private StreamWriter CreatFile(string fullFilePath)
        {
            return new StreamWriter(fullFilePath, bool.Parse(base.GetValue(APPEND_TO_EXIST_FILE)), Encoding.GetEncoding(base.GetValue(ENCODING)));
        }

        private void SaveToFile(StreamWriter writer, IEnumerable<string> values)
        {
            foreach (var x in values)
            {
                writer.WriteLine(x);
            }
        }

        #endregion
    }
}
