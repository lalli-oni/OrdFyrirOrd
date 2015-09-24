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

namespace OrdFyrirOrd
{
    class Program
    {
		private static WordExtractor wordGetter;
		private static WordCounter wordCount;
        static void Main(string[] args)
        {
			wordGetter = new WordExtractor();
			wordCount = new WordCounter();
			HashSet<string> wordDictionary = wordGetter.Islex();
			Dictionary<string,int> topListWords = wordCount.MostUsedWords (wordGetter.wordFrequency);
			foreach (var word in topListWords) {
				Console.WriteLine (word);
			}
			Console.WriteLine ("Total words: " + wordDictionary.Count);
            Console.ReadLine();
        }
    }
}
