using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly SistemaContext context;

        public EnderecoRepository(SistemaContext context) : base(context)
        {
            this.context = context;
        }
    }
}
