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
        public string formatXml(XmlReader source, Source sourceType)
        {
            StringBuilder sb = new StringBuilder();
            if (sourceType == Source.Ordtidni)
            {
                while (source.Read())
                {
                    try
                    {
                        if (source.HasValue)
                        {
                            if (source.Value.Length > 0)
                            {
                                sb.AppendLine(source.Value);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        source.Skip();
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
