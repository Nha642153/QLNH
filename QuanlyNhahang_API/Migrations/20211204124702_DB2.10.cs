using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanlyNhahang_API.Migrations
{
    public partial class DB210 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemImage_Item_ItemId",
                table: "ItemImage");

            migrationBuilder.DropIndex(
                name: "IX_ItemImage_ItemId",
                table: "ItemImage");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemImage");

            migrationBuilder.AddColumn<int>(
                name: "ItemImageId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemImageId",
                table: "Item",
                column: "ItemImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ItemImage_ItemImageId",
                table: "Item",
                column: "ItemImageId",
                principalTable: "ItemImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_ItemImage_ItemImageId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_ItemImageId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemImageId",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemImage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemImage_ItemId",
                table: "ItemImage",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImage_Item_ItemId",
                table: "ItemImage",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
