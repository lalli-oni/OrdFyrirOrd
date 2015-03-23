using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OFOWebAPI;

namespace OrdFyrirOrd
{
    static class WebAPIClient
    {
        private static readonly String _serverUrl = "http://localhost:16858";
        static private HttpClient webClient = new HttpClient(new HttpClientHandler());


        //static WebAPIClient()
        //{
        //    HttpClient webClient = new HttpClient();
        //    webClient.BaseAddress = new Uri(_serverUrl);
        //}


        public static async Task<IEnumerable<Word>> GetWords()
        {
                try
                {
                    var jsonContent = await webClient.GetAsync("api/persons");
                    if (jsonContent.IsSuccessStatusCode)
                    {
                        var result = jsonContent.Content.ReadAsAsync<IEnumerable<Word>>().Result;
                        return result.ToList();
                    }
                    return null;
                }
                catch (Exception)
                {
                   throw;
                }
            return new List<Word>();
        }

        public static async void DeleteWord(int wordIdToDelete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_serverUrl);
                client.DefaultRequestHeaders.Clear();  
                try
                {
                    await client.DeleteAsync("api/words/" + wordIdToDelete);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static async void AddWord(string word)
        {
            if (webClient.BaseAddress == null)
            {
                webClient.BaseAddress = new Uri(_serverUrl);
            }
            Word wordToAdd = new Word();
            wordToAdd.Word1 = word;
                try
                {
                    webClient.PostAsJsonAsync("api/words", wordToAdd);
                    Console.WriteLine(word + " added!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n Press any key to continue...");
                    Console.ReadLine();
                }
        }

        public static async void EditWord(Word wordToEdit)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    await client.PutAsJsonAsync<Word>("api/words/"+ wordToEdit.WordId, wordToEdit);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
