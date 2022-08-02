using System;
using System.IO;
using System.Net.Mime;
using System.Xml;

namespace Luminescence.Engine.Repositories
{
    public abstract class Repository
    {
        #region Fields

        private readonly string _fullName;
        private readonly XmlDocument _xmlDocument = new XmlDocument();
        private readonly byte _theFindedInXmlFileNumber;
        private readonly object _locked = new object();

        #endregion

        #region Constructors

        protected Repository(string filePath, string fileName, byte theFindedInXmlNumber = 0)
        {
            _fullName = String.IsNullOrEmpty(filePath) ? fileName : Path.GetFullPath(Path.Combine(filePath, fileName).Replace("/", @"\"));
            _theFindedInXmlFileNumber = theFindedInXmlNumber;
            lock (_locked)
            {
                _xmlDocument.Load(_fullName);
            }
        }

        #endregion

        #region ProtectedMethods

        protected void SaveValue(string tagName, string valueStr)
        {
            lock (_locked)
            {
                _xmlDocument.GetElementsByTagName(tagName)[_theFindedInXmlFileNumber].InnerText = valueStr;
                _xmlDocument.Save(_fullName);
            }
        }

        protected string GetValue(string tagName)
        {
            lock (_locked)
            {
                return _xmlDocument.GetElementsByTagName(tagName)[_theFindedInXmlFileNumber].InnerText;
            }
        }

        #endregion
    }
}
