using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class BancoAleitamentoRepository : BaseRepository<BancoAleitamento>, IBancoAleitamentoRepository
    {
        private readonly SistemaContext context;

        public BancoAleitamentoRepository(SistemaContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<BancoAleitamento> Listar()
        {
            return context.Set<BancoAleitamento>()
                .Include(bancoLeiteMaterno => bancoLeiteMaterno.Estoque)
                .ToList();
        }
    }
}
