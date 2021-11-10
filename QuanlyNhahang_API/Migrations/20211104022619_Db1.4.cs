using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanlyNhahang_API.Migrations
{
    public partial class Db14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_CreatedUserId",
                table: "Restaurant",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_UpdatedUserId",
                table: "Restaurant",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_User_CreatedUserId",
                table: "Restaurant",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_User_UpdatedUserId",
                table: "Restaurant",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_User_CreatedUserId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_User_UpdatedUserId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_CreatedUserId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_UpdatedUserId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Restaurant");
        }
    }
}
