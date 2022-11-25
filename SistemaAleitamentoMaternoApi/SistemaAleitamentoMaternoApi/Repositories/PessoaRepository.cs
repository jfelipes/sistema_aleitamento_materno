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

        public override Pessoa FiltrarPorId(Guid? id)
        {
            if (id == null)
            {
                return null;
            }
            return context.Set<Pessoa>().AsNoTracking()
                .Include(pessoa => pessoa.Endereco)
                .Include(pessoa => pessoa.Contatos)
                .FirstOrDefault(entidade => entidade.Id == id);
        }

        public override IEnumerable<Pessoa> Listar()
        {
            return context.Set<Pessoa>().AsNoTracking()
                .Include(pessoa => pessoa.Endereco)
                .Include(pessoa => pessoa.Contatos)
                .ToList();
        }
    }
}
