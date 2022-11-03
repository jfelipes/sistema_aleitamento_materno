using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAleitamentoMaternoApi.Models
{
    public class Contato : EntidadeBase
    {
        [Required(ErrorMessage = "Deve ser informado o dado do meio de contato.")]
        [StringLength(50, ErrorMessage = "o dado do meio de contato deve ter no máximo 50 letras.")]
        public string Dado { get; set; }

        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
    }
}
