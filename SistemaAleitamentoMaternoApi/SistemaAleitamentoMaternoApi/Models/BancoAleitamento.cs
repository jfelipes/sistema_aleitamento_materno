namespace SistemaAleitamentoMaternoApi.Models
{
    public class BancoAleitamento : BaseEntity
    {
        public string Nome { get; set; }
        public virtual IEnumerable<LeiteMaterno> Estoque { get; set; }
        public Guid EnderecoId { get; set;
        public Guid ResponsavelId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
