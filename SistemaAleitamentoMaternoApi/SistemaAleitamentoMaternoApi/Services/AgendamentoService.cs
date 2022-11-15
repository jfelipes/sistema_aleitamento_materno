using SistemaAleitamentoMaternoApi.Exceptions;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class AgendamentoService : BaseService<Agendamento>, IAgendamentoService
    {
        private readonly IAgendamentoRepository agendamentoRepository;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository) : base(agendamentoRepository)
        {
            this.agendamentoRepository = agendamentoRepository;
        }

        public void TratarExcecoes(Agendamento agendamento)
        {
            if (agendamento.Operacao != null)
            {
                agendamento.OperacaoId = agendamento.Operacao.Id;
            }
            if (DateTime.Compare(agendamento.DataAgendamento, DateTime.UtcNow) > 0
                || agendamento.DataTermino != null && DateTime.Compare(agendamento.DataAgendamento, (DateTime) agendamento.DataTermino) > 0)
            {
                throw new IrregularidadeDatasException(agendamento.DataAgendamento, agendamento.DataTermino);
            }
        }

        public override void Adicionar(Agendamento agendamento)
        {
            TratarExcecoes(agendamento);
            base.Adicionar(agendamento);
        }

        public override void Atualizar(Agendamento agendamento)
        {
            TratarExcecoes(agendamento);
            base.Atualizar(agendamento);
        }
    }
}
