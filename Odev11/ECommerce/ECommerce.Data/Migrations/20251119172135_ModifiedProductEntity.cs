using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "IPhone 16", 60000m, 6 },
                    { 2, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "IPhone 15", 50000m, 16 },
                    { 3, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "IPhone 14", 40000m, 26 },
                    { 4, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "IPhone 13", 30000m, 36 },
                    { 5, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "IPhone 12", 20000m, 46 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Products");
        }
    }
}
