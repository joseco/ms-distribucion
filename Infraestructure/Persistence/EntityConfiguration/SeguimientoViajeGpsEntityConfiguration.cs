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
    public class SeguimientoViajeGpsEntityConfiguration : IEntityTypeConfiguration<SeguimientoViajeGps>
    {
        public void Configure(EntityTypeBuilder<SeguimientoViajeGps> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("segimientoViajeId");

            builder.Property(x => x.FechaHora)
                .HasColumnName("fechaHora")
                .IsRequired();

            builder.Property(x => x.ViajeId)
                .HasColumnName("viajeId")
                .IsRequired();

            builder.OwnsOne(x => x.Ubicacion)
                .Property(x => x.Latitud)
                .HasColumnName("latitud")
                .IsRequired()
                .HasPrecision(18, 12);


            builder.OwnsOne(x => x.Ubicacion)
                .Property(x => x.Longitud)
                .HasColumnName("longitud")
                .IsRequired()
                .HasPrecision(18, 12);
        }
    }
}
