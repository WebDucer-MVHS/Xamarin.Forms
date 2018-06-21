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

        public async Task<IEnumerable<Receipt>> GetFavoritesAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1.5));

            return new List<Receipt>
            {
                new Receipt
                {
                    Title = "Rezept 1",
                    IsFavorit = true
                },
                new Receipt
                {
                    Title = "Rezept 2",
                    IsFavorit = true
                },
                new Receipt
                {
                    Title = "Rezept 3",
                    IsFavorit = true
                },
                new Receipt
                {
                    Title = "Rezept 4",
                    IsFavorit = true
                }
            };
        }

        public Task<Receipt> GetReceiptByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
