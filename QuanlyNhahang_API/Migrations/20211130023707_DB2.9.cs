using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanlyNhahang_API.Migrations
{
    public partial class DB29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Unit_UnitId",
                table: "Item");

            //migrationBuilder.RenameColumn(
            //    name: "Dessription",
            //    table: "ItemImage",
            //    newName: "Description");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "Item",
                newName: "UpdatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_UnitId",
                table: "Item",
                newName: "IX_Item_UpdatedUserId");

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_CreatedUserId",
                table: "Item",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_RestaurantId",
                table: "Item",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Restaurant_RestaurantId",
                table: "Item",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_CreatedUserId",
                table: "Item",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UpdatedUserId",
                table: "Item",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Restaurant_RestaurantId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_CreatedUserId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UpdatedUserId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CreatedUserId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_RestaurantId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Item");

            //migrationBuilder.RenameColumn(
            //    name: "Description",
            //    table: "ItemImage",
            //    newName: "Dessription");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Item",
                newName: "UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_UpdatedUserId",
                table: "Item",
                newName: "IX_Item_UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Unit_UnitId",
                table: "Item",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
