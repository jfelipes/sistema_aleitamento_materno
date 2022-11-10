using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAleitamentoMaternoApi.Models
{
    public class Contato : BaseEntity
    {
        public string Dado { get; set; }
        public Guid PessoaId { get; set; }
    }
}
