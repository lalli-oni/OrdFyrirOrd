using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OrdFyrirOrd
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("islex_final.xml", FileMode.Open, FileAccess.Read);
            List<string> sentenceList = new List<string>();
            List<string> wordList = new List<string>();
            XmlTextReader xmlReader = new XmlTextReader(fs);
            xmlReader.XmlResolver = null;
            int sentenceCounter = 0;
            int wordCounter = 0;
            char[] whitespace = new char[] { ' ', '\t' };
            while (xmlReader.Read())
            {
                if (xmlReader.Value.Length > 5)
                {
                    if (xmlReader.Value.Contains("\n") == false)
                    {
                        sentenceCounter++;
                        Console.WriteLine("Added word n."+ sentenceCounter + ": " + xmlReader.Value);
                        sentenceList.Add(xmlReader.Value);
                    }
                }
            }
            sentenceList.Remove("version");
            Console.WriteLine("Finished putting " + sentenceCounter + " sentences in the list");
            Console.ReadLine();
            foreach (string sentence in sentenceList)
            {
                string[] splitString = sentence.Split(whitespace);
                foreach (string word in splitString)
                {
                    wordCounter++;
                    wordList.Add(word);
                    Console.WriteLine("Added word n." + wordCounter + ": " + word);
                }
            }
            Console.WriteLine("Finished putting " + wordCounter + " words in the list");
            Console.ReadLine();
        }
    }
}
