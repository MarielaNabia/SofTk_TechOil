using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SofTk_TechOil.Migrations
{
    public partial class entityProyectoServiciotrabajos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    CodProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.CodProyecto);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    CodServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.CodServicio);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    codTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodProyecto = table.Column<int>(type: "int", nullable: false),
                    ProjectCodProyecto = table.Column<int>(type: "int", nullable: true),
                    CodServicio = table.Column<int>(type: "int", nullable: false),
                    ServiceCodServicio = table.Column<int>(type: "int", nullable: true),
                    CantHoras = table.Column<int>(type: "int", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.codTrabajo);
                    table.ForeignKey(
                        name: "FK_Jobs_Projects_ProjectCodProyecto",
                        column: x => x.ProjectCodProyecto,
                        principalTable: "Projects",
                        principalColumn: "CodProyecto");
                    table.ForeignKey(
                        name: "FK_Jobs_Services_ServiceCodServicio",
                        column: x => x.ServiceCodServicio,
                        principalTable: "Services",
                        principalColumn: "CodServicio");
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "codTrabajo", "Activo", "CantHoras", "CodProyecto", "CodServicio", "Costo", "Fecha", "ProjectCodProyecto", "ServiceCodServicio", "ValorHora" },
                values: new object[] { 1, true, 10000, 1, 2, 2600000m, new DateTime(2023, 9, 23, 12, 43, 32, 561, DateTimeKind.Local).AddTicks(4929), null, null, 260m });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "CodProyecto", "Activo", "Direccion", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "AV. Carcano 200, Cordoba", 1, "Villa Carlos Paz III" },
                    { 2, true, "Km 451, Rio Negro", 2, "Vaca Muerta" },
                    { 3, true, "Litoral 241, Rio Gallegos", 3, "Sucursal 154" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "CodServicio", "Activo", "Descripcion", "Estado", "ValorHora" },
                values: new object[,]
                {
                    { 1, true, "PerforacionPozzo100", true, 1500m },
                    { 2, true, "ExtraccionCapa2", true, 1400m },
                    { 3, true, "TransporteKM", true, 1300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectCodProyecto",
                table: "Jobs",
                column: "ProjectCodProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ServiceCodServicio",
                table: "Jobs",
                column: "ServiceCodServicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
