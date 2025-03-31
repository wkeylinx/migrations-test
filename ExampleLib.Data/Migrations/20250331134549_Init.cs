using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExampleLib.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Review = table.Column<int>(type: "INTEGER", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublishedDate", "Review", "Title" },
                values: new object[,]
                {
                    { 1, "Author One", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Book One" },
                    { 2, "Author Two", new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Book Two" },
                    { 3, "Author Three", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Book Three" },
                    { 4, "George Orwell", new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "1984" },
                    { 5, "Harper Lee", new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "To Kill a Mockingbird" },
                    { 6, "F. Scott Fitzgerald", new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "The Great Gatsby" },
                    { 7, "Herman Melville", new DateTime(1851, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Moby Dick" },
                    { 8, "Jane Austen", new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Pride and Prejudice" },
                    { 9, "Leo Tolstoy", new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "War and Peace" },
                    { 10, "J.D. Salinger", new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "The Catcher in the Rye" },
                    { 11, "J.R.R. Tolkien", new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "The Hobbit" },
                    { 12, "Ray Bradbury", new DateTime(1953, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Fahrenheit 451" },
                    { 13, "Charlotte Brontë", new DateTime(1847, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Jane Eyre" }
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
