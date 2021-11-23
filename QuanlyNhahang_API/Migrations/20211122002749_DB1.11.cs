﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanlyNhahang_API.Migrations
{
    public partial class DB111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "parentId",
                table: "Catogory",
                newName: "ParentId");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Catogory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ChildrenId",
                table: "Catogory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Catogory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Catogory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Catogory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffDuty = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDTO_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantDTO_UserDTO_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "UserDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantDTO_UserDTO_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "UserDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDTOUserDTO",
                columns: table => new
                {
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDTOUserDTO", x => new { x.CreatedUserId, x.UpdatedUserId });
                    table.ForeignKey(
                        name: "FK_UserDTOUserDTO_UserDTO_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "UserDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDTOUserDTO_UserDTO_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "UserDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatogoryDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RestaurantDTOId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatogoryDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatogoryDTO_CatogoryDTO_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CatogoryDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatogoryDTO_RestaurantDTO_RestaurantDTOId",
                        column: x => x.RestaurantDTOId,
                        principalTable: "RestaurantDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatogoryDTO_UserDTO_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "UserDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatogoryDTO_UserDTO_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "UserDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catogory_CreatedUserId",
                table: "Catogory",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Catogory_ChildrenId",
                table: "Catogory",
                column: "ChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_Catogory_ParentId",
                table: "Catogory",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Catogory_RestaurantId",
                table: "Catogory",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Catogory_UpdatedUserId",
                table: "Catogory",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CatogoryDTO_CreatedUserId",
                table: "CatogoryDTO",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CatogoryDTO_ParentId",
                table: "CatogoryDTO",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CatogoryDTO_RestaurantDTOId",
                table: "CatogoryDTO",
                column: "RestaurantDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_CatogoryDTO_UpdatedUserId",
                table: "CatogoryDTO",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDTO_CreatedUserId",
                table: "RestaurantDTO",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDTO_UpdatedUserId",
                table: "RestaurantDTO",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDTO_RoleId",
                table: "UserDTO",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDTOUserDTO_UpdatedUserId",
                table: "UserDTOUserDTO",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catogory_CatogoryDTO_ChildrenId",
                table: "Catogory",
                column: "ChildrenId",
                principalTable: "CatogoryDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catogory_CatogoryDTO_ParentId",
                table: "Catogory",
                column: "ParentId",
                principalTable: "CatogoryDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catogory_Restaurant_RestaurantId",
                table: "Catogory",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catogory_User_CreatedUserId",
                table: "Catogory",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catogory_User_UpdatedUserId",
                table: "Catogory",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catogory_CatogoryDTO_ChildrenId",
                table: "Catogory");

            migrationBuilder.DropForeignKey(
                name: "FK_Catogory_CatogoryDTO_ParentId",
                table: "Catogory");

            migrationBuilder.DropForeignKey(
                name: "FK_Catogory_Restaurant_RestaurantId",
                table: "Catogory");

            migrationBuilder.DropForeignKey(
                name: "FK_Catogory_User_CreatedUserId",
                table: "Catogory");

            migrationBuilder.DropForeignKey(
                name: "FK_Catogory_User_UpdatedUserId",
                table: "Catogory");

            migrationBuilder.DropTable(
                name: "CatogoryDTO");

            migrationBuilder.DropTable(
                name: "UserDTOUserDTO");

            migrationBuilder.DropTable(
                name: "RestaurantDTO");

            migrationBuilder.DropTable(
                name: "UserDTO");

            migrationBuilder.DropIndex(
                name: "IX_Catogory_CreatedUserId",
                table: "Catogory");

            migrationBuilder.DropIndex(
                name: "IX_Catogory_ChildrenId",
                table: "Catogory");

            migrationBuilder.DropIndex(
                name: "IX_Catogory_ParentId",
                table: "Catogory");

            migrationBuilder.DropIndex(
                name: "IX_Catogory_RestaurantId",
                table: "Catogory");

            migrationBuilder.DropIndex(
                name: "IX_Catogory_UpdatedUserId",
                table: "Catogory");

            migrationBuilder.DropColumn(
                name: "ChildrenId",
                table: "Catogory");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Catogory");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Catogory");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Catogory");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Catogory",
                newName: "parentId");

            migrationBuilder.AlterColumn<int>(
                name: "parentId",
                table: "Catogory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
