using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using OrdFyrirOrd.Models;

namespace OrdFyrirOrd
{
    /// <summary>
    /// Retrieves different sources and formats them for processing.
    /// </summary>
    class SourceHandler
    {
		private string RemoveUnwantedCharacters(string inpString)
		{
			//inpString = Regex.Replace(inpString, "\n", "");
			inpString = Regex.Replace(inpString, "\"", "");
			//inpString = Regex.Replace(inpString, "[\"]", "\n");
			return inpString;
		}
    }
}
