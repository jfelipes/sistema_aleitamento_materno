using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class OperacaoService : BaseService<Operacao>, IOperacaoService
    {
        private readonly IOperacaoRepository operacaoRepository;

        public OperacaoService(IOperacaoRepository operacaoRepository) : base(operacaoRepository)
        {
            this.operacaoRepository = operacaoRepository;
        }
    }
}
