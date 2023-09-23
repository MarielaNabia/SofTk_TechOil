using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SofTk_TechOil.Migrations
{
    public partial class entityprojectServiceJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "codTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 23, 12, 46, 58, 541, DateTimeKind.Local).AddTicks(9464));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "codTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 23, 12, 43, 32, 561, DateTimeKind.Local).AddTicks(4929));
        }
    }
}
