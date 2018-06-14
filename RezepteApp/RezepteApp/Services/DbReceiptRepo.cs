using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RezepteApp.DB;
using RezepteApp.Models;

namespace RezepteApp.Services
{
    public class DbReceiptRepo : IReceiptRepo
    {
        private readonly ReceiptContext _context;

        public DbReceiptRepo(ReceiptContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receipt>> FindReceiptsAsync(string searchTerm)
        {
            return await _context
                .Receipts
                .AsNoTracking()
                .Where(w => w.Title.Contains(searchTerm)
                    || w.Ingredient.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<IEnumerable<Receipt>> GetFavoritesAsync()
        {
            return await _context
                .Receipts
                .AsNoTracking()
                .Where(w => w.IsFavorit)
                .ToListAsync();
        }
    }
}
