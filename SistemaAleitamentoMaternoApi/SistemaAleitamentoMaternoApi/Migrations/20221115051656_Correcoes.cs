using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAleitamentoMaternoApi.Migrations
{
    public partial class Correcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_EnderecoDto_EnderecoId",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "ContatoDto");

            migrationBuilder.DropTable(
                name: "EnderecoDto");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Pessoas_PessoaId",
                table: "Contatos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Enderecos_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Pessoas_PessoaId",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Enderecos_EnderecoId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos");

            migrationBuilder.CreateTable(
                name: "ContatoDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Dado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PessoaId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContatoDto_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Bairro = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Complemento = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Logradouro = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoDto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContatoDto_PessoaId",
                table: "ContatoDto",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_EnderecoDto_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId",
                principalTable: "EnderecoDto",
                principalColumn: "Id");
        }
    }
}
