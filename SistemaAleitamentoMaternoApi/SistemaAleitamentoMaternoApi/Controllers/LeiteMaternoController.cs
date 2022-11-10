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

        [HttpPut("remover/{leiteId}&{receptorId}")]
        public ActionResult Retirar(Guid leiteId, Guid receptorId)
        {
            try
            {
                var leiteMaterno = applicationService.FiltrarPorId(leiteId);
                if (leiteMaterno == null)
                {
                    return NotFound();
                }
                applicationService.Retirar(leiteId, receptorId);
                return Ok(leiteMaterno);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}