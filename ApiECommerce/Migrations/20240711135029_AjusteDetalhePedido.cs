using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDetalhePedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "DetalhesPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "DetalhesPedido",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
