namespace SistemaAleitamentoMaternoApi.Models
{
    public class BancoAleitamento : BaseEntity
    {
        public IEnumerable<LeiteMaterno> Estoque { get; set; }
    }
}
