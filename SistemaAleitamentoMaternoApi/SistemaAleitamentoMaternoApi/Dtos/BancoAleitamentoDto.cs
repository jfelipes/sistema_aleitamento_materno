using SistemaAleitamentoMaternoApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class BancoAleitamentoDto : BaseDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "O nome do banco de aleitamento não deveria exceder 50 dígitos.")]
        public string Nome { get; set; }
        public virtual IEnumerable<LeiteMaternoDto> Estoque { get; set; }
        [Required(ErrorMessage = "Você deve informar o responsável pelo banco de aleitamento!")]
        public Guid ResponsavelId { get; set; }
        public Guid EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
