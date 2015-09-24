using System;
using System.IO;
using System.Xml;

namespace OrdFyrirOrd
{
	/// <summary>
	/// Access files and returns streams.
	/// </summary>
	public class FileProcessor
	{

		/// <summary>
		/// Accesses a file at a certain path
		/// </summary>
		/// <returns>The stream to read the file</returns>
		/// <param name="filePath">File path.</param>
		public XmlTextReader AccessFile(string filePath)
		{
			FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			XmlTextReader xmlReader = new XmlTextReader (fs);
			xmlReader.XmlResolver = null;
			return xmlReader;
		}
	}
}

