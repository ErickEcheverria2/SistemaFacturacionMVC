using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaFacturacionMVC.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    codigo_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefonos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.codigo_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    codigo_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    existencia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    activo = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.codigo_producto);
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    numero_factura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo_cliente = table.Column<int>(type: "int", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_factura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    anulada = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.numero_factura);
                    table.ForeignKey(
                        name: "FK_facturas_Clientes_codigo_cliente",
                        column: x => x.codigo_cliente,
                        principalTable: "Clientes",
                        principalColumn: "codigo_cliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "factura_Productos",
                columns: table => new
                {
                    numero_factura = table.Column<int>(type: "int", nullable: false),
                    codigo_producto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura_Productos", x => new { x.numero_factura, x.codigo_producto });
                    table.ForeignKey(
                        name: "FK_factura_Productos_facturas_numero_factura",
                        column: x => x.numero_factura,
                        principalTable: "facturas",
                        principalColumn: "numero_factura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_factura_Productos_Productos_codigo_producto",
                        column: x => x.codigo_producto,
                        principalTable: "Productos",
                        principalColumn: "codigo_producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_factura_Productos_codigo_producto",
                table: "factura_Productos",
                column: "codigo_producto");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_codigo_cliente",
                table: "facturas",
                column: "codigo_cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "factura_Productos");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
