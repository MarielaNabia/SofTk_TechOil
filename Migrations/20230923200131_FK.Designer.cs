﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SofTk_TechOil.DataAccess;

#nullable disable

namespace SofTk_TechOil.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230923200131_FK")]
    partial class FK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SofTk_TechOil.Entities.Job", b =>
                {
                    b.Property<int>("CodTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodTrabajo"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CantHoras")
                        .HasColumnType("int");

                    b.Property<int>("CodProyecto")
                        .HasColumnType("int");

                    b.Property<int>("CodServicio")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodTrabajo");

                    b.HasIndex("CodProyecto");

                    b.HasIndex("CodServicio");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            CodTrabajo = 1,
                            Activo = true,
                            CantHoras = 10000,
                            CodProyecto = 1,
                            CodServicio = 2,
                            Fecha = new DateTime(2023, 9, 23, 17, 1, 31, 82, DateTimeKind.Local).AddTicks(1061),
                            ValorHora = 260m
                        });
                });

            modelBuilder.Entity("SofTk_TechOil.Entities.Project", b =>
                {
                    b.Property<int>("CodProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProyecto"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodProyecto");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            CodProyecto = 1,
                            Activo = true,
                            Direccion = "AV. Carcano 200, Cordoba",
                            Estado = 1,
                            Nombre = "Villa Carlos Paz III"
                        },
                        new
                        {
                            CodProyecto = 2,
                            Activo = true,
                            Direccion = "Km 451, Rio Negro",
                            Estado = 2,
                            Nombre = "Vaca Muerta"
                        },
                        new
                        {
                            CodProyecto = 3,
                            Activo = true,
                            Direccion = "Litoral 241, Rio Gallegos",
                            Estado = 3,
                            Nombre = "Sucursal 154"
                        });
                });

            modelBuilder.Entity("SofTk_TechOil.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("role_activo");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_name");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Description = "Administrador",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Activo = true,
                            Description = "Consultor",
                            Name = "Consultor"
                        });
                });

            modelBuilder.Entity("SofTk_TechOil.Entities.Service", b =>
                {
                    b.Property<int>("CodServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodServicio"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodServicio");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            CodServicio = 1,
                            Activo = true,
                            Descripcion = "PerforacionPozzo100",
                            Estado = true,
                            ValorHora = 1500m
                        },
                        new
                        {
                            CodServicio = 2,
                            Activo = true,
                            Descripcion = "ExtraccionCapa2",
                            Estado = true,
                            ValorHora = 1400m
                        },
                        new
                        {
                            CodServicio = 3,
                            Activo = true,
                            Descripcion = "TransporteKM",
                            Estado = true,
                            ValorHora = 1300m
                        });
                });

            modelBuilder.Entity("SofTk_TechOil.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CodUsuario")
                        .HasColumnType("int");

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasColumnName("user_password");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = false,
                            CodUsuario = 1234,
                            DNI = 40123456,
                            FechaBaja = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Onur Dog",
                            Password = "e52e96fab3ca3e5ffda0fa7faf55ee15221695af0a077f5acd11cc4f55bdb725",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("SofTk_TechOil.Entities.Job", b =>
                {
                    b.HasOne("SofTk_TechOil.Entities.Project", "Project")
                        .WithMany("Jobs")
                        .HasForeignKey("CodProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SofTk_TechOil.Entities.Service", "Service")
                        .WithMany("Jobs")
                        .HasForeignKey("CodServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("SofTk_TechOil.Entities.User", b =>
                {
                    b.HasOne("SofTk_TechOil.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SofTk_TechOil.Entities.Project", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("SofTk_TechOil.Entities.Service", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}