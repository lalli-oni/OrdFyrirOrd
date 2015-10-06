using System;
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

            //Output Managers
            #endregion

            //Opens up a file dialog to select a xml file. Returns an XmlDocument
            XmlDocument xmlDoc = fileProc.AccessXmlFile(fileProc.SelectXmlFile());
            //Formats the source data into a standardized json for us to work with
            string formattedSource = sourceHandler.xmlWrangler(xmlDoc);
            //Splits the source data into sentences
            List<string> sentences = sh.SplitToSentences(formattedSource);
            //Splits the sentences into words with frequency
            Dictionary<string, int> frequencyWords = wh.SplitToWords(sentences);
            //Saves the data to a json formatted .txt file
            frequencyWords.SaveEnumerableJson(Console.ReadLine(), FileMode.Create);

            Console.ReadLine();
        }
    }
}
