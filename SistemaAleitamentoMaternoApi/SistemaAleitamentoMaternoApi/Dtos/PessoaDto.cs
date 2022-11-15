using SistemaAleitamentoMaternoApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class PessoaDto : BaseDto
    {
        public bool? Ativo { get; set; } = true;
        [Required]
        [StringLength(50, ErrorMessage = "Seu nome completo não deveria exceder 50 dígitos.")]
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Seu Rg não deveria exceder 20 dígitos.")]
        [DisplayName("Registro Geral (Rg)")]
        public string Rg { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Seu Cpf não deve exceder 15 dígitos.")]
        [DisplayName("Cadastro de Pessoa Física (CPF)")]
        public string Cpf { get; set; }

        [ForeignKey("Endereco")]
        public Guid? EnderecoId { get; set; }
        public virtual EnderecoDto Endereco { get; set; }
        public virtual IEnumerable<ContatoDto> Contatos { get; set; }
    }
}
