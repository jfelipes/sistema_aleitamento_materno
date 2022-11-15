namespace SistemaAleitamentoMaternoApi.Models
{
    public class Pessoa : BaseEntity
    {
        public bool? Ativo { get; set; } = true;
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public Guid? EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual IEnumerable<Contato> Contatos { get; set; }
    }
}
