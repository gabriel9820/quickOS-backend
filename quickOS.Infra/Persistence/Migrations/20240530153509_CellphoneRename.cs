using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quickOS.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CellphoneRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CellPhone",
                table: "Users",
                newName: "Cellphone");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CellPhone",
                table: "Users",
                newName: "IX_Users_Cellphone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cellphone",
                table: "Users",
                newName: "CellPhone");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Cellphone",
                table: "Users",
                newName: "IX_Users_CellPhone");
        }
    }
}
