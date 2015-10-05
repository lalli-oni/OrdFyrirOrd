﻿using System;
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
        /// Accesses a xml file at a certain path
        /// </summary>
        /// <returns>The stream to read the file</returns>
        /// <param name="filePath">File path.</param>
        public XmlTextReader AccessXmlFile(string fileName)
		{
            string path = Directory.GetCurrentDirectory();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            XmlTextReader xmlReader = new XmlTextReader(fs);
            xmlReader.XmlResolver = null;
			return xmlReader;
		}

        /// <summary>
        /// Accesses a json file at a certain path
        /// </summary>
        /// <returns>A json formatted string</returns>
        /// <param name="filePath">File path.</param>
        public string AccessJsonFile(string fileName)
        {
            string path = Directory.GetCurrentDirectory();
            FileStream fs = new FileStream(path + "/output/" + fileName, FileMode.Open, FileAccess.ReadWrite);
            string fileText;
            using (StreamReader sr = new StreamReader(fs))
            {
                fileText = sr.ReadToEnd();
            }
            return fileText;
        }
    }
}

