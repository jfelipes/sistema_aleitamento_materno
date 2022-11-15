using SistemaAleitamentoMaternoApi.Enumerations;

namespace SistemaAleitamentoMaternoApi.Models
{
    public class Operacao : BaseEntity
    {
        public ETipoOperacao TipoOperacao { get; set; }
        public string? Detalhes { get; set; }
        public Guid PessoaId { get; set; }
        public Guid? ResponsavelId { get; set; }
        public Guid? LocalId { get; set; }  
    }
}
