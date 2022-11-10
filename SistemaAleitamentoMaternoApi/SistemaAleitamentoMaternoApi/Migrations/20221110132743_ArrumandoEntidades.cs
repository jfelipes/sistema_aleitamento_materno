using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAleitamentoMaternoApi.Migrations
{
    public partial class ArrumandoEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Dado",
                table: "Contatos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Operacoes_PessoaId",
                table: "Operacoes",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_OperacaoId",
                table: "Agendamentos",
                column: "OperacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Operacoes_OperacaoId",
                table: "Agendamentos",
                column: "OperacaoId",
                principalTable: "Operacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operacoes_Pessoas_PessoaId",
                table: "Operacoes",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Operacoes_OperacaoId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Operacoes_Pessoas_PessoaId",
                table: "Operacoes");

            migrationBuilder.DropIndex(
                name: "IX_Operacoes_PessoaId",
                table: "Operacoes");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_OperacaoId",
                table: "Agendamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Dado",
                table: "Contatos",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
