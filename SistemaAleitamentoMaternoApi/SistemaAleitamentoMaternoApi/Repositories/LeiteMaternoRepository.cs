using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class LeiteMaternoRepository : BaseRepository<LeiteMaterno>, ILeiteMaternoRepository
    {
        private readonly SistemaContext context;

        public LeiteMaternoRepository(SistemaContext context) : base(context)
        {
            this.context = context;
        }
    }
}
