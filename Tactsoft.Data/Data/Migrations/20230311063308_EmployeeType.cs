using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactsoft.Data.Data.Migrations
{
    public partial class EmployeeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sat = table.Column<bool>(type: "bit", nullable: false),
                    Sun = table.Column<bool>(type: "bit", nullable: false),
                    Mon = table.Column<bool>(type: "bit", nullable: false),
                    Tue = table.Column<bool>(type: "bit", nullable: false),
                    Wed = table.Column<bool>(type: "bit", nullable: false),
                    Thu = table.Column<bool>(type: "bit", nullable: false),
                    Fri = table.Column<bool>(type: "bit", nullable: false),
                    DateOfParmanent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesignationId = table.Column<long>(type: "bigint", nullable: false),
                    DepertmentId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceInformations_Departments_DepertmentId",
                        column: x => x.DepertmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceInformations_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceInformations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date", "Intime", "OutTime" },
                values: new object[] { new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 3, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDateUtc", "DateOfParmanent", "Fri", "Mon", "Remarks", "Sat", "Sun", "Thu", "Tue", "UpdatedBy", "UpdatedDateUtc", "Wed" },
                values: new object[] { 1L, 0L, new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)), new DateTime(2023, 1, 2, 0, 3, 0, 0, DateTimeKind.Unspecified), false, false, "Good", false, false, false, false, null, null, false });

            migrationBuilder.InsertData(
                table: "ServiceInformations",
                columns: new[] { "Id", "CreatedBy", "CreatedDateUtc", "DateOfJoining", "DepertmentId", "DesignationId", "EmployeeId", "UpdatedBy", "UpdatedDateUtc" },
                values: new object[] { 1L, 0L, new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)), new DateTime(2023, 1, 2, 0, 3, 0, 0, DateTimeKind.Unspecified), 1L, 1L, 1L, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInformations_DepertmentId",
                table: "ServiceInformations",
                column: "DepertmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInformations_DesignationId",
                table: "ServiceInformations",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInformations_EmployeeId",
                table: "ServiceInformations",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "ServiceInformations");

            migrationBuilder.UpdateData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date", "Intime", "OutTime" },
                values: new object[] { new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 3, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 9, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
