using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdFyrirOrd
{
    class WordHandler
    {
        public Dictionary<string, int> SplitToWords(List<string> sentences)
        {
            int wordCounter = 0;
            Dictionary<string, int> wordList = new Dictionary<string, int>();
            char[] whitespace = new char[] { ' ', '\t' };
            foreach (var sentence in sentences)
            {
                string[] splitString = sentence.Split(whitespace);
                foreach (string word in splitString)
                {
                    if (!wordList.ContainsKey(word))
                    {
                        wordList.Add(word, 1);
                        wordCounter++;
                        //Console.WriteLine("Added word n." + wordCounter + ": " + word);
                    }
                    else
                    {
                        wordList[word]++;
                        //Console.WriteLine("Found duplicate of word: " + word);
                    }
                }
            }
            Console.WriteLine("Finished putting " + wordCounter + " unique words in the list");
            return wordList;
        }
    }
}
