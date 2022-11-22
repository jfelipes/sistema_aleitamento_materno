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

        public override BancoAleitamento FiltrarPorId(Guid? id)
        {
            if (id == null)
            {
                return null;
            }
            return context.Set<BancoAleitamento>().AsNoTracking()
                .Include(pessoa => pessoa.Endereco)
                .Include(pessoa => pessoa.Estoque)
                .FirstOrDefault(entidade => entidade.Id == id);
        }


        public IEnumerable<BancoAleitamento> Listar()
        {
            return context.Set<BancoAleitamento>()
                .Include(bancoAleitamento => bancoAleitamento.Estoque)
                .Include(bancoAleitamento => bancoAleitamento.Endereco)
                .ToList();
        }
    }
}
