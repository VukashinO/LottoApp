using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModels.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedRound",
                value: new DateTime(2019, 8, 27, 17, 8, 1, 322, DateTimeKind.Local).AddTicks(5759));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedRound",
                value: new DateTime(2019, 8, 27, 16, 46, 48, 435, DateTimeKind.Local).AddTicks(2578));
        }
    }
}
