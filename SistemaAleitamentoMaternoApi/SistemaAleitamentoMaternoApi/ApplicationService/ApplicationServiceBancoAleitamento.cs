using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceBancoAleitamento : BaseApplicationService<BancoAleitamento, BancoAleitamentoDto>, IApplicationServiceBancoAleitamento
    {
        private readonly IBancoAleitamentoService service;
        private readonly IMapper mapper;

        public ApplicationServiceBancoAleitamento(IBancoAleitamentoService service, IMapper mapper) : base (service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
    }
}
