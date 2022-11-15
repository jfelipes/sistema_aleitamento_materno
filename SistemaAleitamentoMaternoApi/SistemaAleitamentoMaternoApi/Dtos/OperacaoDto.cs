using SistemaAleitamentoMaternoApi.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class OperacaoDto : BaseDto
    {
        [Required(ErrorMessage = "Você deve informar o tipo da operação em questão.")]
        public ETipoOperacao TipoOperacao { get; set; }
        public string? Detalhes { get; set; }
        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        public Guid? ResponsavelId { get; set; }
        public Guid? LocalId { get; set; }
    }
}
