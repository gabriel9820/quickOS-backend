using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace quickOS.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewEntitiesConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Details",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Neighborhood",
                table: "Users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Number",
                table: "Users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Users",
                type: "character(9)",
                fixedLength: true,
                maxLength: 9,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ServicesProvided",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Document = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    FullName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Cellphone = table.Column<string>(type: "character(15)", fixedLength: true, maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "character(9)", fixedLength: true, maxLength: 9, nullable: true),
                    Address_Street = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Address_Number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Address_Details = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Address_Neighborhood = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Address_City = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Address_State = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CostPrice = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    ProfitMargin = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    SellingPrice = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Stock = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UnitOfMeasurementId = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_UnitsOfMeasurement_UnitOfMeasurementId",
                        column: x => x.UnitOfMeasurementId,
                        principalTable: "UnitsOfMeasurement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    EquipmentDescription = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ProblemDescription = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TechnicalReport = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    TechnicianId = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrder_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrder_Users_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrderProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Item = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", precision: 6, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ServiceOrderId = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrderProduct_ServiceOrder_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrderService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Item = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", precision: 6, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    ServiceOrderId = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrderService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrderService_ServiceOrder_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrderService_ServicesProvided_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServicesProvided",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Cellphone_TenantId",
                table: "Customer",
                columns: new[] { "Cellphone", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Document_TenantId",
                table: "Customer",
                columns: new[] { "Document", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email_TenantId",
                table: "Customer",
                columns: new[] { "Email", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ExternalId",
                table: "Customer",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TenantId",
                table: "Customer",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Code_TenantId",
                table: "Product",
                columns: new[] { "Code", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ExternalId",
                table: "Product",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_TenantId",
                table: "Product",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitOfMeasurementId",
                table: "Product",
                column: "UnitOfMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_CustomerId",
                table: "ServiceOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_ExternalId",
                table: "ServiceOrder",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_Number_TenantId",
                table: "ServiceOrder",
                columns: new[] { "Number", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_TechnicianId",
                table: "ServiceOrder",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_TenantId",
                table: "ServiceOrder",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderProduct_ExternalId",
                table: "ServiceOrderProduct",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderProduct_Item_ServiceOrderId",
                table: "ServiceOrderProduct",
                columns: new[] { "Item", "ServiceOrderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderProduct_ProductId",
                table: "ServiceOrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderProduct_ServiceOrderId",
                table: "ServiceOrderProduct",
                column: "ServiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderService_ExternalId",
                table: "ServiceOrderService",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderService_Item_ServiceOrderId",
                table: "ServiceOrderService",
                columns: new[] { "Item", "ServiceOrderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderService_ServiceId",
                table: "ServiceOrderService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderService_ServiceOrderId",
                table: "ServiceOrderService",
                column: "ServiceOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceOrderProduct");

            migrationBuilder.DropTable(
                name: "ServiceOrderService");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ServiceOrder");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_Details",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_Neighborhood",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_Number",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Users");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ServicesProvided",
                type: "double precision",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6629), new Guid("b25719f0-d241-45c3-b72b-15524a02d26e"), new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6639), new Guid("d0505db2-a3ed-4e3e-943a-61df332631d1"), new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6648), new Guid("1756d900-d234-4777-bcf0-86a72ea0f1cc"), new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6648) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6656), new Guid("586762f7-90d5-4821-b1cc-a0679917fe6d"), new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6656) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6663), new Guid("c0ef61a9-fdf1-4b8e-89f5-7882e2ffc1fa"), new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6664) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6671), new Guid("ccdfb575-2492-441f-83fb-5047c1d34a0c"), new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6671) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6679), new Guid("30a78d4e-62b6-42d5-95fe-4f5ee0cb0257"), new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6679) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6686), new Guid("9b485104-de70-4964-8b64-dae14a085b97"), new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6687) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6694), new Guid("97623f28-4d25-4e8c-a65b-62e219d4922b"), new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6694) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasurement",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExternalId", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6702), new Guid("bb489c91-3400-4520-9033-15b7db5eb18d"), new DateTime(2024, 5, 16, 22, 45, 11, 226, DateTimeKind.Utc).AddTicks(6702) });
        }
    }
}
