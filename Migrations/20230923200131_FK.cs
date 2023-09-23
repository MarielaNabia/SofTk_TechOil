using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SofTk_TechOil.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Projects_ProjectCodProyecto",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Services_ServiceCodServicio",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ProjectCodProyecto",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ServiceCodServicio",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ProjectCodProyecto",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ServiceCodServicio",
                table: "Jobs");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "CodTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 23, 17, 1, 31, 82, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CodProyecto",
                table: "Jobs",
                column: "CodProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CodServicio",
                table: "Jobs",
                column: "CodServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Projects_CodProyecto",
                table: "Jobs",
                column: "CodProyecto",
                principalTable: "Projects",
                principalColumn: "CodProyecto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Services_CodServicio",
                table: "Jobs",
                column: "CodServicio",
                principalTable: "Services",
                principalColumn: "CodServicio",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Projects_CodProyecto",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Services_CodServicio",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CodProyecto",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CodServicio",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "ProjectCodProyecto",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceCodServicio",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "CodTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 23, 16, 51, 25, 867, DateTimeKind.Local).AddTicks(3994));

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectCodProyecto",
                table: "Jobs",
                column: "ProjectCodProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ServiceCodServicio",
                table: "Jobs",
                column: "ServiceCodServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Projects_ProjectCodProyecto",
                table: "Jobs",
                column: "ProjectCodProyecto",
                principalTable: "Projects",
                principalColumn: "CodProyecto");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Services_ServiceCodServicio",
                table: "Jobs",
                column: "ServiceCodServicio",
                principalTable: "Services",
                principalColumn: "CodServicio");
        }
    }
}
