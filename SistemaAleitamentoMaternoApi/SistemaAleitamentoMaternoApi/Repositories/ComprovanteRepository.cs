using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class ComprovanteRepository : BaseRepository<Comprovante>, IComprovanteRepository
    {
        private readonly SistemaContext context;

        public ComprovanteRepository(SistemaContext context) : base(context)
        {
            this.context = context;
        }
    }
}
