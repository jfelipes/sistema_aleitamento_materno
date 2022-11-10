namespace SistemaAleitamentoMaternoApi.Models
{
    public class Operacao : BaseEntity
    {
        public string? Detalhes { get; set; }
        public Guid PessoaId { get; set; }
        public Guid? ResponsavelId { get; set; }
        public Guid? LocalId { get; set; }  
    }
}
