using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBoletimTransporteDigital.Migrations
{
    /// <inheritdoc />
    public partial class CreateTBmanutencao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manutencoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataManutencao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoManutencao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoManutencao = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    VeiculoID = table.Column<int>(type: "int", nullable: false)
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
                name: "Manutencoes");
        }
    }
}
