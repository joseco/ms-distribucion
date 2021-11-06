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
    public class ItemViajeEntityConfiguration : IEntityTypeConfiguration<ItemViaje>
    {
        public void Configure(EntityTypeBuilder<ItemViaje> builder)
        {
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasColumnName("itemViajeId");

            builder.Property(x => x.Cantidad)
                .IsRequired()
                .HasPrecision(6)
                .HasColumnName("cantidad");

            builder.Property(x => x.ItemId)
                .HasColumnName("itemId")
                .IsRequired();

            builder.Property(x => x.ViajeId)
               .HasColumnName("viajeEntregaId")
               .IsRequired();
        }
    }
}
