using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceAgendamento : BaseApplicationService<Agendamento, AgendamentoDto>, IApplicationServiceAgendamento
    {
        private readonly IAgendamentoService service;
        private readonly IMapper mapper;

        public ApplicationServiceAgendamento(IAgendamentoService service, IMapper mapper) : base (service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
    }
}
