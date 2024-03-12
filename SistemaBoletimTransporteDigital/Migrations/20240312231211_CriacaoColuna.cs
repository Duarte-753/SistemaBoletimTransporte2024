using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBoletimTransporteDigital.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KmInicial",
                table: "Corridas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KmInicial",
                table: "Corridas");
        }
    }
}
