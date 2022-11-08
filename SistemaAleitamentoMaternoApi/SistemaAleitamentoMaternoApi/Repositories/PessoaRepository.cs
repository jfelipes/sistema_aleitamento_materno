using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;
using SistemaAleitamentoMaternoApi.Data;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        private readonly SistemaContext context;

        public PessoaRepository(SistemaContext context) : base(context)
        {
            this.context = context;
        }
    }
}
