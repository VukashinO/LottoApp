using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModels.Migrations
{
    public partial class AddedUserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prize",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedRound",
                value: new DateTime(2019, 8, 29, 16, 8, 44, 592, DateTimeKind.Local).AddTicks(7793));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Prize",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedRound",
                value: new DateTime(2019, 8, 27, 17, 8, 1, 322, DateTimeKind.Local).AddTicks(5759));
        }
    }
}
