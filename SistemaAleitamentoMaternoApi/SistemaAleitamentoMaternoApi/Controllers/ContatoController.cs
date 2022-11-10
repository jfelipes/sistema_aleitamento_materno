using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    public class ContatoController : BaseController<ContatoDto>
    {
        private readonly IApplicationServiceContato applicationService;

        public ContatoController(IApplicationServiceContato applicationService) : base(applicationService)
        {
            this.applicationService = applicationService;
        }
    }
}
