﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanlyNhahang_API.Data;

namespace QuanlyNhahang_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211127093713_DB2.8")]
    partial class DB28
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuanlyNhahang_API.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryTypeId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.CategoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CategoryType");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Guest");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quatity")
                        .HasColumnType("int");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UnitId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.ItemImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Dessription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("ItemImage");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Dessription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Voided")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Dessription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("SalePrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Voied")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GuestId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("StatusId");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("UnitTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UnitTypeId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.UnitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UnitType");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OffDuty")
                        .HasColumnType("bit");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Category", b =>
                {
                    b.HasOne("QuanlyNhahang_API.Model.CategoryType", "CategoryType")
                        .WithMany()
                        .HasForeignKey("CategoryTypeId");

                    b.HasOne("QuanlyNhahang_API.Model.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QuanlyNhahang_API.Model.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QuanlyNhahang_API.Model.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CategoryType");

                    b.Navigation("CreatedUser");

                    b.Navigation("Restaurant");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Guest", b =>
                {
                    b.HasOne("QuanlyNhahang_API.Model.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QuanlyNhahang_API.Model.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Item", b =>
                {
                    b.HasOne("QuanlyNhahang_API.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("QuanlyNhahang_API.Model.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("Category");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.ItemImage", b =>
                {
                    b.HasOne("QuanlyNhahang_API.Model.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QuanlyNhahang_API.Model.Item", "Item")
                        .WithMany("ItemImages")
                        .HasForeignKey("ItemId");

                    b.HasOne("QuanlyNhahang_API.Model.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Item");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.OrderItem", b =>
                {
                    b.HasOne("QuanlyNhahang_API.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("QuanlyNhahang_API.Model.Order", null)
                        .WithMany("OrderItem")
                        .HasForeignKey("OrderId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Restaurant", b =>
                {
                    b.HasOne("QuanlyNhahang_API.Model.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QuanlyNhahang_API.Model.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Status", b =>
                {
                    b.HasOne("QuanlyNhahang_API.Model.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QuanlyNhahang_API.Model.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QuanlyNhahang_API.Model.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Restaurant");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Table", b =>
                {
                    b.HasOne("QuanlyNhahang_API.Model.Guest", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId");

                    b.HasOne("QuanlyNhahang_API.Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Guest");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Unit", b =>
                {
                    b.HasOne("QuanlyNhahang_API.Model.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("QuanlyNhahang_API.Model.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("QuanlyNhahang_API.Model.UnitType", "UnitType")
                        .WithMany()
                        .HasForeignKey("UnitTypeId");

                    b.HasOne("QuanlyNhahang_API.Model.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("Restaurant");

                    b.Navigation("UnitType");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.User", b =>
                {
                    b.HasOne("QuanlyNhahang_API.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Item", b =>
                {
                    b.Navigation("ItemImages");
                });

            modelBuilder.Entity("QuanlyNhahang_API.Model.Order", b =>
                {
                    b.Navigation("OrderItem");
                });
#pragma warning restore 612, 618
        }
    }
}
