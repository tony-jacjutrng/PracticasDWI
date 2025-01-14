﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using practicaV1.Context;

#nullable disable

namespace practicaV1.Migrations
{
    [DbContext(typeof(HotelJacjContext))]
    [Migration("20240604051947_practicaV1.Context.HotelJacjContext")]
    partial class practicaV1ContextHotelJacjContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("practicaV1.Models.cAlquiler", b =>
                {
                    b.Property<int>("idAlquiler")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAlquiler"));

                    b.Property<decimal>("costoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("fechaHoraEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaHoraSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("fkCliente")
                        .HasColumnType("int");

                    b.Property<int>("fkEstado")
                        .HasColumnType("int");

                    b.Property<int>("fkHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("fkRegistrador")
                        .HasColumnType("int");

                    b.Property<string>("observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idAlquiler");

                    b.ToTable("tAlquiler");
                });

            modelBuilder.Entity("practicaV1.Models.cCliente", b =>
                {
                    b.Property<int>("idCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCliente"));

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("fkNacionalidad")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCliente");

                    b.ToTable("tCliente");
                });

            modelBuilder.Entity("practicaV1.Models.cEstado", b =>
                {
                    b.Property<int>("idEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEstado"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idEstado");

                    b.ToTable("tEstado");
                });

            modelBuilder.Entity("practicaV1.Models.cHabitacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("fkTipo")
                        .HasColumnType("int");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tHabitacion");
                });

            modelBuilder.Entity("practicaV1.Models.cNacionalidad", b =>
                {
                    b.Property<int>("idNacionalidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idNacionalidad"));

                    b.Property<string>("nacionalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idNacionalidad");

                    b.ToTable("tNacionalidad");
                });

            modelBuilder.Entity("practicaV1.Models.cRegistrador", b =>
                {
                    b.Property<int>("idRegistrador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRegistrador"));

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idRegistrador");

                    b.ToTable("tRegistrador");
                });

            modelBuilder.Entity("practicaV1.Models.cTipoHabitacion", b =>
                {
                    b.Property<int>("idTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTipo"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idTipo");

                    b.ToTable("tTipoHabitacion");
                });
#pragma warning restore 612, 618
        }
    }
}
