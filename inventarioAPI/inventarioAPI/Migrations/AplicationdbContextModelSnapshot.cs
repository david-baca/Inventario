﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using inventarioAPI.Context;

#nullable disable

namespace inventarioAPI.Migrations
{
    [DbContext(typeof(Aplication_DB_Context.AplicationdbContext))]
    partial class AplicationdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entity.Area", b =>
                {
                    b.Property<int>("PkArea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PkArea");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Domain.Entity.Articulo", b =>
                {
                    b.Property<int>("PkArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Costo")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Estado_Articulo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FEQADD")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FEQ_ASC")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Factura")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FkArea")
                        .HasColumnType("int");

                    b.Property<int>("FkCategoria")
                        .HasColumnType("int");

                    b.Property<int>("FkFuente")
                        .HasColumnType("int");

                    b.Property<int>("FkProvedor")
                        .HasColumnType("int");

                    b.Property<int>("FkResponsable")
                        .HasColumnType("int");

                    b.Property<string>("Polisa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PkArticulo");

                    b.HasIndex("FkArea");

                    b.HasIndex("FkCategoria");

                    b.HasIndex("FkFuente");

                    b.HasIndex("FkProvedor");

                    b.HasIndex("FkResponsable");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Domain.Entity.Catalogo", b =>
                {
                    b.Property<int>("PkCatalogo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PkCatalogo");

                    b.ToTable("Catalogos");
                });

            modelBuilder.Entity("Domain.Entity.Categoria", b =>
                {
                    b.Property<int>("PkCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("FkCatalogo")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PkCategoria");

                    b.HasIndex("FkCatalogo");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Domain.Entity.Fuente", b =>
                {
                    b.Property<int>("PkFuente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PkFuente");

                    b.ToTable("Fuentes");
                });

            modelBuilder.Entity("Domain.Entity.Provedor", b =>
                {
                    b.Property<int>("PkProvedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PkProvedor");

                    b.ToTable("Provedores");
                });

            modelBuilder.Entity("Domain.Entity.Responsable", b =>
                {
                    b.Property<int>("PkResponsable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApellidoM")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ApellidoP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PkResponsable");

                    b.HasIndex("FkRol");

                    b.ToTable("Responsables");
                });

            modelBuilder.Entity("Domain.Entity.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PkRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entity.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido_M")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Apellido_P")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contrseña")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("N_Usuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Domain.Entity.Articulo", b =>
                {
                    b.HasOne("Domain.Entity.Area", "Area")
                        .WithMany()
                        .HasForeignKey("FkArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("FkCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Fuente", "Fuente")
                        .WithMany()
                        .HasForeignKey("FkFuente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Provedor", "Provedor")
                        .WithMany()
                        .HasForeignKey("FkProvedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Responsable", "Responsable")
                        .WithMany()
                        .HasForeignKey("FkResponsable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Categoria");

                    b.Navigation("Fuente");

                    b.Navigation("Provedor");

                    b.Navigation("Responsable");
                });

            modelBuilder.Entity("Domain.Entity.Categoria", b =>
                {
                    b.HasOne("Domain.Entity.Catalogo", "Catalogo")
                        .WithMany()
                        .HasForeignKey("FkCatalogo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalogo");
                });

            modelBuilder.Entity("Domain.Entity.Responsable", b =>
                {
                    b.HasOne("Domain.Entity.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("FkRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Domain.Entity.Usuario", b =>
                {
                    b.HasOne("Domain.Entity.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("FkRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
