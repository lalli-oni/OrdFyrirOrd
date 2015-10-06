using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OrdFyrirOrd
{
    class SourceHandler
    {
        private char[] ignoredChars;

        public SourceHandler()
        {
            ignoredChars = new char[] { '\r','\n', ' ', '\"'};
        }

        public string formatXml(XmlReader source, Source sourceType)
        {
            StringBuilder sb = new StringBuilder();
            if (sourceType == Source.Ordtidni)
            {
                source.MoveToContent();
                while (source.Read())
                {
                    try
                    {
                        if (source.HasValue)
                        {
                            if (source.Value.Length > 0)
                            {
                                foreach (char ignoredChar in ignoredChars)
                                {
                                    source.Value.Replace(ignoredChar, '\0');
                                }
                                sb.AppendLine(source.Value);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
            else
            {
                throw new NotImplementedException("This source type is not supported by the SourceHandler. [Oni]");
            }
            return sb.ToString();
        }
    }
}
