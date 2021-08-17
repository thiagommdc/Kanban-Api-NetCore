﻿// <auto-generated />
using System;
using BancoDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210701232033_kanban_v3")]
    partial class kanban_v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Dominio.Entidades.tblEtapa", b =>
                {
                    b.Property<int>("intEtapaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("intOrdem")
                        .HasColumnType("INTEGER");

                    b.Property<string>("txtNome")
                        .HasColumnType("TEXT");

                    b.HasKey("intEtapaID");

                    b.ToTable("tblEtapa");
                });

            modelBuilder.Entity("Dominio.Entidades.tblTarefa", b =>
                {
                    b.Property<int>("intTarefaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("bitCompleto")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dteCadastro")
                        .HasColumnType("TEXT");

                    b.Property<int>("intEtapaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("intUsuarioID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("tblEtapaintEtapaID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("tblUsuariointUsuarioID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("txtDescricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("txtSubtitulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("txtTitulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("intTarefaID");

                    b.HasIndex("tblEtapaintEtapaID");

                    b.HasIndex("tblUsuariointUsuarioID");

                    b.ToTable("tblTarefa");
                });

            modelBuilder.Entity("Dominio.Entidades.tblUsuario", b =>
                {
                    b.Property<int>("intUsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("txtNome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("intUsuarioID");

                    b.ToTable("tblUsuario");
                });

            modelBuilder.Entity("Dominio.Entidades.tblTarefa", b =>
                {
                    b.HasOne("Dominio.Entidades.tblEtapa", "tblEtapa")
                        .WithMany()
                        .HasForeignKey("tblEtapaintEtapaID");

                    b.HasOne("Dominio.Entidades.tblUsuario", "tblUsuario")
                        .WithMany("txtTarefa")
                        .HasForeignKey("tblUsuariointUsuarioID");

                    b.Navigation("tblEtapa");

                    b.Navigation("tblUsuario");
                });

            modelBuilder.Entity("Dominio.Entidades.tblUsuario", b =>
                {
                    b.Navigation("txtTarefa");
                });
#pragma warning restore 612, 618
        }
    }
}
