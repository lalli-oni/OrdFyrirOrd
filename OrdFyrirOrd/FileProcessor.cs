using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace OrdFyrirOrd
{
    /// <summary>
    /// Access files and returns streams.
    /// </summary>
    public class FileProcessor
	{
        /// <summary>
        /// Opens up a dialog to select an XmlFile
        /// </summary>
        /// <returns>The path for the selected XmlFile</returns>
        public string SelectXmlFile()
	    {
            OpenFileDialog selectFileDialog = new OpenFileDialog();
            selectFileDialog.DefaultExt = "xml";
            selectFileDialog.Filter = "xml files (*.xml)|*.xml";
            selectFileDialog.InitialDirectory = "";
	        if (selectFileDialog.ShowDialog() == DialogResult.OK)
	        {
	            return selectFileDialog.FileName;
	        }
            return null;
	    }

        /// <summary>
        /// Accesses a file at a certain path
        /// </summary>
        /// <returns>The stream to read the file</returns>
        /// <param name="filePath">File path.</param>
        public XmlTextReader AccessFile(string filePath)
		{
			FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            XmlTextReader xmlReader = new XmlTextReader(fs);
            xmlReader.XmlResolver = null;
			return xmlReader;
		}
	}
}

