using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBoletimTransporteDigital.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBanco : Migration
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
                    CodigoFuncional = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
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
                    Prefixo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Veiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quilometragem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroSistema = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    DataFinalCorrida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoCorrida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    VeiculoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corridas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corridas_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Corridas_Veiculos_VeiculoID",
                        column: x => x.VeiculoID,
                        principalTable: "Veiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_UsuarioID",
                table: "Corridas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_VeiculoID",
                table: "Corridas",
                column: "VeiculoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corridas");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
