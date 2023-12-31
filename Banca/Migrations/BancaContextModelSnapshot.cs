﻿// <auto-generated />
using System;
using Banca.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Banca.Migrations
{
    [DbContext(typeof(BancaContext))]
    partial class BancaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Banca.Entities.Ahorro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaDeRegistro")
                        .HasColumnType("datetime");

                    b.Property<string>("Nota")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Ahorro", (string)null);
                });

            modelBuilder.Entity("Banca.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CalleYnumero")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("CalleYNumero");

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("FechaDeRegistro")
                        .HasColumnType("datetime");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Rfc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SegundoApellido")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Banca.Entities.Transaccion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AhorroId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("FechaDeRegistro")
                        .HasColumnType("datetime");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AhorroId");

                    b.ToTable("Transaccion", (string)null);
                });

            modelBuilder.Entity("Banca.Entities.Ahorro", b =>
                {
                    b.HasOne("Banca.Entities.Cliente", "IdNavigation")
                        .WithOne("Ahorro")
                        .HasForeignKey("Banca.Entities.Ahorro", "Id")
                        .IsRequired()
                        .HasConstraintName("FK_Ahorro_Cliente");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("Banca.Entities.Transaccion", b =>
                {
                    b.HasOne("Banca.Entities.Ahorro", "Ahorro")
                        .WithMany("Transaccions")
                        .HasForeignKey("AhorroId")
                        .IsRequired()
                        .HasConstraintName("FK_Transaccion_Ahorro");

                    b.Navigation("Ahorro");
                });

            modelBuilder.Entity("Banca.Entities.Ahorro", b =>
                {
                    b.Navigation("Transaccions");
                });

            modelBuilder.Entity("Banca.Entities.Cliente", b =>
                {
                    b.Navigation("Ahorro");
                });
#pragma warning restore 612, 618
        }
    }
}
