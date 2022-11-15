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

        [HttpGet("listar-pessoa/{guid}")]
        public ActionResult<IEnumerable<OperacaoDto>> OperacoesPorPessoa(Guid guid)
        {
            try
            {
                var operacoesDto = applicationService.Listar().Where(operacao => operacao.PessoaId == guid);
                return Ok(operacoesDto);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}