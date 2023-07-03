using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using MauiAppProba.Models;
using System.Net.Http.Headers;

namespace MauiAppProba
{
    internal class ApiWorker
    {
        public static HttpClient client = new HttpClient();

        static void Init()
        {
            client.BaseAddress = new Uri("https://www.googleapis.com/books/v1/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Book1> GetBookAsync(int startIndex, int maxResults)
        {
            Init();
            string response = await client.GetStringAsync($"volumes?q=flowers&startIndex={startIndex}&maxResults={maxResults}&fields=items(volumeInfo/title,volumeInfo/authors,volumeInfo/publishedDate,volumeInfo/description, volumeInfo/imageLinks/thumbnail, volumeInfo/categories)");
            //if (response.IsSuccessStatusCode)
            //{
            // book = await response.Content.ReadAsAsync<Book>();
            //}
            return JsonConvert.DeserializeObject<Book1>(response);
        }

    }
}
