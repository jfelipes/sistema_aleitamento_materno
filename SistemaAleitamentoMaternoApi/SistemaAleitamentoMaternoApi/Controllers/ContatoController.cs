using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IApplicationServiceContato applicationService;

        public ContatoController(IApplicationServiceContato applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContatoDto>> Listar()
        {
            return Ok(applicationService.Listar());
        }

        [HttpGet("{guid}")]
        public ActionResult<string> FiltrarPorId(Guid guid)
        {
            return Ok(applicationService.FiltrarPorId(guid));
        }

        [HttpPost]
        public ActionResult Adicionar([FromBody] ContatoDto contatoDto)
        {
            try
            {
                if (contatoDto == null)
                {
                    return NotFound();
                }
                applicationService.Adicionar(contatoDto);
                return Ok("Contato cadastrado com sucesso!");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPut]
        public ActionResult Atualizar([FromBody] ContatoDto contatoDto)
        {
            try
            {
                if (contatoDto == null)
                {
                    return NotFound();
                }
                applicationService.Atualizar(contatoDto);
                return Ok("Contato atualizado com sucesso!");
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
                var contatoDto = applicationService.FiltrarPorId(guid);
                if (contatoDto == null)
                {
                    return NotFound();
                }
                applicationService.Remover(contatoDto);
                return Ok("Contato removido com sucesso!");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
