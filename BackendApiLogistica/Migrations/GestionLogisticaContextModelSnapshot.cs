﻿// <auto-generated />
using System;
using BackendApiLogistica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackendApiLogistica.Migrations
{
    [DbContext(typeof(GestionLogisticaContext))]
    partial class GestionLogisticaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BackendApiLogistica.Data.Models.Bodega", b =>
                {
                    b.Property<int>("BodegaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BodegaID"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BodegaID");

                    b.ToTable("Bodegas");
                });

            modelBuilder.Entity("BackendApiLogistica.Data.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClienteID"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ClienteID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BackendApiLogistica.Data.Models.EnvioMaritimo", b =>
                {
                    b.Property<int>("EnvioMaritimoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EnvioMaritimoID"));

                    b.Property<int>("CantidadProducto")
                        .HasColumnType("integer");

                    b.Property<int>("ClienteID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NumeroFlota")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumeroGuia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PrecioEnvio")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductoID")
                        .HasColumnType("integer");

                    b.Property<int>("PuertoID")
                        .HasColumnType("integer");

                    b.HasKey("EnvioMaritimoID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ProductoID");

                    b.HasIndex("PuertoID");

                    b.ToTable("EnviosMaritimos");
                });

            modelBuilder.Entity("BackendApiLogistica.Data.Models.EnvioTerrestre", b =>
                {
                    b.Property<int>("EnvioTerrestreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EnvioTerrestreID"));

                    b.Property<int>("BodegaID")
                        .HasColumnType("integer");

                    b.Property<int>("CantidadProducto")
                        .HasColumnType("integer");

                    b.Property<int>("ClienteID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NumeroGuia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlacaVehiculo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PrecioEnvio")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductoID")
                        .HasColumnType("integer");

                    b.HasKey("EnvioTerrestreID");

                    b.HasIndex("BodegaID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ProductoID");

                    b.ToTable("EnviosTerrestres");
                });

            modelBuilder.Entity("BackendApiLogistica.Data.Models.Producto", b =>
                {
                    b.Property<int>("ProductoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductoID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductoID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("BackendApiLogistica.Data.Models.Puerto", b =>
                {
                    b.Property<int>("PuertoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PuertoID"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PuertoID");

                    b.ToTable("Puertos");
                });

            modelBuilder.Entity("BackendApiLogistica.Data.Models.EnvioMaritimo", b =>
                {
                    b.HasOne("BackendApiLogistica.Data.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendApiLogistica.Data.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendApiLogistica.Data.Models.Puerto", "Puerto")
                        .WithMany()
                        .HasForeignKey("PuertoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Producto");

                    b.Navigation("Puerto");
                });

            modelBuilder.Entity("BackendApiLogistica.Data.Models.EnvioTerrestre", b =>
                {
                    b.HasOne("BackendApiLogistica.Data.Models.Bodega", "Bodega")
                        .WithMany()
                        .HasForeignKey("BodegaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendApiLogistica.Data.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendApiLogistica.Data.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bodega");

                    b.Navigation("Cliente");

                    b.Navigation("Producto");
                });
#pragma warning restore 612, 618
        }
    }
}
