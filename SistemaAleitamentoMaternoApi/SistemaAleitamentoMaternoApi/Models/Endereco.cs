namespace SistemaAleitamentoMaternoApi.Models
{
    public class Endereco : BaseEntity
    {
        public string Cep { get; set; }
        public string UF { get; set; }
        public string Localidade { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
    }
}
