﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RezepteApp.DB;
using System;

namespace RezepteApp.Migrations
{
    [DbContext(typeof(ReceiptContext))]
    partial class ReceiptContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("RezepteApp.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("_id");

                    b.Property<string>("Ingredient")
                        .HasColumnName("ingredients");

                    b.Property<bool>("IsFavorit")
                        .HasColumnName("favorite")
                        .HasDefaultValue(false);

                    b.Property<int>("Rating")
                        .HasColumnName("rating")
                        .HasDefaultValue(0);

                    b.Property<string>("Steps")
                        .HasColumnName("steps");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("receipts");
                });
#pragma warning restore 612, 618
        }
    }
}
