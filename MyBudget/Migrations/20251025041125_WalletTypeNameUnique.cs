using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Migrations
{
    /// <inheritdoc />
    public partial class WalletTypeNameUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WalletTypes_Name",
                table: "WalletTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WalletTypes_Name",
                table: "WalletTypes");
        }
    }
}
