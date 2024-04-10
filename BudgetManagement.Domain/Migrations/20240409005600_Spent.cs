using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetManagement.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Spent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpentId",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Spent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spent_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_SpentId",
                table: "Profiles",
                column: "SpentId");

            migrationBuilder.CreateIndex(
                name: "IX_Spent_CategoryId",
                table: "Spent",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Spent_SpentId",
                table: "Profiles",
                column: "SpentId",
                principalTable: "Spent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Spent_SpentId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "Spent");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_SpentId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "SpentId",
                table: "Profiles");
        }
    }
}
