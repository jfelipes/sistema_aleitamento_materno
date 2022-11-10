using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class AgendamentoDto : BaseDto
    {
        [ForeignKey("Operacao")]
        public Guid OperacaoId { get; set; }
        public virtual OperacaoDto OperacaoDto { get; set; }
        public bool Cancelado { get; set; } = false;
        [Required(ErrorMessage = "Deve ser informado se o agendamento foi ou não realizado.")]
        public bool Realizado { get; set; } = false;
        [Required(ErrorMessage = "Deve ser informado a data da agendamento.")]
        public DateTime DataAgendamento { get; set; }
        public DateTime? DataRealizacao { get; set; }
    }
}
