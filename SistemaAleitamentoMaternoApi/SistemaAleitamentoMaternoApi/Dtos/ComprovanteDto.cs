using SistemaAleitamentoMaternoApi.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class ComprovanteDto : BaseDto
    {
        [Required(ErrorMessage = "Você deve informar o beneficiado do comprovante.")]
        public Guid PessoaId { get; set; }

        [Required(ErrorMessage = "Você deve informar a operação referente ao comprovante.")]
        public Guid OperacaoId { get; set; }
    }
}
