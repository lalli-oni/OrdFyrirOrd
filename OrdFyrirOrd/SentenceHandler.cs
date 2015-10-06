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
    class SentenceHandler
    {
        /// <summary>
		/// Uses the XmlReader to read through and split it down stream to sentences
		/// and then to word. When it processes each word it checks
		/// how often it has occured and adds it to +wordFrequency.
		/// </summary>
		/// <returns>All sentences from the xml stream</returns>
		public List<string> processXml(XmlReader xmlStreamReader)
        {
            throw new NotImplementedException("This has been moved to FileProcessor and SourceHandler");
            //List<string> sentences = SplitToSentences(xmlStreamReader);
            //return sentences;
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
            Console.WriteLine("Finished putting " + sentenceCounter + " sentences in the list");
            return sentenceList;
        }
    }
}
