using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackendApiLogistica.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bodegas",
                columns: table => new
                {
                    BodegaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Ubicacion = table.Column<string>(type: "text", nullable: false),
                    Capacidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodegas", x => x.BodegaID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoID);
                });

            migrationBuilder.CreateTable(
                name: "Puertos",
                columns: table => new
                {
                    PuertoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Ubicacion = table.Column<string>(type: "text", nullable: false),
                    Capacidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puertos", x => x.PuertoID);
                });

            migrationBuilder.CreateTable(
                name: "EnviosTerrestres",
                columns: table => new
                {
                    EnvioTerrestreID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteID = table.Column<int>(type: "integer", nullable: false),
                    ProductoID = table.Column<int>(type: "integer", nullable: false),
                    CantidadProducto = table.Column<int>(type: "integer", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BodegaID = table.Column<int>(type: "integer", nullable: false),
                    PrecioEnvio = table.Column<decimal>(type: "numeric", nullable: false),
                    PlacaVehiculo = table.Column<string>(type: "text", nullable: false),
                    NumeroGuia = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnviosTerrestres", x => x.EnvioTerrestreID);
                    table.ForeignKey(
                        name: "FK_EnviosTerrestres_Bodegas_BodegaID",
                        column: x => x.BodegaID,
                        principalTable: "Bodegas",
                        principalColumn: "BodegaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviosTerrestres_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviosTerrestres_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnviosMaritimos",
                columns: table => new
                {
                    EnvioMaritimoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteID = table.Column<int>(type: "integer", nullable: false),
                    ProductoID = table.Column<int>(type: "integer", nullable: false),
                    CantidadProducto = table.Column<int>(type: "integer", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PuertoID = table.Column<int>(type: "integer", nullable: false),
                    PrecioEnvio = table.Column<decimal>(type: "numeric", nullable: false),
                    NumeroFlota = table.Column<string>(type: "text", nullable: false),
                    NumeroGuia = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnviosMaritimos", x => x.EnvioMaritimoID);
                    table.ForeignKey(
                        name: "FK_EnviosMaritimos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviosMaritimos_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviosMaritimos_Puertos_PuertoID",
                        column: x => x.PuertoID,
                        principalTable: "Puertos",
                        principalColumn: "PuertoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnviosMaritimos_ClienteID",
                table: "EnviosMaritimos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosMaritimos_ProductoID",
                table: "EnviosMaritimos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosMaritimos_PuertoID",
                table: "EnviosMaritimos",
                column: "PuertoID");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosTerrestres_BodegaID",
                table: "EnviosTerrestres",
                column: "BodegaID");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosTerrestres_ClienteID",
                table: "EnviosTerrestres",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosTerrestres_ProductoID",
                table: "EnviosTerrestres",
                column: "ProductoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnviosMaritimos");

            migrationBuilder.DropTable(
                name: "EnviosTerrestres");

            migrationBuilder.DropTable(
                name: "Puertos");

            migrationBuilder.DropTable(
                name: "Bodegas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
