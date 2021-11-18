﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrabalhoFinalProgInternet.Data;

namespace TrabalhoFinalProgInternet.Data.GestorProjetosMigrations
{
    [DbContext(typeof(GestorProjetosContext))]
    partial class GestorProjetosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Colaborador", b =>
                {
                    b.Property<int>("ColaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("NumeroCC")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("ColaboradorId");

                    b.HasIndex("JobId");

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

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.ToTable("Job");
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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ProjetoId");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("TrabalhoFinalProgInternet.Models.Colaborador", b =>
                {
                    b.HasOne("TrabalhoFinalProgInternet.Models.Job", "Nome")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nome");
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
