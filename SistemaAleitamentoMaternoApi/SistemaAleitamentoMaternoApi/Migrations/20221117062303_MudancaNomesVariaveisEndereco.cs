using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAleitamentoMaternoApi.Migrations
{
    public partial class MudancaNomesVariaveisEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Enderecos",
                newName: "Logradouro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "Enderecos",
                newName: "Cidade");
        }
    }
}
