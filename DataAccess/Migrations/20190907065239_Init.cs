﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Username = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderUserName = table.Column<string>(maxLength: 100, nullable: false),
                    OrderAddress = table.Column<string>(maxLength: 150, nullable: false),
                    OrderCity = table.Column<string>(maxLength: 50, nullable: false),
                    DeleveryDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_BaseUser_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_BaseUser_UserId",
                        column: x => x.UserId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bicycles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Brand = table.Column<int>(nullable: false),
                    Model = table.Column<string>(maxLength: 100, nullable: false),
                    FullName = table.Column<string>(maxLength: 120, nullable: false),
                    Brakes = table.Column<string>(maxLength: 100, nullable: true),
                    Cassate = table.Column<string>(maxLength: 100, nullable: true),
                    Chain = table.Column<string>(maxLength: 100, nullable: true),
                    Frame = table.Column<string>(maxLength: 100, nullable: true),
                    Handlebar = table.Column<string>(maxLength: 100, nullable: true),
                    RearDeraillerur = table.Column<string>(maxLength: 100, nullable: true),
                    RearHub = table.Column<string>(maxLength: 100, nullable: true),
                    Seat = table.Column<string>(maxLength: 100, nullable: true),
                    TireSize = table.Column<string>(maxLength: 100, nullable: true),
                    TireInfo = table.Column<string>(maxLength: 100, nullable: true),
                    Weight = table.Column<string>(maxLength: 100, nullable: true),
                    Cruncset = table.Column<string>(maxLength: 100, nullable: true),
                    Fork = table.Column<string>(maxLength: 100, nullable: true),
                    Images = table.Column<string>(maxLength: 100, nullable: true),
                    Prize = table.Column<double>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bicycles_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BaseUser",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Password", "Phone" },
                values: new object[] { 1, "Admin", "Admin@gmail.com", "Admin", "123456", "111111111" });

            migrationBuilder.CreateIndex(
                name: "IX_Bicycles_OrderId",
                table: "Bicycles",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bicycles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BaseUser");
        }
    }
}