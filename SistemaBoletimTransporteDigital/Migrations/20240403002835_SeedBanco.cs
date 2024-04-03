using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaBoletimTransporteDigital.Migrations
{
    /// <inheritdoc />
    public partial class SeedBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Celular", "CodigoFuncional", "CorridaStatus", "DataCriacao", "DataUltimaAtualizacao", "Email", "Nome", "Perfil", "Senha", "Usuario" },
                values: new object[,]
                {
                    { 1, "11912345678", "1234", 4, new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5156), new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5157), "julioduartebatista753@gmail.com", "admin", 1, "d033e22ae348aeb5660fc2140aec35850c4da997", "admin" },
                    { 2, "11912345678", "567", 4, new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5196), new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5196), "julioduartebatista753@gmail.com", "motorista", 3, "a61e38f3910fba1d8e1fb97f4b3561df07ab0d81", "motorista" },
                    { 3, "11912345678", "9876", 4, new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5214), new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5215), "julioduartebatista753@gmail.com", "motorista2", 3, "b739522c59a564437fc8c6ad639176f704766596", "motorista2" }
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "Ano", "CadastroSistema", "CarroEmUso", "Cor", "DataUltimaAtualizacao", "Placa", "Prefixo", "Quilometragem", "Valor", "Veiculo" },
                values: new object[,]
                {
                    { 1, "2014", new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5243), 1, "Branco", new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5243), "FWF-1232", "1234-5", "12600", "259875", "Golf" },
                    { 2, "2016", new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5268), 1, "Branco", new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5269), "ASD-2345", "6789-10", "450067", "15000", "Fiat Uno" },
                    { 3, "2024", new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5288), 1, "Azul", new DateTime(2024, 4, 2, 21, 28, 35, 1, DateTimeKind.Local).AddTicks(5289), "JHF-7653", "12123-5", "100", "45000", "Palio Weekend" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
