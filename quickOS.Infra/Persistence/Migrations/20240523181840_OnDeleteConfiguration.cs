using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quickOS.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Tenants_TenantId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Tenants_TenantId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_UnitsOfMeasurement_UnitOfMeasurementId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_Customer_CustomerId",
                table: "ServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_Tenants_TenantId",
                table: "ServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_Users_TechnicianId",
                table: "ServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrderProduct_Product_ProductId",
                table: "ServiceOrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrderService_ServicesProvided_ServiceId",
                table: "ServiceOrderService");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesProvided_Tenants_TenantId",
                table: "ServicesProvided");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Tenants_TenantId",
                table: "Customer",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Tenants_TenantId",
                table: "Product",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_UnitsOfMeasurement_UnitOfMeasurementId",
                table: "Product",
                column: "UnitOfMeasurementId",
                principalTable: "UnitsOfMeasurement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_Customer_CustomerId",
                table: "ServiceOrder",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_Tenants_TenantId",
                table: "ServiceOrder",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_Users_TechnicianId",
                table: "ServiceOrder",
                column: "TechnicianId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrderProduct_Product_ProductId",
                table: "ServiceOrderProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrderService_ServicesProvided_ServiceId",
                table: "ServiceOrderService",
                column: "ServiceId",
                principalTable: "ServicesProvided",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesProvided_Tenants_TenantId",
                table: "ServicesProvided",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Tenants_TenantId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Tenants_TenantId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_UnitsOfMeasurement_UnitOfMeasurementId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_Customer_CustomerId",
                table: "ServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_Tenants_TenantId",
                table: "ServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_Users_TechnicianId",
                table: "ServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrderProduct_Product_ProductId",
                table: "ServiceOrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrderService_ServicesProvided_ServiceId",
                table: "ServiceOrderService");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesProvided_Tenants_TenantId",
                table: "ServicesProvided");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Tenants_TenantId",
                table: "Customer",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Tenants_TenantId",
                table: "Product",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_UnitsOfMeasurement_UnitOfMeasurementId",
                table: "Product",
                column: "UnitOfMeasurementId",
                principalTable: "UnitsOfMeasurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_Customer_CustomerId",
                table: "ServiceOrder",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_Tenants_TenantId",
                table: "ServiceOrder",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_Users_TechnicianId",
                table: "ServiceOrder",
                column: "TechnicianId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrderProduct_Product_ProductId",
                table: "ServiceOrderProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrderService_ServicesProvided_ServiceId",
                table: "ServiceOrderService",
                column: "ServiceId",
                principalTable: "ServicesProvided",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesProvided_Tenants_TenantId",
                table: "ServicesProvided",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
