using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RezepteApp.Models;

namespace RezepteApp.Services
{
    public class ChefkochApiService : IApiService
    {
        private HttpClient _client;

        public ChefkochApiService()
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromMinutes(1);
            _client.MaxResponseContentBufferSize = 1024 * 256;
        }

        public async Task<IEnumerable<ApiReceipt>> SearchReceiptsAsync(string searchTerm)
        {
            // Uri zum Suchen erstellen
            var uri = new Uri($"https://www.chefkoch.de/api/1.1/api-recipe-search.php?Suchbegriff={searchTerm}&limit=100");

            // Daten abfragen
            var response = await _client.GetAsync(uri);

            // Prüfen, ob alles OK ist
            if (response.IsSuccessStatusCode)
            {
                // Inahalt auslesen
                var content = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert
                    .DeserializeObject<ReceiptResult>(content).result;
            }

            return new ApiReceipt[0];
        }
    }
}
