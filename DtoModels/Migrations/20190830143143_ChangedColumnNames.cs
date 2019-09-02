using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModels.Migrations
{
    public partial class ChangedColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Profit",
                table: "Rounds",
                newName: "PayOut");

            migrationBuilder.RenameColumn(
                name: "Lose",
                table: "Rounds",
                newName: "PayIn");

            migrationBuilder.UpdateData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedRound",
                value: new DateTime(2019, 8, 30, 16, 31, 43, 726, DateTimeKind.Local).AddTicks(575));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayOut",
                table: "Rounds",
                newName: "Profit");

            migrationBuilder.RenameColumn(
                name: "PayIn",
                table: "Rounds",
                newName: "Lose");

            migrationBuilder.UpdateData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedRound",
                value: new DateTime(2019, 8, 30, 14, 20, 33, 203, DateTimeKind.Local).AddTicks(2934));
        }
    }
}
