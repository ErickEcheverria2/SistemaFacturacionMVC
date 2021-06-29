using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaFacturacionMVC.Migrations
{
    public partial class Migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_Productos_facturas_numero_factura",
                table: "factura_Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_factura_Productos_Productos_codigo_producto",
                table: "factura_Productos");

            migrationBuilder.AddForeignKey(
                name: "FK_factura_Productos_facturas_numero_factura",
                table: "factura_Productos",
                column: "numero_factura",
                principalTable: "facturas",
                principalColumn: "numero_factura",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_factura_Productos_Productos_codigo_producto",
                table: "factura_Productos",
                column: "codigo_producto",
                principalTable: "Productos",
                principalColumn: "codigo_producto",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_Productos_facturas_numero_factura",
                table: "factura_Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_factura_Productos_Productos_codigo_producto",
                table: "factura_Productos");

            migrationBuilder.AddForeignKey(
                name: "FK_factura_Productos_facturas_numero_factura",
                table: "factura_Productos",
                column: "numero_factura",
                principalTable: "facturas",
                principalColumn: "numero_factura",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_factura_Productos_Productos_codigo_producto",
                table: "factura_Productos",
                column: "codigo_producto",
                principalTable: "Productos",
                principalColumn: "codigo_producto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
