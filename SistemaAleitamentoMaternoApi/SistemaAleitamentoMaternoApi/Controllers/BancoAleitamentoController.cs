using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    public class BancoAleitamentoController : BaseController<BancoAleitamentoDto>
    {
        private readonly IApplicationServiceBancoAleitamento applicationService;

        public BancoAleitamentoController(IApplicationServiceBancoAleitamento applicationService) : base(applicationService)
        {
            this.applicationService = applicationService;
        }
    }
}
