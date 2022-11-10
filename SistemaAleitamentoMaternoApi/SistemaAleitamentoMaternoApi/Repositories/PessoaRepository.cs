using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;
using SistemaAleitamentoMaternoApi.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        private readonly SistemaContext context;

        public PessoaRepository(SistemaContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Pessoa> Listar()
        {
            return context.Set<Pessoa>()
                .Include(pessoa => pessoa.Contatos)
                .Include(pessoa => pessoa.Operacoes)
                .ToList();
        }
    }
}
