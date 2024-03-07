using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace quickOS.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamedCompanyToTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesProvided_Companies_CompanyId",
                table: "ServicesProvided");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Users",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                newName: "IX_Users_TenantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "ServicesProvided",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesProvided_CompanyId",
                table: "ServicesProvided",
                newName: "IX_ServicesProvided_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesProvided_Code_CompanyId",
                table: "ServicesProvided",
                newName: "IX_ServicesProvided_Code_TenantId");

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ExternalId",
                table: "Tenants",
                column: "ExternalId",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesProvided_Tenants_TenantId",
                table: "ServicesProvided");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Users",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                newName: "IX_Users_CompanyId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "ServicesProvided",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesProvided_TenantId",
                table: "ServicesProvided",
                newName: "IX_ServicesProvided_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesProvided_Code_TenantId",
                table: "ServicesProvided",
                newName: "IX_ServicesProvided_Code_CompanyId");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ExternalId",
                table: "Companies",
                column: "ExternalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesProvided_Companies_CompanyId",
                table: "ServicesProvided",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
