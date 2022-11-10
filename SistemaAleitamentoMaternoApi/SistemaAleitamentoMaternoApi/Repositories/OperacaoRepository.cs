using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class OperacaoRepository : BaseRepository<Operacao>, IOperacaoRepository
    {
        private readonly SistemaContext context;

        public OperacaoRepository(SistemaContext context) : base(context)
        {
            this.context = context;
        }
    }
}
