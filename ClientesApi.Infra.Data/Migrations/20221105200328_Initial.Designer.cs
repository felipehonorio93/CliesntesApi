﻿// <auto-generated />
using System;
using ClientesApi.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientesApi.Infra.Data.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20221105200328_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClientesApi.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid?>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime?>("DataHoraCadastro")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataHoraUltimaAtualizacao")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdCliente");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ClientesApi.Domain.Entities.Dependente", b =>
                {
                    b.Property<Guid?>("IdDependente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataHoraCadastro")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataHoraUltimaAtualizacao")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IdCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdDependente");

                    b.HasIndex("IdCliente");

                    b.ToTable("Dependentes");
                });

            modelBuilder.Entity("ClientesApi.Domain.Entities.Dependente", b =>
                {
                    b.HasOne("ClientesApi.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Dependentes")
                        .HasForeignKey("IdCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ClientesApi.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Dependentes");
                });
#pragma warning restore 612, 618
        }
    }
}
