using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    public class EnderecoController : BaseController<EnderecoDto>
    {
        private readonly IApplicationServiceEndereco applicationService;

        public EnderecoController(IApplicationServiceEndereco applicationService) : base(applicationService)
        {
            this.applicationService = applicationService;
        }
    }
}
