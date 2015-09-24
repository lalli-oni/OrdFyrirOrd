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
        static void Main(string[] args)
        {
			wordGetter = new WordExtractor();
            int dbNumber = 0;
			HashSet<string> wordDictionary = wordGetter.Islex();
            Console.ReadLine();
            foreach (string word in wordDictionary)
            {
                dbNumber++;
                Console.WriteLine("Adding word nr." + dbNumber + " of 39157/168414");
            }
            Console.ReadLine();
        }
    }
}
