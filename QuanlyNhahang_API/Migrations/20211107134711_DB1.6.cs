using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanlyNhahang_API.Migrations
{
    public partial class DB16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Update",
                table: "Status",
                newName: "Updated");

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Guest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Guest",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_CreatedUserId",
                table: "Status",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_UpdatedUserId",
                table: "Status",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_CreatedUserId",
                table: "Guest",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_UpdatedUserId",
                table: "Guest",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_User_CreatedUserId",
                table: "Guest",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_User_UpdatedUserId",
                table: "Guest",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_User_CreatedUserId",
                table: "Status",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_User_UpdatedUserId",
                table: "Status",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_User_CreatedUserId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_User_UpdatedUserId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_User_CreatedUserId",
                table: "Status");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_User_UpdatedUserId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_CreatedUserId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_UpdatedUserId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Guest_CreatedUserId",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_UpdatedUserId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Guest");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "Status",
                newName: "Update");
        }
    }
}
