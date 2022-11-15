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


        [NonAction]
        public override ActionResult<BancoAleitamentoDto> Adicionar([FromBody] BancoAleitamentoDto entidadeDto)
        {
            return BadRequest(entidadeDto);
        }
        [HttpPost]
        public ActionResult<BancoAleitamentoDto> Adicionar()
        {
            try
            {
                var bancoAleitamentoDto = new BancoAleitamentoDto();
                applicationService.Adicionar(bancoAleitamentoDto);
                return Ok(bancoAleitamentoDto);
            }
            catch (Exception exception)
            {
                LidarComExcecoes(exception);
                return BadRequest(ModelState);
            }
        }
    }
}
