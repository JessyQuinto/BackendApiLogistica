using BackendApiLogistica.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackendApiLogistica.Data
{
    public class GestionLogisticaContext : DbContext
    {
        public GestionLogisticaContext(DbContextOptions<GestionLogisticaContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Puerto> Puertos { get; set; }
        public DbSet<EnvioTerrestre> EnviosTerrestres { get; set; }
        public DbSet<EnvioMaritimo> EnviosMaritimos { get; set; }
    }
}
