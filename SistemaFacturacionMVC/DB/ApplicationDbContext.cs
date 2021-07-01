using Microsoft.EntityFrameworkCore;
using SistemaFacturacionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Creado y modificado por: Erick Eduardo Echeverría Garrido - 14/06/2021

namespace SistemaFacturacionMVC.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura_Producto>()
            .HasKey(p => new { p.numero_factura, p.codigo_producto });

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        } 


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> facturas { get; set; }
        public DbSet<Factura_Producto> factura_Productos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<P_VENTAS_PRODUCTO_FILTRADO_CODIGOP> P_VENTAS_PRODUCTO { get; set; }
        public DbSet<P_VENTAS_CLIENTE> P_VENTAS_CLIENTE { get; set; }
        public DbSet<P_REPORTE_FACTURAS> P_REPORTE_FACTURAS { get; set; }

    }
}
