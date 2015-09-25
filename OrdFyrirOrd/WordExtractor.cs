using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Threading.Tasks;
using System.Text;
using System.Collections;

namespace OrdFyrirOrd
{
	/// <summary>
	/// Extracts words from multiple sources
	/// </summary>
	public class WordExtractor
	{
		/// <summary>
		/// Uses the XmlReader to read through and split it down stream to sentences
		/// and then to word. When it processes each word it checks
		/// how often it has occured and adds it to +wordFrequency.
		/// </summary>
		/// <returns>A quickly iterative datacollection of every word from that file</returns>
		public Dictionary<string, int> processXml(XmlReader xmlStreamReader)
		{

		    List<string> sentences = SplitToSentences(xmlStreamReader);
		    Dictionary<string, int> wordList = SplitToWords(sentences);
			return wordList;
		}

        /// <summary>
        /// Reads the stream and splits each line into sentences.
        /// </summary>
        /// <param name="xmlStreamReader">The text stream to split</param>
        /// <returns>List of sentences</returns>
	    public List<string> SplitToSentences(XmlReader xmlStreamReader)
        {
            List<string> sentenceList = new List<string>();
            int sentenceCounter = 0;
            while (xmlStreamReader.Read())
            {
                if (xmlStreamReader.Value.Length > 2)
                {
                    if (!xmlStreamReader.Value.Contains("\n"))
                    {
                        if (sentenceCounter > 0)
                        {
                            //TODO: Remove any ? and ' characters
                            StringBuilder sentenceBuilder = new StringBuilder(xmlStreamReader.Value);
                            sentenceBuilder.Replace("\"", "");
                            sentenceList.Add(sentenceBuilder.ToString());
                            //Console.WriteLine("Added word n." + sentenceCounter + ": " + xmlReader.Value);
                        }
                        sentenceCounter++;
                    }
                }
            }
            Console.WriteLine("Finished putting " + sentenceCounter + " sentences in the list");
	        return sentenceList;
        }

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

