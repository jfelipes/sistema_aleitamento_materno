using AutoMapper;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceOperacao : BaseApplicationService<Operacao, OperacaoDto>, IApplicationServiceOperacao
    {
        private readonly IOperacaoService service;
        private readonly IMapper mapper;

        public ApplicationServiceOperacao(IOperacaoService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
    }
}
