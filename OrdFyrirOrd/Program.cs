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
using System.Windows.Forms;

namespace OrdFyrirOrd
{
    class Program
    {
		private static WordExtractor wordGetter;
		private static WordCounter wordCount;

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
			wordGetter = new WordExtractor();
			wordCount = new WordCounter();

			#region Select a file
			OpenFileDialog selectFileDialog = new OpenFileDialog ();
			selectFileDialog.DefaultExt = "xml";
			selectFileDialog.Filter = "xml files (*.xml)|*.xml";
			selectFileDialog.InitialDirectory = "";

			if (selectFileDialog.ShowDialog() == DialogResult.OK)
			{
				DialogResult fileResult = selectFileDialog.ShowDialog ();
				string openFileName = selectFileDialog.FileName;
			}
			#endregion

			HashSet<string> wordDictionary = wordGetter.Islex();
			Dictionary<string,int> topListWords = wordCount.MostUsedWords (wordGetter.wordFrequency);
			foreach (var word in topListWords) {
				Console.WriteLine (word);
			}
			Console.WriteLine ("Total words: " + wordDictionary.Count);
            Console.ReadLine();
        }
    }
}
