using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AddCamposServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Servicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Servicos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Servicos");
        }
    }
}
