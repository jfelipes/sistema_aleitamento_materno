using SistemaAleitamentoMaternoApi.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IApplicationServicePessoa applicationService;

        public PessoaController(IApplicationServicePessoa applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PessoaDto>> Listar()
        {
            return Ok(applicationService.Listar());
        }

        [HttpGet("{guid}")]
        public ActionResult<string> FiltrarPorId(Guid guid)
        {
            return Ok(applicationService.FiltrarPorId(guid));
        }

        [HttpPost]
        public ActionResult Adicionar([FromBody] PessoaDto pessoaDto)
        {
            try
            {
                if (pessoaDto == null)
                {
                    return NotFound();
                }
                applicationService.Adicionar(pessoaDto);
                return Ok("Pessoa cadastrada com sucesso!");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPut]
        public ActionResult Atualizar([FromBody] PessoaDto pessoaDto)
        {
            try
            {
                if (pessoaDto == null)
                {
                    return NotFound();
                }
                applicationService.Atualizar(pessoaDto);
                return Ok("Pessoa atualizada com sucesso!");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpDelete("{guid}")]
        public ActionResult Remover(Guid guid)
        {
            try
            {
                var pessoaDto = applicationService.FiltrarPorId(guid);
                if (pessoaDto == null)
                {
                    return NotFound();
                }
                applicationService.Remover(pessoaDto);
                return Ok("Pessoa removida com sucesso!");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
