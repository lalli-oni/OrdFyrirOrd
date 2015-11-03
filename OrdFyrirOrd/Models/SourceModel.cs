using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using OrdFyrirOrd.Interfaces;
using OrdFyrirOrd.Interfaces.Readers;

namespace OrdFyrirOrd.Models
{
    class SourceModel
    {
        #region Fields
        #region Variables
        private Source _sourceType;
        private string _sourceData;
        private int _sourceSize;
        private IReader _sourceReader;

        #endregion
        #region Properties
        public Source SourceType
        {
            get { return _sourceType; }
            set { _sourceType = value; }
        }

        public string SourceData
        {
            get { return _sourceData; }
            set { _sourceData = value; }
        }

        public int SourceSize
        {
            get { return _sourceSize; }
            set { _sourceSize = value; }
        }

        public IReader SourceReader
        {
            get { return _sourceReader; }
            set { _sourceReader = value; }
        }

        #endregion
        #endregion
        public SourceModel(IReader reader, Source sourceType)
        {
            SourceReader = reader;
            SourceType = sourceType;
        }

        public SourceModel(string sourceData, Source sourceType)
        {
            XmlReaderWrapper wrapper = new XmlReaderWrapper();
            wrapper.Create(sourceData, sourceType);
            wrapper.FormatSource(sourceType);
            SourceReader = wrapper;
        }

    }
}
