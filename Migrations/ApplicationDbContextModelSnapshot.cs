﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OkuoTest.Data;

#nullable disable

namespace OkuoTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OkuoTest.Models.ClasificacionPlanta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClasificacionPlanta");
                });

            modelBuilder.Entity("OkuoTest.Models.Contacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantaId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlantaId");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("OkuoTest.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NIT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("OkuoTest.Models.Planta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClasificacionPlantaId")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("InformacionContacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPlantaId")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClasificacionPlantaId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("TipoPlantaId");

                    b.ToTable("Plantas");
                });

            modelBuilder.Entity("OkuoTest.Models.TipoPlanta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoPlanta");
                });

            modelBuilder.Entity("OkuoTest.Models.Contacto", b =>
                {
                    b.HasOne("OkuoTest.Models.Planta", "Planta")
                        .WithMany("Contactos")
                        .HasForeignKey("PlantaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planta");
                });

            modelBuilder.Entity("OkuoTest.Models.Planta", b =>
                {
                    b.HasOne("OkuoTest.Models.ClasificacionPlanta", "Clasificacion")
                        .WithMany("Plantas")
                        .HasForeignKey("ClasificacionPlantaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OkuoTest.Models.Empresa", "Empresa")
                        .WithMany("Plantas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OkuoTest.Models.TipoPlanta", "Tipo")
                        .WithMany("Plantas")
                        .HasForeignKey("TipoPlantaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clasificacion");

                    b.Navigation("Empresa");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("OkuoTest.Models.ClasificacionPlanta", b =>
                {
                    b.Navigation("Plantas");
                });

            modelBuilder.Entity("OkuoTest.Models.Empresa", b =>
                {
                    b.Navigation("Plantas");
                });

            modelBuilder.Entity("OkuoTest.Models.Planta", b =>
                {
                    b.Navigation("Contactos");
                });

            modelBuilder.Entity("OkuoTest.Models.TipoPlanta", b =>
                {
                    b.Navigation("Plantas");
                });
#pragma warning restore 612, 618
        }
    }
}
