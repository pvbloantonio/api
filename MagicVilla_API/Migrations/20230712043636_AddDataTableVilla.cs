using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AddDataTableVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "Created_at", "Description", "ImageUrl", "Name", "Occupants", "Price", "SquareMeter", "Updated_at" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 7, 12, 4, 36, 36, 480, DateTimeKind.Utc).AddTicks(8304), "Test", "", "Test", 3, 3000.0, 3, new DateTime(2023, 7, 12, 4, 36, 36, 480, DateTimeKind.Utc).AddTicks(8305) },
                    { 2, "", new DateTime(2023, 7, 12, 4, 36, 36, 480, DateTimeKind.Utc).AddTicks(8307), "Test2", "", "Test2", 3, 3000.0, 3, new DateTime(2023, 7, 12, 4, 36, 36, 480, DateTimeKind.Utc).AddTicks(8307) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
