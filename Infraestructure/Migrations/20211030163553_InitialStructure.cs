using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    itemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.itemId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenEntrega",
                columns: table => new
                {
                    ordenEntregaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaConsolidacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: false),
                    destinatario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ubicacionLatitud = table.Column<decimal>(type: "decimal(12,8)", precision: 12, scale: 8, nullable: true),
                    ubicacionLongitud = table.Column<decimal>(type: "decimal(12,8)", precision: 12, scale: 8, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenEntrega", x => x.ordenEntregaId);
                });

            migrationBuilder.CreateTable(
                name: "Viaje",
                columns: table => new
                {
                    viajeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ordenEntregaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaProgramacion = table.Column<DateTime>(type: "Date", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaFin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaje", x => x.viajeId);
                });

            migrationBuilder.CreateTable(
                name: "ItemEntrega",
                columns: table => new
                {
                    itemEntregaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    itemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ordenEntregaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", precision: 6, nullable: false),
                    entregado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEntrega", x => x.itemEntregaId);
                    table.ForeignKey(
                        name: "FK_ItemEntrega_Item_itemId",
                        column: x => x.itemId,
                        principalTable: "Item",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemEntrega_OrdenEntrega_ordenEntregaId",
                        column: x => x.ordenEntregaId,
                        principalTable: "OrdenEntrega",
                        principalColumn: "ordenEntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemViaje",
                columns: table => new
                {
                    itemViajeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    itemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    viajeEntregaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemViaje", x => x.itemViajeId);
                    table.ForeignKey(
                        name: "FK_ItemViaje_Item_itemId",
                        column: x => x.itemId,
                        principalTable: "Item",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemViaje_Viaje_viajeEntregaId",
                        column: x => x.viajeEntregaId,
                        principalTable: "Viaje",
                        principalColumn: "viajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeguimientoViajeGps",
                columns: table => new
                {
                    segimientoViajeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    viajeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    latitud = table.Column<decimal>(type: "decimal(18,12)", precision: 18, scale: 12, nullable: true),
                    longitud = table.Column<decimal>(type: "decimal(18,12)", precision: 18, scale: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoViajeGps", x => x.segimientoViajeId);
                    table.ForeignKey(
                        name: "FK_SeguimientoViajeGps_Viaje_viajeId",
                        column: x => x.viajeId,
                        principalTable: "Viaje",
                        principalColumn: "viajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntrega_itemId",
                table: "ItemEntrega",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntrega_ordenEntregaId",
                table: "ItemEntrega",
                column: "ordenEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemViaje_itemId",
                table: "ItemViaje",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemViaje_viajeEntregaId",
                table: "ItemViaje",
                column: "viajeEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientoViajeGps_viajeId",
                table: "SeguimientoViajeGps",
                column: "viajeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemEntrega");

            migrationBuilder.DropTable(
                name: "ItemViaje");

            migrationBuilder.DropTable(
                name: "SeguimientoViajeGps");

            migrationBuilder.DropTable(
                name: "OrdenEntrega");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Viaje");
        }
    }
}
