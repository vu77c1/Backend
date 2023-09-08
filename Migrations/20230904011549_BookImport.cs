using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MSQL.Migrations
{
    /// <inheritdoc />
    public partial class BookImport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksImport",
                columns: table => new
                {
                    BookImportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "longtext", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksImport", x => x.BookImportId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksImport");
        }
    }
}
