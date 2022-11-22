using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class EnderecoDto : BaseDto
    {
        [Required]
        [StringLength(8, ErrorMessage = "Seu Cep não deve exceder 8 dígitos.")]
        public string Cep { get; set; }
        [Required]
        [StringLength(2, ErrorMessage = "Sua UF não deve exceder 2 letras.")]
        public string UF { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Sua localidade deve conter no máximo 20 letras.")]
        public string Localidade { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Seu logradouro deve conter no máximo 40 letras.")]
        public string Logradouro { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Seu bairro deve conter no máximo 30 letras.")]
        public string Bairro { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Seu número deve conter no máximo 10 letras.")]
        public string Numero { get; set; }
        [StringLength(40, ErrorMessage = "Seu complemento deve conter no máximo 40 letras.")]
        public string? Complemento { get; set; }
    }
}
