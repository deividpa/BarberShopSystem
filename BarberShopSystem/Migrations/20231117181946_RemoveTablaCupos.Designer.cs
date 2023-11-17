﻿// <auto-generated />
using System;
using BarberShopSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BarberShopSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231117181946_RemoveTablaCupos")]
    partial class RemoveTablaCupos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BarberShopSystem.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BarberShopSystem.Models.Profesional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Profesionales");
                });

            modelBuilder.Entity("BarberShopSystem.Models.ProfesionalServicio", b =>
                {
                    b.Property<int>("ProfesionalId")
                        .HasColumnType("int");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("ProfesionalId", "ServicioId");

                    b.HasIndex("ServicioId");

                    b.ToTable("ProfesionalServicios");
                });

            modelBuilder.Entity("BarberShopSystem.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("EstadoReserva")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Novedad")
                        .HasColumnType("longtext");

                    b.Property<int>("ProfesionalId")
                        .HasColumnType("int");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProfesionalId");

                    b.HasIndex("ServicioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("BarberShopSystem.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("BarberShopSystem.Models.ProfesionalServicio", b =>
                {
                    b.HasOne("BarberShopSystem.Models.Profesional", "Profesional")
                        .WithMany("ProfesionalServicios")
                        .HasForeignKey("ProfesionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberShopSystem.Models.Servicio", "Servicio")
                        .WithMany("ProfesionalServicios")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profesional");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("BarberShopSystem.Models.Reserva", b =>
                {
                    b.HasOne("BarberShopSystem.Models.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberShopSystem.Models.Profesional", "Profesional")
                        .WithMany("Reservas")
                        .HasForeignKey("ProfesionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberShopSystem.Models.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Profesional");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("BarberShopSystem.Models.Cliente", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("BarberShopSystem.Models.Profesional", b =>
                {
                    b.Navigation("ProfesionalServicios");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("BarberShopSystem.Models.Servicio", b =>
                {
                    b.Navigation("ProfesionalServicios");
                });
#pragma warning restore 612, 618
        }
    }
}
