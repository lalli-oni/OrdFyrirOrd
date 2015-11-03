using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace OrdFyrirOrd.Interfaces.Readers
{
    class XmlReaderWrapper : IReader
    {
        private XmlReader _xReader;

        public XmlReader xReader
        {
            get { return _xReader; }
            set { _xReader = value; }
        }

        public void MoveToContent()
        {
            throw new NotImplementedException();
        }

        public IReader Create(FileStream stream, XmlReaderSettings settings)
        {
            xReader = XmlReader.Create(stream, new XmlReaderSettings()
            {
                IgnoreComments = true,
                IgnoreWhitespace = true,
                IgnoreProcessingInstructions = true,
                DtdProcessing = DtdProcessing.Ignore
            });
            return this;
        }

        public IReader Create(string text, Source sourceType)
        {
            xReader = XmlReader.Create(text, new XmlReaderSettings()
            {
                IgnoreComments = true,
                IgnoreWhitespace = true,
                IgnoreProcessingInstructions = true,
                DtdProcessing = DtdProcessing.Ignore
            });
            return this;
        }

        public void FormatSource(Source sourceType)
        {
            StringBuilder sb = new StringBuilder();
            if (sourceType == Source.Ordtidni || sourceType == Source.GenericXml)
            {
                xReader.MoveToContent();
                while (xReader.Read())
                {
                    if (xReader.Value.Length > 1 && xReader.Value != "\"")
                    {
                        string line = xReader.Value;
                        line = Regex.Replace(line, "\"", "");
                        sb.Append(line + "\n");
                    }
                }
                string toRead = sb.ToString();
                StringReader sr = new StringReader(toRead);
                xReader = XmlReader.Create(sr, new XmlReaderSettings()
                {
                    IgnoreComments = true,
                    IgnoreWhitespace = true,
                    IgnoreProcessingInstructions = true,
                    DtdProcessing = DtdProcessing.Ignore
                });
            }
            else
            {
                throw new NotImplementedException("This source type is not supported by the SourceHandler. [Oni]");
            }
        }


        public void Create(JsonReader reader)
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            return xReader.Read();
        }

        public IReader GetReader()
        {
            return this;
        }
    }
}
