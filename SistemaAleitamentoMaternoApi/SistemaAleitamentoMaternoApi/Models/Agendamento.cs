namespace SistemaAleitamentoMaternoApi.Models
{
    public class Agendamento : BaseEntity
    {
        public Guid OperacaoId { get; set; }
        public virtual Operacao Operacao { get; set; }
        public bool Cancelado { get; set; } = false;
        public bool Realizado { get; set; } = false;

        public DateTime DataAgendamento { get; set; }
        public DateTime? DataRealizacao { get; set; }
    }
}
