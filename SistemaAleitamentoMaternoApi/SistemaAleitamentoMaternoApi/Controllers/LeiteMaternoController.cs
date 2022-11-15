using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    public class LeiteMaternoController : BaseController<LeiteMaternoDto>
    {
        private readonly IApplicationServiceLeiteMaterno applicationService;

        public LeiteMaternoController(IApplicationServiceLeiteMaterno applicationService) : base(applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpPatch("remover/{leiteId}&{receptorId}")]
        public ActionResult Retirar(Guid leiteId, Guid receptorId)
        {
            try
            {
                applicationService.Retirar(leiteId, receptorId);
                var leiteMaternoPosOperacao = applicationService.FiltrarPorId(leiteId);
                return Ok(leiteMaternoPosOperacao);
            }
            catch (Exception exception)
            {
                LidarComExcecoes(exception);
                return BadRequest(ModelState);
            }
        }
    }
}