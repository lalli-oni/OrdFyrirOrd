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
        private static PersistenceHandler persHandler;

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        [STAThread]
        static void Main(string[] args)
        {
			wordGetter = new WordExtractor();
			wordCount = new WordCounter();
			fileProc = new FileProcessor();
            webGetter = new WebCrawler();
            persHandler = new PersistenceHandler();

            //webGetter.GetSiteText(WebPages.Mbl , "http://www.mbl.is/frettir/mest_lesid/", 20);

            string filePath = fileProc.SelectXmlFile();
            Dictionary<string, int>  wordDictionary = wordGetter.processXml(fileProc.AccessFile(filePath));
            Dictionary<string, int> sortedWordDictionary = wordCount.MostUsedWords(wordDictionary, wordDictionary.Count);
            persHandler.SaveToJson(sortedWordDictionary);
            Console.WriteLine("Total words: " + wordDictionary.Count);


            //HashSet<string> wordDictionary = wordGetter.Islex();
            Console.ReadLine();
        }
    }
}
