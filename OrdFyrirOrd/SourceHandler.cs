using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;

namespace OrdFyrirOrd
{
    class SourceHandler
    {
        public string formatXml(XmlReader source, Source sourceType)
        {
            StringBuilder sb = new StringBuilder();
            if (sourceType == Source.Ordtidni)
            {
                source.MoveToContent();
                while (source.Read())
                {
					if (source.Value.Length > 1 && source.Value != "\"") {
						string line = source.Value;
						line = Regex.Replace(line, "\"", "");
						sb.Append(line + "\n");
					}
                }
            }
            else
            {
                throw new NotImplementedException("This source type is not supported by the SourceHandler. [Oni]");
            }
			//string outputString = removeCharacters(sb.ToString());
			return sb.ToString();
        }

		private string removeCharacters(string inpString)
		{
			//inpString = Regex.Replace(inpString, "\n", "");
			inpString = Regex.Replace(inpString, "\"", "");
			//inpString = Regex.Replace(inpString, "[\"]", "\n");
			return inpString;
		}
    }
}
