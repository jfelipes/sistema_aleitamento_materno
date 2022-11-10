using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceLeiteMaterno : BaseApplicationService<LeiteMaterno, LeiteMaternoDto>, IApplicationServiceLeiteMaterno
    {
        private readonly ILeiteMaternoService service;
        private readonly IMapper mapper;

        public ApplicationServiceLeiteMaterno(ILeiteMaternoService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Retirar(Guid leiteId, Guid receptorId)
        {
            service.Retirar(leiteId, receptorId);
        }
    }
}
