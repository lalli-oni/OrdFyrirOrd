using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace OrdFyrirOrd
{
    /// <summary>
    /// Provides processing for sentences.
    /// </summary>
    class SentenceHandler
    {
        #region Split Methods
        /// <summary>
        /// Splits the sentence to words based on line returns and white space.
        /// Only for Json sources. The sourcehandler should be used to get json
        /// </summary>
        /// <param name="sentences">A List of sentences to extract words from</param>
        /// <returns>A list of words</returns>
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

        /// <summary>
        /// Reads a json formatted string and splits each line into sentences.
        /// </summary>
        /// <param name="jsonInput">The json string to split</param>
        /// <returns>List of sentences</returns>
	    public List<string> SplitToSentences(string jsonInput)
        {
            List<string> sentenceList = new List<string>();
            int sentenceCounter = 0;
            JsonTextReader reader = new JsonTextReader(new StringReader(jsonInput));
            while (reader.Read())
            {
                if (reader.Value.ToString().Length > 2)
                {
                    if (!reader.Value.ToString().Contains("\n"))
                    {
                        if (sentenceCounter > 0)
                        {
                            //TODO: Remove any ? and ' characters
                            StringBuilder sentenceBuilder = new StringBuilder(reader.Value.ToString());
                            sentenceBuilder.Replace("\"", "");
                            sentenceList.Add(sentenceBuilder.ToString());
                            //Console.WriteLine("Added word n." + sentenceCounter + ": " + xmlReader.Value);
                        }
                        sentenceCounter++;
                    }
                }
            }
            if (sentenceList.Count < 2)
            {
                throw new Exception("The supplied source has no more than 1 sentence");
            }
            Console.WriteLine("Finished putting " + sentenceCounter + " sentences in the list");
            return sentenceList;
        }
        #endregion
    }
}
