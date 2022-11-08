using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        private readonly SistemaContext context;

        public ContatoRepository(SistemaContext context) : base(context)
        {
            this.context = context;
        }
    }
}
