using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;
using Microsoft.AspNetCore.Mvc;

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
