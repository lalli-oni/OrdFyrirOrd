using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            List<string> sentences = SplitToSentences(xmlStreamReader);
            return sentences;
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
    }
}
