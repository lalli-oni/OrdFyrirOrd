﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Windows.Forms;
using OrdFyrirOrd.Interfaces;
using OrdFyrirOrd.Models;

namespace OrdFyrirOrd
{
    class Program
    {
		private static FileProcessor fileProc;
        private static WebCrawler webGetter;

        private static SourceHandler sourceHandler;

        private static WordHandler wh;
        private static SentenceHandler sh;

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        [STAThread]
        static void Main(string[] args)
        {
            #region Instanciations
            //Source Managers
            fileProc = new FileProcessor();
            webGetter = new WebCrawler();
            sourceHandler = new SourceHandler();

            //Data Managers
            sh = new SentenceHandler();
            wh = new WordHandler();

            #region Model impl.
            IReader xmlReader = fileProc.AccessXmlFile(@"C:\Users\Lalli-Oni\Documents\Visual Studio 2015\Projects\OrdFyrirOrd\OrdFyrirOrd\bin\Debug/islex_final smaller.xml");
            SourceModel source = new SourceModel(xmlReader, Source.GenericXml);
            source.SourceReader.FormatSource(source.SourceType);
            SentenceModel sentences = new SentenceModel(source);
            #endregion

            #region Non Model Impl.
            //Output Managers
            #endregion
            //Opens up a file dialog to select a xml file. Returns an XmlDocument
            //XmlReader sourceReader = fileProc.AccessXmlFile(@"C:\Users\Lalli-Oni\Documents\Visual Studio 2015\Projects\OrdFyrirOrd\OrdFyrirOrd\bin\Debug/islex_final smaller.xml");
            //Formats the source data into a standardized json for us to work with
            //string formattedSource = sourceHandler.formatXml(sourceReader, Source.Ordtidni);
			//add each line into a list 
			//List<string> lines = sh.SplitLines(formattedSource);
            //Splits the source data into sentences
            //List<string> sentences = sh.SplitToSentences(formattedSource);
            //Splits the sentences into words with frequency
            //Dictionary<string, int> frequencyWords = wh.SplitToWords(sentences);
            //Saves the data to a json formatted .txt file
            //frequencyWords.SaveEnumerableJson(Console.ReadLine(), FileMode.Create);
            #endregion

            Console.ReadLine();
        }
    }
}
