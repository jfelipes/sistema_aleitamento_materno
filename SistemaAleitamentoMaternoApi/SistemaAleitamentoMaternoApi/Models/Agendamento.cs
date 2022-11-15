using SistemaAleitamentoMaternoApi.Enumerations;

namespace SistemaAleitamentoMaternoApi.Models
{
    public class Agendamento : BaseEntity
    {
        public Guid OperacaoId { get; set; }
        public virtual Operacao Operacao { get; set; }
        public EStatusAgendamento? Status { get; set; } = EStatusAgendamento.Cadastrado;
        public DateTime DataAgendamento { get; set; } = DateTime.UtcNow;
        public DateTime? DataTermino { get; set; }
    }
}
