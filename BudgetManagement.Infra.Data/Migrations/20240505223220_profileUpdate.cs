using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetManagement.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class profileUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Profile_ProfileId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Spent_Profile_ProfileId",
                table: "Spent");

            migrationBuilder.DropIndex(
                name: "IX_Spent_ProfileId",
                table: "Spent");

            migrationBuilder.DropIndex(
                name: "IX_Category_ProfileId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Spent");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Spent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spent_ProfileId",
                table: "Spent",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProfileId",
                table: "Category",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Profile_ProfileId",
                table: "Category",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Spent_Profile_ProfileId",
                table: "Spent",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id");
        }
    }
}
