using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quickOS.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CellPhoneLengthUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CellPhone",
                table: "Users",
                type: "character(15)",
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(14)",
                oldFixedLength: true,
                oldMaxLength: 14);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CellPhone",
                table: "Users",
                type: "character(14)",
                fixedLength: true,
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(15)",
                oldFixedLength: true,
                oldMaxLength: 15);
        }
    }
}
