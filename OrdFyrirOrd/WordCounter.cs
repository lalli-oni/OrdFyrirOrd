using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OrdFyrirOrd
{
	/// <summary>
	/// Provides various counting functions to the word collections
	/// </summary>
	public class WordCounter
	{
        /// <summary>
        /// Goes through a word list, extracts the most frequent words in order.
        /// </summary>
        /// <returns>The used words.</returns>
        /// <param name="frequentWords">Frequent words.</param>
        /// <param name="numberOfRanks">Number of ranked words.</param>
        public Dictionary<string,int> MostUsedWords(Dictionary<string, int> frequentWords, int numberOfRanks)
		{
			int wordFrequencyCounter = frequentWords.Count;
			Dictionary<string, int> topWords = new Dictionary<string, int> ();
			while (wordFrequencyCounter > 0) {
				foreach (var wordPair in frequentWords) {
					if (wordPair.Value == wordFrequencyCounter) {
						topWords.Add(wordPair.Key, wordPair.Value);
					}
				}
				wordFrequencyCounter--;
			}

			#region write out results
			//foreach (var word in topWords) {
			//	Console.WriteLine (word);
			//}
			#endregion
			return topWords;
		}

        /// <summary>
        /// Adds words to the base json file.
        /// </summary>
        /// <param name="frequentWords">The list of words to add to the count</param>
        /// <param name="numberOfRanks">Number of words to add</param>
        public void AmmendFrequency(Dictionary<string, int> frequentWords, int numberOfRanks)
        {
            FileProcessor fileHandler = new FileProcessor();
            string jsonText = fileHandler.AccessJsonFile("wordList.txt");
            Dictionary<string, int> masterWordList = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonText);

            foreach (KeyValuePair<string, int> pair in frequentWords)
            {
                if (masterWordList.ContainsKey(pair.Key))
                {
                    masterWordList[pair.Key] = masterWordList[pair.Key] + pair.Value;
                }
                else
                {
                    masterWordList.Add(pair.Key, pair.Value);
                }
            }

            #region write out results
            //foreach (var word in topWords) {
            //	Console.WriteLine (word);
            //}
            #endregion
            masterWordList.SaveEnumerableJson("wordList.txt", FileMode.Open);
        }
    }
}

