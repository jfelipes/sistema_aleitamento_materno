using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class EnderecoService : BaseService<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository) : base(enderecoRepository)
        {
            this.enderecoRepository = enderecoRepository;
        }

        public void Adicionar(Endereco entidade)
        {
            entidade.Logradouro = "Vamo realizar um testezim";
            base.Adicionar(entidade);
        }
    }
}
