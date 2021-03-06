// <auto-generated />
using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211030163553_InitialStructure")]
    partial class InitialStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Model.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("itemId");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("codigo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("descripcion");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Domain.Model.ItemEntrega", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("itemEntregaId");

                    b.Property<int>("Cantidad")
                        .HasPrecision(6)
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<bool>("Entregado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("entregado");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("itemId");

                    b.Property<Guid>("OrdenEntregaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ordenEntregaId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrdenEntregaId");

                    b.ToTable("ItemEntrega");
                });

            modelBuilder.Entity("Domain.Model.ItemViaje", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("itemViajeId");

                    b.Property<int>("Cantidad")
                        .HasPrecision(6)
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("itemId");

                    b.Property<Guid>("ViajeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("viajeEntregaId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ViajeId");

                    b.ToTable("ItemViaje");
                });

            modelBuilder.Entity("Domain.Model.OrdenEntrega", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ordenEntregaId");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)")
                        .HasColumnName("direccion");

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("FechaAnulacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaAnulacion");

                    b.Property<DateTime?>("FechaConsolidacion")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaConsolidacion");

                    b.Property<DateTime?>("FechaFinalizacion")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaConsolidacion");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaRegistro");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("OrdenEntrega");
                });

            modelBuilder.Entity("Domain.Model.SeguimientoViajeGps", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("segimientoViajeId");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaHora");

                    b.Property<Guid>("ViajeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("viajeId");

                    b.HasKey("Id");

                    b.HasIndex("ViajeId");

                    b.ToTable("SeguimientoViajeGps");
                });

            modelBuilder.Entity("Domain.Model.Viaje", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("viajeId");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaFin");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaInicio");

                    b.Property<DateTime>("FechaProgramacion")
                        .HasColumnType("Date")
                        .HasColumnName("fechaProgramacion");

                    b.Property<Guid>("OrdenEntregaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ordenEntregaId");

                    b.HasKey("Id");

                    b.ToTable("Viaje");
                });

            modelBuilder.Entity("Domain.Model.ItemEntrega", b =>
                {
                    b.HasOne("Domain.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.OrdenEntrega", "OrdenEntrega")
                        .WithMany("Items")
                        .HasForeignKey("OrdenEntregaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("OrdenEntrega");
                });

            modelBuilder.Entity("Domain.Model.ItemViaje", b =>
                {
                    b.HasOne("Domain.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Viaje", "Viaje")
                        .WithMany("ItemsViaje")
                        .HasForeignKey("ViajeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Viaje");
                });

            modelBuilder.Entity("Domain.Model.OrdenEntrega", b =>
                {
                    b.OwnsOne("CoreDDD.ValueObjects.GpsPositionValue", "UbicacionGps", b1 =>
                        {
                            b1.Property<Guid>("OrdenEntregaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Latitud")
                                .HasPrecision(12, 8)
                                .HasColumnType("decimal(12,8)")
                                .HasColumnName("ubicacionLatitud");

                            b1.Property<decimal>("Longitud")
                                .HasPrecision(12, 8)
                                .HasColumnType("decimal(12,8)")
                                .HasColumnName("ubicacionLongitud");

                            b1.HasKey("OrdenEntregaId");

                            b1.ToTable("OrdenEntrega");

                            b1.WithOwner()
                                .HasForeignKey("OrdenEntregaId");
                        });

                    b.OwnsOne("CoreDDD.ValueObjects.PersonNameValue", "Destinatario", b1 =>
                        {
                            b1.Property<Guid>("OrdenEntregaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasColumnName("destinatario");

                            b1.HasKey("OrdenEntregaId");

                            b1.ToTable("OrdenEntrega");

                            b1.WithOwner()
                                .HasForeignKey("OrdenEntregaId");
                        });

                    b.Navigation("Destinatario");

                    b.Navigation("UbicacionGps");
                });

            modelBuilder.Entity("Domain.Model.SeguimientoViajeGps", b =>
                {
                    b.HasOne("Domain.Model.Viaje", "Viaje")
                        .WithMany("SeguimientoGps")
                        .HasForeignKey("ViajeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CoreDDD.ValueObjects.GpsPositionValue", "Ubicacion", b1 =>
                        {
                            b1.Property<Guid>("SeguimientoViajeGpsId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Latitud")
                                .HasPrecision(18, 12)
                                .HasColumnType("decimal(18,12)")
                                .HasColumnName("latitud");

                            b1.Property<decimal>("Longitud")
                                .HasPrecision(18, 12)
                                .HasColumnType("decimal(18,12)")
                                .HasColumnName("longitud");

                            b1.HasKey("SeguimientoViajeGpsId");

                            b1.ToTable("SeguimientoViajeGps");

                            b1.WithOwner()
                                .HasForeignKey("SeguimientoViajeGpsId");
                        });

                    b.Navigation("Ubicacion");

                    b.Navigation("Viaje");
                });

            modelBuilder.Entity("Domain.Model.OrdenEntrega", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Domain.Model.Viaje", b =>
                {
                    b.Navigation("ItemsViaje");

                    b.Navigation("SeguimientoGps");
                });
#pragma warning restore 612, 618
        }
    }
}
