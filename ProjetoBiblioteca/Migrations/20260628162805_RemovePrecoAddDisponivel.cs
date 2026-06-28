using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class RemovePrecoAddDisponivel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Livros");

            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Livros",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Livros");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Livros",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
