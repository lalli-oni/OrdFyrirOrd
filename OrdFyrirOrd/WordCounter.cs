using System;
using System.Collections.Generic;

namespace OrdFyrirOrd
{
	public class WordCounter
	{
		public Dictionary<string,int> MostUsedWords(Dictionary<string, int> frequentWords)
		{
			int wordFrequencyCounter = frequentWords.Count;
			//Only works if there are more than 10 different words duplicated.
			Dictionary<string, int> topWords = new Dictionary<string, int> ();
			while (topWords.Count < 10) {
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

