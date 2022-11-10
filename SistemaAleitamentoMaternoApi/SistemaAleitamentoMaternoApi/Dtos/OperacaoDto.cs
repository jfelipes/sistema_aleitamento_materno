using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class OperacaoDto : BaseDto
    {
        public string? Detalhes { get; set; }
        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        [Required(ErrorMessage = "Deve ser informado a pessoa responsável pela operação.")]
        public Guid? ResponsavelId { get; set; }
        [Required(ErrorMessage = "Deve ser informado o local que será realizado a operação.")]
        public Guid? LocalId { get; set; }
    }
}
