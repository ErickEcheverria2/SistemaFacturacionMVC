﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaFacturacionMVC.DB;

namespace SistemaFacturacionMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaFacturacionMVC.Models.Cliente", b =>
                {
                    b.Property<int>("codigo_cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("activo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefonos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codigo_cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaFacturacionMVC.Models.Factura", b =>
                {
                    b.Property<int>("numero_factura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("anulada")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("codigo_cliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("total_factura")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("numero_factura");

                    b.HasIndex("codigo_cliente");

                    b.ToTable("facturas");
                });

            modelBuilder.Entity("SistemaFacturacionMVC.Models.Factura_Producto", b =>
                {
                    b.Property<int?>("numero_factura")
                        .HasColumnType("int");

                    b.Property<int?>("codigo_producto")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("precio_unitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("numero_factura", "codigo_producto");

                    b.HasIndex("codigo_producto");

                    b.ToTable("factura_Productos");
                });

            modelBuilder.Entity("SistemaFacturacionMVC.Models.Producto", b =>
                {
                    b.Property<int>("codigo_producto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("activo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<decimal>("costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("existencia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("tipo_producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codigo_producto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("SistemaFacturacionMVC.Models.Usuario", b =>
                {
                    b.Property<int>("codigo_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codigo_usuario");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("SistemaFacturacionMVC.Models.Factura", b =>
                {
                    b.HasOne("SistemaFacturacionMVC.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("codigo_cliente")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SistemaFacturacionMVC.Models.Factura_Producto", b =>
                {
                    b.HasOne("SistemaFacturacionMVC.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("codigo_producto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaFacturacionMVC.Models.Factura", "Factura")
                        .WithMany()
                        .HasForeignKey("numero_factura")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Producto");
                });
#pragma warning restore 612, 618
        }
    }
}
