using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAleitamentoMaternoApi.Migrations
{
    public partial class MudancaOperacaoEAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancelado",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Realizado",
                table: "Agendamentos");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Agendamentos",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Agendamentos");

            migrationBuilder.AddColumn<bool>(
                name: "Cancelado",
                table: "Agendamentos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Realizado",
                table: "Agendamentos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
