using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaAleitamentoMaternoApi.Models
{
    public class Endereco : BaseEntity
    {
        [Required]
        [StringLength(8, ErrorMessage = "Seu Cep não deve exceder 8 dígitos.")]
        [DisplayName("Código de Endereçamento Postal (Cep)")]
        public string Cep { get; set; }
        [Required]
        [StringLength(2, ErrorMessage = "Sua UF não deve exceder 2 letras.")]
        [DisplayName("Unidade Federativa (UF)")]
        public string UF { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Sua cidade deve conter no máximo 20 letras.")]
        [DisplayName("Nome Cidade")]
        public string Cidade { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Seu logradouro deve conter no máximo 40 letras.")]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Seu bairro deve conter no máximo 30 letras.")]
        [DisplayName("Bairro")]
        public string Bairro { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Seu número deve conter no máximo 10 letras.")]
        [DisplayName("Número")]
        public string Numero { get; set; }
        [StringLength(40, ErrorMessage = "Seu complemento deve conter no máximo 40 letras.")]
        [DisplayName("Complemento")]
        public string? Complemento { get; set; }
    }
}
