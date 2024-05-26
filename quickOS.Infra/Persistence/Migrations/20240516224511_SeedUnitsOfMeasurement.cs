using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace quickOS.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedUnitsOfMeasurement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UnitsOfMeasurement",
                columns: new[] { "Id", "Abbreviation", "CreatedAt", "ExternalId", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "un", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6629), new Guid("b25719f0-d241-45c3-b72b-15524a02d26e"), true, "Unidade", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6630) },
                    { 2, "pç", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6639), new Guid("d0505db2-a3ed-4e3e-943a-61df332631d1"), true, "Peça", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6640) },
                    { 3, "cx", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6648), new Guid("1756d900-d234-4777-bcf0-86a72ea0f1cc"), true, "Caixa", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6648) },
                    { 4, "pa", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6656), new Guid("586762f7-90d5-4821-b1cc-a0679917fe6d"), true, "Par", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6656) },
                    { 5, "cm", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6663), new Guid("c0ef61a9-fdf1-4b8e-89f5-7882e2ffc1fa"), true, "Centímetro", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6664) },
                    { 6, "m", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6671), new Guid("ccdfb575-2492-441f-83fb-5047c1d34a0c"), true, "Metro", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6671) },
                    { 7, "g", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6679), new Guid("30a78d4e-62b6-42d5-95fe-4f5ee0cb0257"), true, "Grama", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6679) },
                    { 8, "kg", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6686), new Guid("9b485104-de70-4964-8b64-dae14a085b97"), true, "Quilograma", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6687) },
                    { 9, "ml", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6694), new Guid("97623f28-4d25-4e8c-a65b-62e219d4922b"), true, "Mililitro", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6694) },
                    { 10, "l", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6702), new Guid("bb489c91-3400-4520-9033-15b7db5eb18d"), true, "Litro", new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6702) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
