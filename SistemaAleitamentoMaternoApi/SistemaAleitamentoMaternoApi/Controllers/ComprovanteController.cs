using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    public class ComprovanteController : BaseController<ComprovanteDto>
    {
        private readonly IApplicationServiceComprovante applicationService;

        public ComprovanteController(IApplicationServiceComprovante applicationService) : base(applicationService)
        {
            this.applicationService = applicationService;
        }
    }
}
