using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceComprovante : BaseApplicationService<Comprovante, ComprovanteDto>, IApplicationServiceComprovante
    {
        private readonly IComprovanteService service;
        private readonly IMapper mapper;

        public ApplicationServiceComprovante(IComprovanteService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
    }
}
