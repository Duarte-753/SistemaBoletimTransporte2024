using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaBoletimTransporteDigital.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoFuncional = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    CorridaStatus = table.Column<int>(type: "int", nullable: true),
                    EstaVinculadoAumaCorrida = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefixo = table.Column<int>(type: "int", nullable: false),
                    Veiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    CadastroSistema = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarroEmUso = table.Column<int>(type: "int", nullable: true),
                    VinculadoCarroAcorrida = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corridas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicioCorrida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinalCorrida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DescricaoCorrida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalSaidaCorrida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalChegadaCorrida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KmInicial = table.Column<int>(type: "int", nullable: false),
                    KmFinal = table.Column<int>(type: "int", nullable: true),
                    KmPercorrido = table.Column<int>(type: "int", nullable: true),
                    StatusDaCorrida = table.Column<int>(type: "int", nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    VeiculoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corridas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corridas_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corridas_Veiculos_VeiculoID",
                        column: x => x.VeiculoID,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manutencoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataManutencao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoManutencao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoManutencao = table.Column<int>(type: "int", nullable: false),
                    CaminhoDaImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VeiculoID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    CorridaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manutencoes_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manutencoes_Veiculos_VeiculoID",
                        column: x => x.VeiculoID,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Celular", "CodigoFuncional", "CorridaStatus", "DataCriacao", "DataUltimaAtualizacao", "Email", "EstaVinculadoAumaCorrida", "Nome", "Perfil", "Senha", "Usuario" },
                values: new object[,]
                {
                    { 1, "11912345678", 1234, 4, new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7460), new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7460), "julioduartebatista753@gmail.com", 6, "admin", 1, "d033e22ae348aeb5660fc2140aec35850c4da997", "ADMIN" },
                    { 2, "11912345678", 567, 4, new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7499), new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7499), "julioduartebatista753@gmail.com", 6, "motorista", 3, "a61e38f3910fba1d8e1fb97f4b3561df07ab0d81", "MOTORISTA" },
                    { 3, "11912345678", 9876, 4, new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7515), new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7516), "julioduartebatista753@gmail.com", 6, "motorista2", 3, "b739522c59a564437fc8c6ad639176f704766596", "MOTORISTA2" }
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "Ano", "CadastroSistema", "CarroEmUso", "Cor", "DataUltimaAtualizacao", "Placa", "Prefixo", "Quilometragem", "Valor", "Veiculo", "VinculadoCarroAcorrida" },
                values: new object[,]
                {
                    { 1, 2014, new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7538), 1, "Branco", new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7539), "FWF-1232", 12345, 12600, 259875, "Golf", null },
                    { 2, 2016, new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7558), 1, "Branco", new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7559), "ASD-2345", 678910, 450067, 15000, "Fiat Uno", null },
                    { 3, 2024, new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7575), 1, "Azul", new DateTime(2024, 4, 30, 15, 25, 1, 240, DateTimeKind.Local).AddTicks(7575), "JHF-7653", 121235, 100, 45000, "Palio Weekend", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_UsuarioID",
                table: "Corridas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_VeiculoID",
                table: "Corridas",
                column: "VeiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_UsuarioID",
                table: "Manutencoes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_VeiculoID",
                table: "Manutencoes",
                column: "VeiculoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corridas");

            migrationBuilder.DropTable(
                name: "Manutencoes");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
