using Microsoft.EntityFrameworkCore;
using RezepteApp.DB.Mappings;
using RezepteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RezepteApp.DB
{
    public class ReceiptContext : DbContext
    {
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Dateiname.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konvetionen überschreiben
            modelBuilder.ApplyConfiguration(new ReceiptMapping());
        }
    }
}
