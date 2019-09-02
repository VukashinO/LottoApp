using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModels.Migrations
{
    public partial class RemovedConfirmedPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedRound",
                value: new DateTime(2019, 8, 29, 16, 11, 13, 861, DateTimeKind.Local).AddTicks(4007));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedRound",
                value: new DateTime(2019, 8, 29, 16, 8, 44, 592, DateTimeKind.Local).AddTicks(7793));
        }
    }
}
