using Microsoft.EntityFrameworkCore;
using RezepteApp.DB.Mappings;
using RezepteApp.Models;
using RezepteApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RezepteApp.DB
{
    public class ReceiptContext : DbContext
    {
        private readonly string _dbPath;

        public ReceiptContext(IPathService pathService)
        {
            _dbPath = pathService.GetDbPath("receipts.db");
        }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konvetionen überschreiben
            modelBuilder.ApplyConfiguration(new ReceiptMapping());
        }
    }
}
