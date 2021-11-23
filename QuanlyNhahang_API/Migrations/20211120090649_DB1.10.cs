using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanlyNhahang_API.Migrations
{
    public partial class DB110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Unit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unit_RestaurantId",
                table: "Unit",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Restaurant_RestaurantId",
                table: "Unit",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Restaurant_RestaurantId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Unit_RestaurantId",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Unit");
        }
    }
}
