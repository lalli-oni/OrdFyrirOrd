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
            Dictionary<string, int>  wordDictionary = wordGetter.processXml(fileProc.AccessXmlFile(filePath));
            Dictionary<string, int> sortedWordDictionary = wordCount.MostUsedWords(wordDictionary, wordDictionary.Count);
            persHandler.SaveToJson(sortedWordDictionary);
            Console.WriteLine("Total words: " + wordDictionary.Count);


            Dictionary<string, int> wordDictionary2 = wordGetter.processXml(fileProc.AccessXmlFile(@"C:\Users\lalli\Documents\Visual Studio 2015\Projects\OrdFyrirOrd\Dictionaries\islex_final.xml"));
            Dictionary<string, int> sortedWordDictionary2 = wordCount.MostUsedWords(wordDictionary2, wordDictionary2.Count);
            wordCount.AmmendFrequency(sortedWordDictionary2, sortedWordDictionary2.Count);


            //HashSet<string> wordDictionary = wordGetter.Islex();
            Console.ReadLine();
        }
    }
}
