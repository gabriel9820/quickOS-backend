using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quickOS.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TableName : Migration
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
                name: "FK_ServiceOrderProduct_ServiceOrder_ServiceOrderId",
                table: "ServiceOrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrderService_ServiceOrder_ServiceOrderId",
                table: "ServiceOrderService");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrderService_ServicesProvided_ServiceId",
                table: "ServiceOrderService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrderService",
                table: "ServiceOrderService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrderProduct",
                table: "ServiceOrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrder",
                table: "ServiceOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "ServiceOrderService",
                newName: "ServiceOrdersServices");

            migrationBuilder.RenameTable(
                name: "ServiceOrderProduct",
                newName: "ServiceOrdersProducts");

            migrationBuilder.RenameTable(
                name: "ServiceOrder",
                newName: "ServiceOrders");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrderService_ServiceOrderId",
                table: "ServiceOrdersServices",
                newName: "IX_ServiceOrdersServices_ServiceOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrderService_ServiceId",
                table: "ServiceOrdersServices",
                newName: "IX_ServiceOrdersServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrderService_Item_ServiceOrderId",
                table: "ServiceOrdersServices",
                newName: "IX_ServiceOrdersServices_Item_ServiceOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrderService_ExternalId",
                table: "ServiceOrdersServices",
                newName: "IX_ServiceOrdersServices_ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrderProduct_ServiceOrderId",
                table: "ServiceOrdersProducts",
                newName: "IX_ServiceOrdersProducts_ServiceOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrderProduct_ProductId",
                table: "ServiceOrdersProducts",
                newName: "IX_ServiceOrdersProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrderProduct_Item_ServiceOrderId",
                table: "ServiceOrdersProducts",
                newName: "IX_ServiceOrdersProducts_Item_ServiceOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrderProduct_ExternalId",
                table: "ServiceOrdersProducts",
                newName: "IX_ServiceOrdersProducts_ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrder_TenantId",
                table: "ServiceOrders",
                newName: "IX_ServiceOrders_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrder_TechnicianId",
                table: "ServiceOrders",
                newName: "IX_ServiceOrders_TechnicianId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrder_Number_TenantId",
                table: "ServiceOrders",
                newName: "IX_ServiceOrders_Number_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrder_ExternalId",
                table: "ServiceOrders",
                newName: "IX_ServiceOrders_ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrder_CustomerId",
                table: "ServiceOrders",
                newName: "IX_ServiceOrders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_UnitOfMeasurementId",
                table: "Products",
                newName: "IX_Products_UnitOfMeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_TenantId",
                table: "Products",
                newName: "IX_Products_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ExternalId",
                table: "Products",
                newName: "IX_Products_ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Code_TenantId",
                table: "Products",
                newName: "IX_Products_Code_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_TenantId",
                table: "Customers",
                newName: "IX_Customers_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ExternalId",
                table: "Customers",
                newName: "IX_Customers_ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Email_TenantId",
                table: "Customers",
                newName: "IX_Customers_Email_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Document_TenantId",
                table: "Customers",
                newName: "IX_Customers_Document_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Cellphone_TenantId",
                table: "Customers",
                newName: "IX_Customers_Cellphone_TenantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrdersServices",
                table: "ServiceOrdersServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrdersProducts",
                table: "ServiceOrdersProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrders",
                table: "ServiceOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tenants_TenantId",
                table: "Customers",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tenants_TenantId",
                table: "Products",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitsOfMeasurement_UnitOfMeasurementId",
                table: "Products",
                column: "UnitOfMeasurementId",
                principalTable: "UnitsOfMeasurement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Customers_CustomerId",
                table: "ServiceOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Tenants_TenantId",
                table: "ServiceOrders",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Users_TechnicianId",
                table: "ServiceOrders",
                column: "TechnicianId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrdersProducts_Products_ProductId",
                table: "ServiceOrdersProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrdersProducts_ServiceOrders_ServiceOrderId",
                table: "ServiceOrdersProducts",
                column: "ServiceOrderId",
                principalTable: "ServiceOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrdersServices_ServiceOrders_ServiceOrderId",
                table: "ServiceOrdersServices",
                column: "ServiceOrderId",
                principalTable: "ServiceOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrdersServices_ServicesProvided_ServiceId",
                table: "ServiceOrdersServices",
                column: "ServiceId",
                principalTable: "ServicesProvided",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tenants_TenantId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tenants_TenantId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitsOfMeasurement_UnitOfMeasurementId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Customers_CustomerId",
                table: "ServiceOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Tenants_TenantId",
                table: "ServiceOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Users_TechnicianId",
                table: "ServiceOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrdersProducts_Products_ProductId",
                table: "ServiceOrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrdersProducts_ServiceOrders_ServiceOrderId",
                table: "ServiceOrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrdersServices_ServiceOrders_ServiceOrderId",
                table: "ServiceOrdersServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrdersServices_ServicesProvided_ServiceId",
                table: "ServiceOrdersServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrdersServices",
                table: "ServiceOrdersServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrdersProducts",
                table: "ServiceOrdersProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrders",
                table: "ServiceOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "ServiceOrdersServices",
                newName: "ServiceOrderService");

            migrationBuilder.RenameTable(
                name: "ServiceOrdersProducts",
                newName: "ServiceOrderProduct");

            migrationBuilder.RenameTable(
                name: "ServiceOrders",
                newName: "ServiceOrder");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrdersServices_ServiceOrderId",
                table: "ServiceOrderService",
                newName: "IX_ServiceOrderService_ServiceOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrdersServices_ServiceId",
                table: "ServiceOrderService",
                newName: "IX_ServiceOrderService_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrdersServices_Item_ServiceOrderId",
                table: "ServiceOrderService",
                newName: "IX_ServiceOrderService_Item_ServiceOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrdersServices_ExternalId",
                table: "ServiceOrderService",
                newName: "IX_ServiceOrderService_ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrdersProducts_ServiceOrderId",
                table: "ServiceOrderProduct",
                newName: "IX_ServiceOrderProduct_ServiceOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrdersProducts_ProductId",
                table: "ServiceOrderProduct",
                newName: "IX_ServiceOrderProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrdersProducts_Item_ServiceOrderId",
                table: "ServiceOrderProduct",
                newName: "IX_ServiceOrderProduct_Item_ServiceOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrdersProducts_ExternalId",
                table: "ServiceOrderProduct",
                newName: "IX_ServiceOrderProduct_ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrders_TenantId",
                table: "ServiceOrder",
                newName: "IX_ServiceOrder_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrders_TechnicianId",
                table: "ServiceOrder",
                newName: "IX_ServiceOrder_TechnicianId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrders_Number_TenantId",
                table: "ServiceOrder",
                newName: "IX_ServiceOrder_Number_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrders_ExternalId",
                table: "ServiceOrder",
                newName: "IX_ServiceOrder_ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrders_CustomerId",
                table: "ServiceOrder",
                newName: "IX_ServiceOrder_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UnitOfMeasurementId",
                table: "Product",
                newName: "IX_Product_UnitOfMeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TenantId",
                table: "Product",
                newName: "IX_Product_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ExternalId",
                table: "Product",
                newName: "IX_Product_ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Code_TenantId",
                table: "Product",
                newName: "IX_Product_Code_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_TenantId",
                table: "Customer",
                newName: "IX_Customer_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ExternalId",
                table: "Customer",
                newName: "IX_Customer_ExternalId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Email_TenantId",
                table: "Customer",
                newName: "IX_Customer_Email_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Document_TenantId",
                table: "Customer",
                newName: "IX_Customer_Document_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Cellphone_TenantId",
                table: "Customer",
                newName: "IX_Customer_Cellphone_TenantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrderService",
                table: "ServiceOrderService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrderProduct",
                table: "ServiceOrderProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrder",
                table: "ServiceOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

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
                name: "FK_ServiceOrderProduct_ServiceOrder_ServiceOrderId",
                table: "ServiceOrderProduct",
                column: "ServiceOrderId",
                principalTable: "ServiceOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrderService_ServiceOrder_ServiceOrderId",
                table: "ServiceOrderService",
                column: "ServiceOrderId",
                principalTable: "ServiceOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrderService_ServicesProvided_ServiceId",
                table: "ServiceOrderService",
                column: "ServiceId",
                principalTable: "ServicesProvided",
                principalColumn: "Id");
        }
    }
}
