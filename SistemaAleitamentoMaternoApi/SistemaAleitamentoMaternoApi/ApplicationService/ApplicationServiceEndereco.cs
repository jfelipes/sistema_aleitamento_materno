using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceEndereco : BaseApplicationService<Endereco, EnderecoDto>, IApplicationServiceEndereco
    {
        private readonly IEnderecoService service;
        private readonly IMapper mapper;

        public ApplicationServiceEndereco(IEnderecoService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
    }
}
