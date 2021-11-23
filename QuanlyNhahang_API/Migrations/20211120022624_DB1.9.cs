using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanlyNhahang_API.Migrations
{
    public partial class DB19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Unit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Unit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unit_CreatedUserId",
                table: "Unit",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_UpdatedUserId",
                table: "Unit",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_User_CreatedUserId",
                table: "Unit",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_User_UpdatedUserId",
                table: "Unit",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_User_CreatedUserId",
                table: "Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_User_UpdatedUserId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Unit_CreatedUserId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Unit_UpdatedUserId",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Unit");
        }
    }
}
