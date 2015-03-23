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
using OFOWebAPI;

namespace OrdFyrirOrd
{
    class Program
    {
        static void Main(string[] args)
        {
            int dbNumber = 0;
            HashSet<string> wordDictionary = Islex();
            Console.ReadLine();
            foreach (string word in wordDictionary)
            {
                dbNumber++;
                Console.WriteLine("Adding word nr." + dbNumber + " of 39157/168414");
                WebAPIClient.AddWord(word);
            }
            Console.ReadLine();
        }

        //TODO: Refactor to a handler (Strategy?)
        private static void Ordtidni(string fileName)
        {
            FileStream fs = new FileStream(@"Ordtidni\" + fileName, FileMode.Open, FileAccess.Read);
            List<string> sentenceList = new List<string>();
            List<string> wordList = new List<string>();
            XmlTextReader xmlReader = new XmlTextReader(fs);
            int sentenceCounter = 0;
            int wordCounter = 0;
            while (xmlReader.Read())
            {
                xmlReader.ReadToDescendant("title");
                for (int i = 0; i < xmlReader.AttributeCount; i++)
                {
                    sentenceList.Add(xmlReader.Value);
                }
            }
        }

        //TODO: Refactor to a handler (Strategy?)
        private static HashSet<string> Islex()
        {
            FileStream fs = new FileStream("islex_final.xml", FileMode.Open, FileAccess.Read);
            HashSet<string> sentenceList = new HashSet<string>();
            HashSet<string> wordList = new HashSet<string>();
            XmlTextReader xmlReader = new XmlTextReader(fs);
            xmlReader.XmlResolver = null;
            int sentenceCounter = 0;
            int wordCounter = 0;
            char[] whitespace = new char[] {' ', '\t'};
            while (xmlReader.Read())
            {
                //TODO: Clean up checks
                if (xmlReader.Value.Length > 2)
                {
                    if (xmlReader.Value.Contains("\n") == false)
                    {
                        if (sentenceCounter > 0)
                        {
                            //TODO: Remove any ? and ' characters
                            StringBuilder sentenceBuilder = new StringBuilder(xmlReader.Value);
                            sentenceBuilder.Replace("\"", "");
                            sentenceList.Add(sentenceBuilder.ToString());
                            Console.WriteLine("Added word n." + sentenceCounter + ": " + xmlReader.Value);
                        }
                        sentenceCounter++;
                    }
                }
            }
            Console.WriteLine("Finished putting " + sentenceCounter + " sentences in the list");
            Console.ReadLine();
            foreach (string currSentence in sentenceList)
            {
                string[] splitString = currSentence.Split(whitespace);
                foreach (string word in splitString)
                {
                    if (!wordList.Contains(word))
                    {
                        wordList.Add(word);
                        wordCounter++;
                        Console.WriteLine("Added word n." + wordCounter + ": " + word);
                    }
                    else
                    {
                        Console.WriteLine("Found duplicate of word: " + word);
                    }
                }
            }
            Console.WriteLine("Finished putting " + wordCounter + " words in the list");
            return wordList;
        }
    }
}
