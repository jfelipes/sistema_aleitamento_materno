using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class AgendamentoRepository : BaseRepository<Agendamento>, IAgendamentoRepository
    {
        private readonly SistemaContext context;

        public AgendamentoRepository(SistemaContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Agendamento> Listar()
        {
            return context.Set<Agendamento>()
                .Include(agendamento => agendamento.Operacao)
                .ToList();
        }
    }
}
