using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.EntityConfiguration
{
    public class ViajeEntityConfiguration : IEntityTypeConfiguration<Viaje>
    {
        public void Configure(EntityTypeBuilder<Viaje> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("viajeId");

            builder.Property(x => x.OrdenEntregaId)
                .HasColumnName("ordenEntregaId");

            builder.Property(x => x.FechaProgramacion)
                .HasColumnName("fechaProgramacion")
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(x => x.FechaInicio)
                .HasColumnName("fechaInicio");

            builder.Property(x => x.FechaFin)
                .HasColumnName("fechaFin");

            builder.HasMany(x => x.SeguimientoGps)
                .WithOne(x => x.Viaje);

            builder.HasMany(x => x.ItemsViaje)
                .WithOne(x => x.Viaje);

        }
    }
}
