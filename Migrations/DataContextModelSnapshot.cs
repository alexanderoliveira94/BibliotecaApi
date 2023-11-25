﻿// <auto-generated />
using System;
using BibliotecaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotecaApi.Models.EmprestismoDeLivros", b =>
                {
                    b.Property<int>("IdTransacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTransacao"));

                    b.Property<DateTime>("DataDevolucaoPrevista")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDevolucaoRealizada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLivro")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdTransacao");

                    b.ToTable("EmprestismoDeLivros", (string)null);
                });

            modelBuilder.Entity("BibliotecaApi.Models.Livro", b =>
                {
                    b.Property<int>("IdLivro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLivro"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaDisponivel")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLivro");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("BibliotecaApi.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
