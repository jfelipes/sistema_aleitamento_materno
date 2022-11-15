using SistemaAleitamentoMaternoApi.Enumerations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAleitamentoMaternoApi.Dtos
{
    public class AgendamentoDto : BaseDto
    {
        [ForeignKey("Operacao")]
        public Guid OperacaoId { get; set; }
        public virtual OperacaoDto Operacao { get; set; }
        [TypeConverter("string")]
        public EStatusAgendamento? Status { get; set; } = EStatusAgendamento.Cadastrado;
        [Required(ErrorMessage = "Deve ser informado a data da agendamento.")]
        public DateTime DataAgendamento { get; set; } = DateTime.UtcNow;
        public DateTime? DataTermino { get; set; }
    }
}
