using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    Account = table.Column<string>(type: "varchar(30)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    Account = table.Column<string>(type: "varchar(30)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerType = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactAddresses_OrganizationAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "OrganizationAccounts",
                        principalColumns: new[] { "Id", "AccountType" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactAddresses_PersonAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "PersonAccounts",
                        principalColumns: new[] { "Id", "AccountType" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactEmails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(200)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerType = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactEmails_OrganizationAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "OrganizationAccounts",
                        principalColumns: new[] { "Id", "AccountType" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactEmails_PersonAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "PersonAccounts",
                        principalColumns: new[] { "Id", "AccountType" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    AreaCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerType = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPhones_OrganizationAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "OrganizationAccounts",
                        principalColumns: new[] { "Id", "AccountType" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactPhones_PersonAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "PersonAccounts",
                        principalColumns: new[] { "Id", "AccountType" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationManager",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationManager", x => new { x.OrganizationId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_OrganizationManager_OrganizationAccounts_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "OrganizationAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationManager_PersonAccounts_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "PersonAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddresses_OwnerID_OwnerType",
                table: "ContactAddresses",
                columns: new[] { "OwnerID", "OwnerType" });

            migrationBuilder.CreateIndex(
                name: "IX_ContactEmails_OwnerID_OwnerType",
                table: "ContactEmails",
                columns: new[] { "OwnerID", "OwnerType" });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPhones_OwnerID_OwnerType",
                table: "ContactPhones",
                columns: new[] { "OwnerID", "OwnerType" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationManager_ManagerId",
                table: "OrganizationManager",
                columns: new[] { "ManagerId", "OrganizationId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactAddresses");

            migrationBuilder.DropTable(
                name: "ContactEmails");

            migrationBuilder.DropTable(
                name: "ContactPhones");

            migrationBuilder.DropTable(
                name: "OrganizationManager");

            migrationBuilder.DropTable(
                name: "OrganizationAccounts");

            migrationBuilder.DropTable(
                name: "PersonAccounts");
        }
    }
}
