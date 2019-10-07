using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SharedFund.Migrations
{
    public partial class InitSeedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Salary = table.Column<double>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawalsRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BalanceFrom = table.Column<double>(nullable: false),
                    BalanceTo = table.Column<double>(nullable: false),
                    PercentageLimit = table.Column<int>(nullable: false),
                    FixedMoney = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalsRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Entry = table.Column<double>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundAccounts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "Name", "Salary" },
                values: new object[,]
                {
                    { 100, new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark Zaruch", 200000.32000000001 },
                    { 101, new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Slavikov", 1350.2 },
                    { 102, new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduardo Cerqueira", 58483.980000000003 },
                    { 103, new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andre Ariano", 52483.580000000002 }
                });

            migrationBuilder.InsertData(
                table: "WithdrawalsRules",
                columns: new[] { "Id", "BalanceFrom", "BalanceTo", "FixedMoney", "PercentageLimit" },
                values: new object[,]
                {
                    { 100, 0.0, 500.0, 0.0, 50 },
                    { 101, 500.00999999999999, 1000.0, 50.0, 40 },
                    { 102, 1000.01, 5000.0, 150.0, 30 },
                    { 103, 5000.0100000000002, 10000.0, 650.0, 20 },
                    { 104, 10000.01, 15000.0, 1150.0, 15 },
                    { 105, 15000.01, 20000.0, 1900.0, 10 },
                    { 106, 20000.009999999998, -1.0, 2900.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "FundAccounts",
                columns: new[] { "Id", "EmployeeId", "Entry", "EntryDate" },
                values: new object[,]
                {
                    { 100, 100, 16000.0, new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 100, 16000.0, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 101, 108.01000000000001, new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103, 101, 108.01000000000001, new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, 101, 108.01000000000001, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, 102, 4678.7200000000003, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106, 102, 4678.7200000000003, new DateTime(2019, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, 102, 4678.7200000000003, new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108, 103, 4198.6800000000003, new DateTime(2019, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, 103, 4198.6800000000003, new DateTime(2019, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, 103, 4198.6800000000003, new DateTime(2019, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 103, -3549.75, new DateTime(2019, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundAccounts_EmployeeId",
                table: "FundAccounts",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundAccounts");

            migrationBuilder.DropTable(
                name: "WithdrawalsRules");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
