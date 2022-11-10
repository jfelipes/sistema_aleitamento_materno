using AutoMapper;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServicePessoa : BaseApplicationService<Pessoa, PessoaDto>, IApplicationServicePessoa
    {
        private readonly IPessoaService service;
        private readonly IMapper mapper;

        public ApplicationServicePessoa(IPessoaService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
    }
}
