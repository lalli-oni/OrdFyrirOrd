using System;
using System.Collections.Generic;

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
	}
}

