using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace OrdFyrirOrd
{
    /// <summary>
    /// Access file sources and returns content as json.
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
        /// Accesses a xml file at a given path
        /// </summary>
        /// <returns>A json string</returns>
        /// <param name="filePath">File path.</param>
        public XmlReader AccessXmlFile(string fileName)
		{
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            XmlReader xr = XmlReader.Create(fs, new XmlReaderSettings()
            {
                IgnoreComments = true,
                IgnoreWhitespace = true,
                IgnoreProcessingInstructions = true,
                DtdProcessing = DtdProcessing.Ignore
            });
			return xr;
		}

        /// <summary>
        /// Accesses a json file at a given path
        /// </summary>
        /// <returns>A json formatted string</returns>
        /// <param name="filePath">File path.</param>
        public string AccessJsonFile(string fileName)
        {
            //string path = Directory.GetCurrentDirectory();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            string jsonString;
            using (StreamReader sr = new StreamReader(fs))
            {
                jsonString = sr.ReadToEnd();
            }
            return jsonString;
        }
    }
}

