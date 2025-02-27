﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OeX.Management.Infrastructure.Context;

#nullable disable

namespace OeX.Management.Infrastructure.Migrations
{
    [DbContext(typeof(RNContext))]
    [Migration("20250226004351_InitAll")]
    partial class InitAll
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OeX.Management.Domain.Empresas.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TempoTrabalho")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("OeX.Management.Domain.Manutecoes.Manutencao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataHoraFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaquinaId")
                        .HasColumnType("int");

                    b.Property<long>("MotivoManutencaoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("MaquinaId");

                    b.HasIndex("MotivoManutencaoId");

                    b.ToTable("Manutencoes");
                });

            modelBuilder.Entity("OeX.Management.Domain.Maquinas.Maquina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CapacidadeProdutiva")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Maquinas");
                });

            modelBuilder.Entity("OeX.Management.Domain.MotivosManutencao.MotivoManutencao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("MotivosManutencao");
                });

            modelBuilder.Entity("OeX.Management.Domain.MotivosParada.MotivoParada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("MotivosParada");
                });

            modelBuilder.Entity("OeX.Management.Domain.Paradas.Parada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DataHoraFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaquinaId")
                        .HasColumnType("int");

                    b.Property<int>("MotivoManutencaoId")
                        .HasColumnType("int");

                    b.Property<long>("MotivoParadaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("MaquinaId");

                    b.HasIndex("MotivoParadaId");

                    b.ToTable("Paradas");
                });

            modelBuilder.Entity("OeX.Management.Domain.Manutecoes.Manutencao", b =>
                {
                    b.HasOne("OeX.Management.Domain.Empresas.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .IsRequired();

                    b.HasOne("OeX.Management.Domain.Maquinas.Maquina", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaId")
                        .IsRequired();

                    b.HasOne("OeX.Management.Domain.MotivosManutencao.MotivoManutencao", "MotivoManutencao")
                        .WithMany()
                        .HasForeignKey("MotivoManutencaoId")
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Maquina");

                    b.Navigation("MotivoManutencao");
                });

            modelBuilder.Entity("OeX.Management.Domain.Maquinas.Maquina", b =>
                {
                    b.HasOne("OeX.Management.Domain.Empresas.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("OeX.Management.Domain.MotivosManutencao.MotivoManutencao", b =>
                {
                    b.HasOne("OeX.Management.Domain.Empresas.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("OeX.Management.Domain.MotivosParada.MotivoParada", b =>
                {
                    b.HasOne("OeX.Management.Domain.Empresas.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("OeX.Management.Domain.Paradas.Parada", b =>
                {
                    b.HasOne("OeX.Management.Domain.Empresas.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .IsRequired();

                    b.HasOne("OeX.Management.Domain.Maquinas.Maquina", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaId")
                        .IsRequired();

                    b.HasOne("OeX.Management.Domain.MotivosParada.MotivoParada", "MotivoParada")
                        .WithMany()
                        .HasForeignKey("MotivoParadaId")
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Maquina");

                    b.Navigation("MotivoParada");
                });
#pragma warning restore 612, 618
        }
    }
}
