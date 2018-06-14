using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RezepteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RezepteApp.DB.Mappings
{
    public class ReceiptMapping : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            // Tabelle
            builder.ToTable("receipts");

            // Schlüsselspalte
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnName("_id")
                .ValueGeneratedOnAdd();

            // Weitere Spalten
            builder.Property(t => t.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(t => t.Ingredient)
                .HasColumnName("ingredients");
            builder.Property(t => t.Steps)
                .HasColumnName("steps");
            builder.Property(t => t.IsFavorit)
                .HasColumnName("favorite")
                .HasDefaultValue(false)
                .ValueGeneratedNever();
        }
    }
}
