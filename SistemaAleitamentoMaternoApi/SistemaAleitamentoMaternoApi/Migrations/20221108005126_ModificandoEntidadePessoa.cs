using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAleitamentoMaternoApi.Migrations
{
    public partial class ModificandoEntidadePessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Pessoas",
                type: "boolean",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Pessoas");
        }
    }
}
