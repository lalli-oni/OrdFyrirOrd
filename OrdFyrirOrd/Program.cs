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
		private static WordExtractor wordGetter;
		private static WordCounter wordCount;
		private static FileProcessor fileProc;
        private static WebCrawler webGetter;
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

            //Data Managers
            sh = new SentenceHandler();
            wh = new WordHandler();

            //Output Managers
            #endregion

            //Opens up a file dialog to select a xml file.
            XmlTextReader xmlReader = fileProc.AccessXmlFile(fileProc.SelectXmlFile());
            //Splits the source into sentences (data)
            List<string> sentences = sh.SplitToSentences(xmlReader);
            //Splits the sentences into words with frequency (data)
            Dictionary<string, int> frequencyWords = wh.SplitToWords(sentences);
            //Saves the data to a json formatted .txt file
            frequencyWords.SaveEnumerableJson(Console.ReadLine(), FileMode.Create);

            Console.ReadLine();
        }
    }
}
