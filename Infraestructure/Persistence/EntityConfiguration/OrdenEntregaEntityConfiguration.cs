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
    public class OrdenEntregaEntityConfiguration : IEntityTypeConfiguration<OrdenEntrega>
    {
        public void Configure(EntityTypeBuilder<OrdenEntrega> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ordenEntregaId");

            builder.Property(x => x.FechaRegistro)
                .HasColumnName("fechaRegistro")
                .IsRequired();

            builder.Property(x => x.FechaAnulacion)
                .HasColumnName("fechaAnulacion");

            builder.Property(x => x.FechaConsolidacion)
                .HasColumnName("fechaConsolidacion");

            builder.Property(x => x.FechaFinalizacion)
                .HasColumnName("fechaConsolidacion");

            builder.Property(x => x.Estado)
                .HasColumnName("estado")
                .IsRequired();

            builder.OwnsOne(x => x.Destinatario)
                .Property(x => x.Value)
                .HasColumnName("destinatario")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono")
                .IsRequired();

            builder.Property(x => x.Direccion)
                .HasMaxLength(800)
                .HasColumnName("direccion")
                .IsRequired();

            builder.OwnsOne(x => x.UbicacionGps)
                .Property(x => x.Latitud)
                .HasColumnName("ubicacionLatitud")
                .HasPrecision(12,8);


            builder.OwnsOne(x => x.UbicacionGps)
                .Property(x => x.Longitud)
                .HasColumnName("ubicacionLongitud")
                .HasPrecision(12, 8);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.OrdenEntrega);

        }
    }
}
