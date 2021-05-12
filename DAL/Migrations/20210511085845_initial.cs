using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CMSFunction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentFunctionId = table.Column<int>(type: "int", nullable: false),
                    FunctionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ControllerName = table.Column<string>(type: "varchar(200)", nullable: true),
                    ActionName = table.Column<string>(type: "varchar(200)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSFunction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMSRoleMember",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSRoleMember", x => new { x.AccountId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "ManagerList",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerList", x => new { x.OrganizationId, x.ManagerId });
                });

            migrationBuilder.CreateTable(
                name: "MerchantAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterNameE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterNameC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayNameE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayNameC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualRevenue = table.Column<int>(type: "int", nullable: false),
                    EquityCapital = table.Column<int>(type: "int", nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false),
                    ProxyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProxyIDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProxyNation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantAccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    Account = table.Column<string>(type: "varchar(30)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantAccounts", x => x.Id);
                    table.UniqueConstraint("AK_MerchantAccounts_Id_AccountType", x => new { x.Id, x.AccountType });
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchantId = table.Column<int>(type: "int", nullable: false),
                    MerchantOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostBackUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffAccounts",
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
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAccounts", x => x.Id);
                    table.UniqueConstraint("AK_StaffAccounts_Id_AccountType", x => new { x.Id, x.AccountType });
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

            migrationBuilder.CreateTable(
                name: "OrderTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTransactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CMSPermissions",
                columns: table => new
                {
                    FunctionId = table.Column<int>(type: "int", nullable: false),
                    BelongToId = table.Column<int>(type: "int", nullable: false),
                    IdentityType = table.Column<byte>(type: "tinyint", nullable: false),
                    CMSFunctionId = table.Column<int>(type: "int", nullable: true),
                    StaffAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSPermissions", x => new { x.FunctionId, x.BelongToId, x.IdentityType });
                    table.ForeignKey(
                        name: "FK_CMSPermissions_CMSFunction_CMSFunctionId",
                        column: x => x.CMSFunctionId,
                        principalTable: "CMSFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CMSPermissions_StaffAccounts_StaffAccountId",
                        column: x => x.StaffAccountId,
                        principalTable: "StaffAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerType = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactAddresses_MerchantAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "MerchantAccounts",
                        principalColumns: new[] { "Id", "AccountType" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactAddresses_StaffAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "StaffAccounts",
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
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerType = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactEmails_MerchantAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "MerchantAccounts",
                        principalColumns: new[] { "Id", "AccountType" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactEmails_StaffAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "StaffAccounts",
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
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerType = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPhones_MerchantAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "MerchantAccounts",
                        principalColumns: new[] { "Id", "AccountType" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactPhones_StaffAccounts_OwnerID_OwnerType",
                        columns: x => new { x.OwnerID, x.OwnerType },
                        principalTable: "StaffAccounts",
                        principalColumns: new[] { "Id", "AccountType" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StaffAccounts",
                columns: new[] { "Id", "Account", "AccountType", "CreateBy", "CreateDate", "FirstName", "LastName", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { 1, "admin", (byte)1, 1, new DateTime(2021, 5, 11, 16, 58, 44, 705, DateTimeKind.Local).AddTicks(4154), "管理", "員", (byte)1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_CMSPermissions_CMSFunctionId",
                table: "CMSPermissions",
                column: "CMSFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_CMSPermissions_StaffAccountId",
                table: "CMSPermissions",
                column: "StaffAccountId");

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
                name: "IX_OrderFees_OrderId",
                table: "OrderFees",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTransactions_OrderId",
                table: "OrderTransactions",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMSPermissions");

            migrationBuilder.DropTable(
                name: "CMSRoleMember");

            migrationBuilder.DropTable(
                name: "ContactAddresses");

            migrationBuilder.DropTable(
                name: "ContactEmails");

            migrationBuilder.DropTable(
                name: "ContactPhones");

            migrationBuilder.DropTable(
                name: "ManagerList");

            migrationBuilder.DropTable(
                name: "OrderFees");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderTransactions");

            migrationBuilder.DropTable(
                name: "CMSFunction");

            migrationBuilder.DropTable(
                name: "MerchantAccounts");

            migrationBuilder.DropTable(
                name: "StaffAccounts");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
