using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetManagement.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Profile_IdProfile",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Spent_Profile_IdProfile",
                table: "Spent");

            migrationBuilder.RenameColumn(
                name: "IdProfile",
                table: "Spent",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Spent_IdProfile",
                table: "Spent",
                newName: "IX_Spent_IdUser");

            migrationBuilder.RenameColumn(
                name: "IdProfile",
                table: "Category",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Category_IdProfile",
                table: "Category",
                newName: "IX_Category_IdUser");

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
                name: "FK_Category_User_IdUser",
                table: "Category",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spent_Profile_ProfileId",
                table: "Spent",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Spent_User_IdUser",
                table: "Spent",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Profile_ProfileId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_IdUser",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Spent_Profile_ProfileId",
                table: "Spent");

            migrationBuilder.DropForeignKey(
                name: "FK_Spent_User_IdUser",
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

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Spent",
                newName: "IdProfile");

            migrationBuilder.RenameIndex(
                name: "IX_Spent_IdUser",
                table: "Spent",
                newName: "IX_Spent_IdProfile");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Category",
                newName: "IdProfile");

            migrationBuilder.RenameIndex(
                name: "IX_Category_IdUser",
                table: "Category",
                newName: "IX_Category_IdProfile");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Profile_IdProfile",
                table: "Category",
                column: "IdProfile",
                principalTable: "Profile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Spent_Profile_IdProfile",
                table: "Spent",
                column: "IdProfile",
                principalTable: "Profile",
                principalColumn: "Id");
        }
    }
}
