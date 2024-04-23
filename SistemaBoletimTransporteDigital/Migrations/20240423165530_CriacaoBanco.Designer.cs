﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaBoletimTransporteDigital.Data;

#nullable disable

namespace SistemaBoletimTransporteDigital.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20240423165530_CriacaoBanco")]
    partial class CriacaoBanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaBoletimTransporteDigital.Models.CorridaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataFinalCorrida")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicioCorrida")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoCorrida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KmFinal")
                        .HasColumnType("int");

                    b.Property<int?>("KmInicial")
                        .HasColumnType("int");

                    b.Property<int?>("KmPercorrido")
                        .HasColumnType("int");

                    b.Property<string>("LocalChegadaCorrida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalSaidaCorrida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusDaCorrida")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.Property<int>("VeiculoID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.HasIndex("VeiculoID");

                    b.ToTable("Corridas");
                });

            modelBuilder.Entity("SistemaBoletimTransporteDigital.Models.ManutencaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CaminhoDaImagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CorridaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataManutencao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoManutencao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoManutencao")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.Property<int>("VeiculoID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.HasIndex("VeiculoID");

                    b.ToTable("Manutencoes");
                });

            modelBuilder.Entity("SistemaBoletimTransporteDigital.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CodigoFuncional")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("CorridaStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Celular = "11912345678",
                            CodigoFuncional = "1234",
                            CorridaStatus = 4,
                            DataCriacao = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5813),
                            DataUltimaAtualizacao = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5820),
                            Email = "julioduartebatista753@gmail.com",
                            Nome = "admin",
                            Perfil = 1,
                            Senha = "d033e22ae348aeb5660fc2140aec35850c4da997",
                            Usuario = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Celular = "11912345678",
                            CodigoFuncional = "567",
                            CorridaStatus = 4,
                            DataCriacao = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5877),
                            DataUltimaAtualizacao = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5886),
                            Email = "julioduartebatista753@gmail.com",
                            Nome = "motorista",
                            Perfil = 3,
                            Senha = "a61e38f3910fba1d8e1fb97f4b3561df07ab0d81",
                            Usuario = "motorista"
                        },
                        new
                        {
                            Id = 3,
                            Celular = "11912345678",
                            CodigoFuncional = "9876",
                            CorridaStatus = 4,
                            DataCriacao = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5909),
                            DataUltimaAtualizacao = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5909),
                            Email = "julioduartebatista753@gmail.com",
                            Nome = "motorista2",
                            Perfil = 3,
                            Senha = "b739522c59a564437fc8c6ad639176f704766596",
                            Usuario = "motorista2"
                        });
                });

            modelBuilder.Entity("SistemaBoletimTransporteDigital.Models.VeiculoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CadastroSistema")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CarroEmUso")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataUltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefixo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quilometragem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Veiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = "2014",
                            CadastroSistema = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5940),
                            CarroEmUso = 1,
                            Cor = "Branco",
                            DataUltimaAtualizacao = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5940),
                            Placa = "FWF-1232",
                            Prefixo = "1234-5",
                            Quilometragem = "12600",
                            Valor = "259875",
                            Veiculo = "Golf"
                        },
                        new
                        {
                            Id = 2,
                            Ano = "2016",
                            CadastroSistema = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5966),
                            CarroEmUso = 1,
                            Cor = "Branco",
                            DataUltimaAtualizacao = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5967),
                            Placa = "ASD-2345",
                            Prefixo = "6789-10",
                            Quilometragem = "450067",
                            Valor = "15000",
                            Veiculo = "Fiat Uno"
                        },
                        new
                        {
                            Id = 3,
                            Ano = "2024",
                            CadastroSistema = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5987),
                            CarroEmUso = 1,
                            Cor = "Azul",
                            DataUltimaAtualizacao = new DateTime(2024, 4, 23, 13, 55, 29, 36, DateTimeKind.Local).AddTicks(5988),
                            Placa = "JHF-7653",
                            Prefixo = "12123-5",
                            Quilometragem = "100",
                            Valor = "45000",
                            Veiculo = "Palio Weekend"
                        });
                });

            modelBuilder.Entity("SistemaBoletimTransporteDigital.Models.CorridaModel", b =>
                {
                    b.HasOne("SistemaBoletimTransporteDigital.Models.UsuarioModel", "Usuario")
                        .WithMany("Corridas")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaBoletimTransporteDigital.Models.VeiculoModel", "Veiculo")
                        .WithMany("Corridas")
                        .HasForeignKey("VeiculoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("SistemaBoletimTransporteDigital.Models.ManutencaoModel", b =>
                {
                    b.HasOne("SistemaBoletimTransporteDigital.Models.UsuarioModel", "Usuario")
                        .WithMany("Manutencoes")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaBoletimTransporteDigital.Models.VeiculoModel", "Veiculo")
                        .WithMany("Manutencoes")
                        .HasForeignKey("VeiculoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("SistemaBoletimTransporteDigital.Models.UsuarioModel", b =>
                {
                    b.Navigation("Corridas");

                    b.Navigation("Manutencoes");
                });

            modelBuilder.Entity("SistemaBoletimTransporteDigital.Models.VeiculoModel", b =>
                {
                    b.Navigation("Corridas");

                    b.Navigation("Manutencoes");
                });
#pragma warning restore 612, 618
        }
    }
}