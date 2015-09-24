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
		//The field that holds every word (Key) that appears more than once and the number of times it appears (Value).
		public Dictionary <string, int> wordFrequency;

		/// <summary>
		/// Reads the file corresponding to the given filename in Ordtidni folder
		/// </summary>
		/// <param name="fileName">File name.</param>
		public void Ordtidni(string fileName)
		{
			FileStream fs = new FileStream(@"Ordtidni\" + fileName, FileMode.Open, FileAccess.Read);
			List<string> sentenceList = new List<string>();
			XmlTextReader xmlReader = new XmlTextReader(fs);
			while (xmlReader.Read())
			{
				xmlReader.ReadToDescendant("title");
				for (int i = 0; i < xmlReader.AttributeCount; i++)
				{
					sentenceList.Add(xmlReader.Value);
				}
			}
		}

		/// <summary>
		/// Reads the Islex xml file that is included in the project folder
		/// </summary>
		/// <returns>A quickly iterative datacollection of every word from that file</returns>
		public HashSet<string> Islex()
		{
			wordFrequency = new Dictionary <string, int>();
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
				if (xmlReader.Value.Length > 2)
				{
					if (!xmlReader.Value.Contains("\n"))
					{
						if (sentenceCounter > 0)
						{
							//TODO: Remove any ? and ' characters
							StringBuilder sentenceBuilder = new StringBuilder(xmlReader.Value);
							sentenceBuilder.Replace("\"", "");
							sentenceList.Add(sentenceBuilder.ToString());
							//Console.WriteLine("Added word n." + sentenceCounter + ": " + xmlReader.Value);
						}
						sentenceCounter++;
					}
				}
			}
			Console.WriteLine("Finished putting " + sentenceCounter + " sentences in the list");
			Console.ReadLine();

			foreach (var sentence in sentenceList) {
				string[] splitString = sentence.Split(whitespace);
				foreach (string word in splitString)
				{
					if (!wordList.Contains(word))
					{
						wordList.Add(word);
						wordCounter++;
						//Console.WriteLine("Added word n." + wordCounter + ": " + word);
					}
					else
					{
						try {
							wordFrequency.Add(word,2);
						} catch (Exception) {
							wordFrequency[word]++;
						}
						//Console.WriteLine("Found duplicate of word: " + word);
					}
				}
			}

			Console.WriteLine("Finished putting " + wordCounter + " words in the list");

			return wordList;
		}
	}
}

