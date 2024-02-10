using BackendApiLogistica.Data.Models; // Asegúrate de que tus modelos estén en este espacio de nombres
using Microsoft.EntityFrameworkCore;
using System; // Este using puede ser necesario dependiendo de los tipos de datos que uses en tus modelos

namespace BackendApiLogistica.Data
{
    public class GestionLogisticaContext : DbContext
    {
        public GestionLogisticaContext(DbContextOptions<GestionLogisticaContext> options)
            : base(options)
        {
        }

        // Propiedades DbSet para tus entidades
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Puerto> Puertos { get; set; }
        public DbSet<EnvioTerrestre> EnviosTerrestres { get; set; }
        public DbSet<EnvioMaritimo> EnviosMaritimos { get; set; }
    }
}
