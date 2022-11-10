using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    public class OperacaoController : BaseController<OperacaoDto>
    {
        private readonly IApplicationServiceOperacao applicationService;

        public OperacaoController(IApplicationServiceOperacao applicationService) : base(applicationService)
        {
            this.applicationService = applicationService;
        }
    }
}