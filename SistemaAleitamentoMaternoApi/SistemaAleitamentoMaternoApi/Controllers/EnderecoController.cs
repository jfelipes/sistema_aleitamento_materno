using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IApplicationServiceEndereco applicationService;

        public EnderecoController(IApplicationServiceEndereco applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnderecoDto>> Listar()
        {
            return Ok(applicationService.Listar());
        }

        [HttpGet("{guid}")]
        public ActionResult<string> FiltrarPorId(Guid guid)
        {
            var elemento = applicationService.FiltrarPorId(guid);
            if (elemento == null)
            {
                return NotFound();
            }
            return BadRequest("Endereço não encontrado!");
        }

        [HttpPost]
        public ActionResult Adicionar([FromBody] EnderecoDto enderecoDto)
        {
            try
            {
                if (enderecoDto == null)
                {
                    return NotFound();
                }
                applicationService.Adicionar(enderecoDto);
                return Ok("Endereço cadastrado com sucesso!");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPut]
        public ActionResult Atualizar([FromBody] EnderecoDto enderecoDto)
        {
            try
            {
                if (enderecoDto == null)
                {
                    return NotFound();
                }
                applicationService.Atualizar(enderecoDto);
                return Ok("Endereço atualizado com sucesso!");
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
                var enderecoDto = applicationService.FiltrarPorId(guid);
                if (enderecoDto == null)
                {
                    return NotFound();
                }
                applicationService.Remover(enderecoDto);
                return Ok("Endereço removido com sucesso!");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
