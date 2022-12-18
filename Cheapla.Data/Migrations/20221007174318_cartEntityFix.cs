using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cheapla.Data.Migrations
{
    public partial class cartEntityFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 20, 43, 17, 723, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 20, 43, 17, 723, DateTimeKind.Local).AddTicks(522));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 3, 20, 8, 41, 790, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 3, 20, 8, 41, 790, DateTimeKind.Local).AddTicks(6462));
        }
    }
}
