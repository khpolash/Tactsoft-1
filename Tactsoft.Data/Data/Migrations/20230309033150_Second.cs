using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactsoft.Data.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Nominees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date", "Intime", "OutTime" },
                values: new object[] { new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 3, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 9, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Nominees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Picture",
                value: "zsdfasdf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Nominees");

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date", "Intime", "OutTime" },
                values: new object[] { new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 3, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 7, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
