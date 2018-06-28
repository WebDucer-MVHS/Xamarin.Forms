using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RezepteApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    _id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ingredients = table.Column<string>(nullable: true),
                    favorite = table.Column<bool>(nullable: false, defaultValue: false),
                    steps = table.Column<string>(nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipts", x => x._id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receipts");
        }
    }
}
