using RezepteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RezepteApp.Services
{
    public interface IReceiptRepo
    {
        Task<IEnumerable<Receipt>> GetFavoritesAsync();

        Task<IEnumerable<Receipt>> FindReceiptsAsync(string searchTerm);
        Task<Receipt> GetReceiptByIdAsync(int id);
    }
}
