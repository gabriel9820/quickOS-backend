using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quickOS.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedStaticData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc), new Guid("b25719f0-d241-45c3-b72b-15524a02d26e"), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc), new Guid("d0505db2-a3ed-4e3e-943a-61df332631d1"), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc), new Guid("1756d900-d234-4777-bcf0-86a72ea0f1cc"), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc), new Guid("586762f7-90d5-4821-b1cc-a0679917fe6d"), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc), new Guid("c0ef61a9-fdf1-4b8e-89f5-7882e2ffc1fa"), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc), new Guid("ccdfb575-2492-441f-83fb-5047c1d34a0c"), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc), new Guid("30a78d4e-62b6-42d5-95fe-4f5ee0cb0257"), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc), new Guid("9b485104-de70-4964-8b64-dae14a085b97"), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc), new Guid("97623f28-4d25-4e8c-a65b-62e219d4922b"), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc), new Guid("bb489c91-3400-4520-9033-15b7db5eb18d"), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1798), new Guid("ff047f1a-f3bf-46bc-ba53-98cb0ed0818e"), new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1798) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1811), new Guid("efc06679-387c-4418-9864-eb7490b7e65d"), new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1811) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1819), new Guid("11ac42c7-c08b-48af-91b1-e72131089a3f"), new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1819) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1827), new Guid("f7f5301b-fc1c-42e3-9b8d-270f2021760e"), new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1828) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1835), new Guid("6895c981-724b-49d9-9bf6-88d3a383d1d7"), new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1835) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1843), new Guid("b9602136-b0c8-49d8-adb5-23395d05c1bc"), new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1843) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1851), new Guid("c1555e76-5b31-4b70-ae4d-d75be6c77f4f"), new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1851) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1859), new Guid("b56ccd37-dd24-482a-8c60-8825e6608749"), new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1867), new Guid("f25ad949-c0f5-486b-a9c1-9774bd163533"), new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1867) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1875), new Guid("a5b91309-573a-4ce8-add9-768dcfd2bbfb"), new DateTime(2024, 5, 23, 0, 11, 4, 652, DateTimeKind.Utc).AddTicks(1875) });
        }
    }
}
