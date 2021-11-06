using Domain.Model;
using Infraestructure.Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<OrdenEntrega> OrdenEntrega { get; set; }
        public DbSet<Viaje> Viaje { get; set; }
        public DbSet<SeguimientoViajeGps> SeguimientoViajeGps { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemEntrega> ItemEntrega { get; set; }
        public DbSet<ItemViaje> ItemViaje { get; set; }
        public DbSet<SeguimientoViajeGps> SeguimientoViaje { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrdenEntregaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItemEntregaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ViajeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItemViajeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SeguimientoViajeGpsEntityConfiguration());


        }
    }
}
