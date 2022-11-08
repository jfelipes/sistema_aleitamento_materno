using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;
using SistemaAleitamentoMaternoApi.Services;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class PessoaService : BaseService<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository) : base(pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
        }
    }
}
