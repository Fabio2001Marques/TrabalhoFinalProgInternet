﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrabalhoFinalProgInternet.Data;

namespace TrabalhoFinalProgInternet.Data.GestorProjetosMigrations
{
    [DbContext(typeof(GestorProjetosContext))]
    [Migration("20211119232105_colaboradores")]
    partial class colaboradores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoId");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Colaborador", b =>
                {
                    b.Property<int>("ColaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("NumeroCC")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("ColaboradorId");

                    b.HasIndex("CargoId");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.ColaboradorProjeto", b =>
                {
                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDeInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeSaida")
                        .HasColumnType("datetime2");

                    b.HasKey("ColaboradorId", "ProjetoId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("ColaboradorProjeto");
                });

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Projeto", b =>
                {
                    b.Property<int>("ProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevista")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gestor")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ProjetoId");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Tarefa", b =>
                {
                    b.Property<int>("TarefaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDeFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevista")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("TarefaId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Colaborador", b =>
                {
                    b.HasOne("TrabalhoFinalProgInternet.Models.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.ColaboradorProjeto", b =>
                {
                    b.HasOne("TrabalhoFinalProgInternet.Models.Colaborador", "Colaborador")
                        .WithMany("ColaboradorProjetos")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabalhoFinalProgInternet.Models.Projeto", "Projeto")
                        .WithMany("ProjetoColaboradores")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Tarefa", b =>
                {
                    b.HasOne("TrabalhoFinalProgInternet.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Colaborador", b =>
                {
                    b.Navigation("ColaboradorProjetos");
                });

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Projeto", b =>
                {
                    b.Navigation("ProjetoColaboradores");
                });
#pragma warning restore 612, 618
        }
    }
}
