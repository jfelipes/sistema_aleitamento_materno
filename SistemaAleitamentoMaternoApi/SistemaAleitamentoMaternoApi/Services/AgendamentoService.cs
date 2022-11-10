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
    }
}
