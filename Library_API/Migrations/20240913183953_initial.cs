using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Genre", "IsAvailable", "Published", "Title" },
                values: new object[,]
                {
                    { 1, "Author of Book", "Genre of Book", true, new DateTime(2024, 9, 13, 20, 39, 52, 834, DateTimeKind.Local).AddTicks(9306), "Titel of Book" },
                    { 2, "Book Author", "Book Genre", true, new DateTime(2024, 9, 13, 20, 39, 52, 834, DateTimeKind.Local).AddTicks(9348), "Book Title" },
                    { 3, "The Author", "The Genre", false, new DateTime(2024, 9, 13, 20, 39, 52, 834, DateTimeKind.Local).AddTicks(9351), "The Titel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
