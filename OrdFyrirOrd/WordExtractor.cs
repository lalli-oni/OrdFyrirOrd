using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Threading.Tasks;
using System.Text;

namespace OrdFyrirOrd
{
	public class WordExtractor
	{
		public void Ordtidni(string fileName)
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
		public HashSet<string> Islex()
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
					if (!xmlReader.Value.Contains("\n"))
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
			Parallel.ForEach(sentenceList, (sentence) => {
				string[] splitString = sentence.Split(whitespace);
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
			});
			Console.WriteLine("Finished putting " + wordCounter + " words in the list");
			return wordList;
		}
	}
}

