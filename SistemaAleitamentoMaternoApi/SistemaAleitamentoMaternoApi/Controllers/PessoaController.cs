using SistemaAleitamentoMaternoApi.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    public class PessoaController : BaseController<PessoaDto>
    {
        private readonly IApplicationServicePessoa applicationService;

        public PessoaController(IApplicationServicePessoa applicationService) : base(applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpPut("ativar/{guid}")]
        public ActionResult Ativar(Guid guid)
        {
            try
            {
                var pessoaDto = applicationService.FiltrarPorId(guid);
                if (pessoaDto == null)
                {
                    return NotFound();
                }
                if (pessoaDto.Ativo == true)
                {
                    return Ok(pessoaDto);
                }
                pessoaDto.Ativo = true;
                applicationService.Atualizar(pessoaDto);
                return Ok(pessoaDto);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPut("desativar/{guid}")]
        public ActionResult Desativar(Guid guid)
        {
            try
            {
                var pessoaDto = applicationService.FiltrarPorId(guid);
                if (pessoaDto == null)
                {
                    return NotFound();
                }
                if (pessoaDto.Ativo == false)
                {
                    return Ok(pessoaDto);
                }
                pessoaDto.Ativo = false;
                applicationService.Atualizar(pessoaDto);
                return Ok(pessoaDto);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
