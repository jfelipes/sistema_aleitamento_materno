using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    public class AgendamentoController : BaseController<AgendamentoDto>
    {
        private readonly IApplicationServiceAgendamento applicationService;

        public AgendamentoController(IApplicationServiceAgendamento applicationService) : base(applicationService)
        {
            this.applicationService = applicationService;
        }
    }
}