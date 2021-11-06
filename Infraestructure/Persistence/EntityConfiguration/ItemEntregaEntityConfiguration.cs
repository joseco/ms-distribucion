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
    public class ItemEntregaEntityConfiguration : IEntityTypeConfiguration<ItemEntrega>
    {
        public void Configure(EntityTypeBuilder<ItemEntrega> builder)
        {
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasColumnName("itemEntregaId");

            builder.Property(x => x.Cantidad)
                .IsRequired()
                .HasPrecision(6)
                .HasColumnName("cantidad");

            builder.Property(x => x.Entregado)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("entregado");

            builder.Property(x => x.ItemId)
                .HasColumnName("itemId")
                .IsRequired();

            ////builder
            ////    .HasOne(x => x.Item);

            builder.Property(x => x.OrdenEntregaId)
               .HasColumnName("ordenEntregaId")
               .IsRequired();

            //builder
            //    .HasOne(x => x.OrdenEntrega);
        }
    }
}
