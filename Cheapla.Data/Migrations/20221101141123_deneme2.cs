using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cheapla.Data.Migrations
{
    public partial class deneme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 17, 11, 23, 105, DateTimeKind.Local).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 17, 11, 23, 105, DateTimeKind.Local).AddTicks(113));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 23, 3, 52, 2, 564, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 23, 3, 52, 2, 564, DateTimeKind.Local).AddTicks(1627));
        }
    }
}
