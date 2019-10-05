using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SharedFund.Migrations
{
    public partial class SeedEmpl3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WithdrawalsRules");
        }
    }
}
