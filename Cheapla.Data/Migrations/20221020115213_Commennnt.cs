using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cheapla.Data.Migrations
{
    public partial class Commennnt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 20, 14, 52, 13, 461, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 20, 14, 52, 13, 461, DateTimeKind.Local).AddTicks(2002));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 20, 14, 51, 10, 361, DateTimeKind.Local).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 20, 14, 51, 10, 361, DateTimeKind.Local).AddTicks(6682));
        }
    }
}
