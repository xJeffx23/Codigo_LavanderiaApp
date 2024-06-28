using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavanderiaApp.Migrations
{
    /// <inheritdoc />
    public partial class Migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cedula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "EstadosServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosServicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPrenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPrenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposTela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTela", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prendas",
                columns: table => new
                {
                    IdPrenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CedulaPropietario = table.Column<int>(type: "int", nullable: false),
                    TipoPrendaId = table.Column<int>(type: "int", nullable: false),
                    TipoTelaId = table.Column<int>(type: "int", nullable: false),
                    EspecificacionesLavado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prendas", x => x.IdPrenda);
                    table.ForeignKey(
                        name: "FK_Prendas_Clientes_CedulaPropietario",
                        column: x => x.CedulaPropietario,
                        principalTable: "Clientes",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prendas_TiposPrenda_TipoPrendaId",
                        column: x => x.TipoPrendaId,
                        principalTable: "TiposPrenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prendas_TiposTela_TipoTelaId",
                        column: x => x.TipoTelaId,
                        principalTable: "TiposTela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prendaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrendaIdPrenda = table.Column<int>(type: "int", nullable: false),
                    cedulaPropietario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaRecibo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoServicioId = table.Column<int>(type: "int", nullable: false),
                    fechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_EstadosServicio_estadoServicioId",
                        column: x => x.estadoServicioId,
                        principalTable: "EstadosServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicios_Prendas_PrendaIdPrenda",
                        column: x => x.PrendaIdPrenda,
                        principalTable: "Prendas",
                        principalColumn: "IdPrenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prendas_CedulaPropietario",
                table: "Prendas",
                column: "CedulaPropietario");

            migrationBuilder.CreateIndex(
                name: "IX_Prendas_TipoPrendaId",
                table: "Prendas",
                column: "TipoPrendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prendas_TipoTelaId",
                table: "Prendas",
                column: "TipoTelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_estadoServicioId",
                table: "Servicios",
                column: "estadoServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_PrendaIdPrenda",
                table: "Servicios",
                column: "PrendaIdPrenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "EstadosServicio");

            migrationBuilder.DropTable(
                name: "Prendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposPrenda");

            migrationBuilder.DropTable(
                name: "TiposTela");
        }
    }
}
