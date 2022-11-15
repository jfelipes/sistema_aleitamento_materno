using SistemaAleitamentoMaternoApi.Enumerations;
namespace SistemaAleitamentoMaternoApi.Models
{
    public class Comprovante : BaseEntity
    {
        public Guid OperacaoId { get; set; }
        public Guid PessoaId { get; set; }
    }
}
