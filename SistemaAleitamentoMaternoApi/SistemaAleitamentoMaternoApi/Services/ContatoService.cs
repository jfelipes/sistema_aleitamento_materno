using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class ContatoService : BaseService<Contato>, IContatoService
    {
        private readonly IContatoRepository contatoRepository;

        public ContatoService(IContatoRepository contatoRepository) : base(contatoRepository)
        {
            this.contatoRepository = contatoRepository;
        }
    }
}
