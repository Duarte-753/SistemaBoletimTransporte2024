using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBoletimTransporteDigital.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoStatusCorrida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corridas_Usuario_UsuarioID",
                table: "Corridas");

            migrationBuilder.DropForeignKey(
                name: "FK_Corridas_Veiculos_VeiculoID",
                table: "Corridas");

            migrationBuilder.AlterColumn<int>(
                name: "VeiculoID",
                table: "Corridas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Corridas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoCorrida",
                table: "Corridas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "StatusDaCorrida",
                table: "Corridas",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Corridas_Usuario_UsuarioID",
                table: "Corridas",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Corridas_Veiculos_VeiculoID",
                table: "Corridas",
                column: "VeiculoID",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corridas_Usuario_UsuarioID",
                table: "Corridas");

            migrationBuilder.DropForeignKey(
                name: "FK_Corridas_Veiculos_VeiculoID",
                table: "Corridas");

            migrationBuilder.DropColumn(
                name: "StatusDaCorrida",
                table: "Corridas");

            migrationBuilder.AlterColumn<int>(
                name: "VeiculoID",
                table: "Corridas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Corridas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoCorrida",
                table: "Corridas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Corridas_Usuario_UsuarioID",
                table: "Corridas",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Corridas_Veiculos_VeiculoID",
                table: "Corridas",
                column: "VeiculoID",
                principalTable: "Veiculos",
                principalColumn: "Id");
        }
    }
}
