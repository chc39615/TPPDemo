using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CrateOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationManager_OrganizationAccounts_OrganizationId",
                table: "OrganizationManager");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationManager_PersonAccounts_ManagerId",
                table: "OrganizationManager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationManager",
                table: "OrganizationManager");

            migrationBuilder.RenameTable(
                name: "OrganizationManager",
                newName: "OrganizationManagers");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationManager_ManagerId",
                table: "OrganizationManagers",
                newName: "IX_OrganizationManagers_ManagerId");

            migrationBuilder.AddColumn<byte>(
                name: "Role",
                table: "OrganizationManagers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationManagers",
                table: "OrganizationManagers",
                columns: new[] { "OrganizationId", "ManagerId" });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchantId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderFees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    FeeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderFees_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPrice = table.Column<int>(type: "int", nullable: false),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderFees_OrderId",
                table: "OrderFees",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationManagers_OrganizationAccounts_OrganizationId",
                table: "OrganizationManagers",
                column: "OrganizationId",
                principalTable: "OrganizationAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationManagers_PersonAccounts_ManagerId",
                table: "OrganizationManagers",
                column: "ManagerId",
                principalTable: "PersonAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationManagers_OrganizationAccounts_OrganizationId",
                table: "OrganizationManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationManagers_PersonAccounts_ManagerId",
                table: "OrganizationManagers");

            migrationBuilder.DropTable(
                name: "OrderFees");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationManagers",
                table: "OrganizationManagers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "OrganizationManagers");

            migrationBuilder.RenameTable(
                name: "OrganizationManagers",
                newName: "OrganizationManager");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationManagers_ManagerId",
                table: "OrganizationManager",
                newName: "IX_OrganizationManager_ManagerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationManager",
                table: "OrganizationManager",
                columns: new[] { "OrganizationId", "ManagerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationManager_OrganizationAccounts_OrganizationId",
                table: "OrganizationManager",
                column: "OrganizationId",
                principalTable: "OrganizationAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationManager_PersonAccounts_ManagerId",
                table: "OrganizationManager",
                column: "ManagerId",
                principalTable: "PersonAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
