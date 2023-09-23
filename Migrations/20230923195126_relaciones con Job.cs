using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SofTk_TechOil.Migrations
{
    public partial class relacionesconJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Costo",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "codTrabajo",
                table: "Jobs",
                newName: "CodTrabajo");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "CodTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 23, 16, 51, 25, 867, DateTimeKind.Local).AddTicks(3994));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodTrabajo",
                table: "Jobs",
                newName: "codTrabajo");

            migrationBuilder.AddColumn<decimal>(
                name: "Costo",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "codTrabajo",
                keyValue: 1,
                columns: new[] { "Costo", "Fecha" },
                values: new object[] { 2600000m, new DateTime(2023, 9, 23, 12, 46, 58, 541, DateTimeKind.Local).AddTicks(9464) });
        }
    }
}
