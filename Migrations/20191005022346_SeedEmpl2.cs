using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SharedFund.Migrations
{
    public partial class SeedEmpl2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "FundAccounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 100,
                column: "BirthDate",
                value: new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                column: "BirthDate",
                value: new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "FundAccounts",
                columns: new[] { "Id", "EmployeeId", "Entry", "EntryDate" },
                values: new object[,]
                {
                    { 100, 100, 16000.0, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 101, 104.0, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FundAccounts",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "FundAccounts",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "FundAccounts");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 100,
                column: "BirthDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                column: "BirthDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
