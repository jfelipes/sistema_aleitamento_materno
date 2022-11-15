using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAleitamentoMaternoApi.Models
{
    public class Contato : BaseEntity
    {
        public string Dado { get; set; }
        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
    }
}
