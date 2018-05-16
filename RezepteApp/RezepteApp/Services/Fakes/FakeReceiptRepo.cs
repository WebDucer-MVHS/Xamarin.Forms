using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RezepteApp.Models;

namespace RezepteApp.Services.Fakes
{
    public class FakeReceiptRepo : IReceiptRepo
    {
        public async Task<IEnumerable<Receipt>> FindReceiptsAsync(string searchTerm)
        {
            // Bearbeitung simulieren
            await Task.Delay(TimeSpan.FromSeconds(2));

            return new []
            {
                new Receipt
                {
                    Title = "Gefunden",
                    IsFavorit = false
                }
            };
        }

        public Task<IEnumerable<Receipt>> GetFavoritesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
