using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModels.Migrations
{
    public partial class AddedTwoColumnsInRounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lose",
                table: "Rounds",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Profit",
                table: "Rounds",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedRound",
                value: new DateTime(2019, 8, 30, 14, 20, 33, 203, DateTimeKind.Local).AddTicks(2934));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lose",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Profit",
                table: "Rounds");

            migrationBuilder.UpdateData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedRound",
                value: new DateTime(2019, 8, 29, 16, 11, 13, 861, DateTimeKind.Local).AddTicks(4007));
        }
    }
}
