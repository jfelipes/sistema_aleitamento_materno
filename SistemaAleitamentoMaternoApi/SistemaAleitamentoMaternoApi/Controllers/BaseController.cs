using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Exceptions.BancoAleitamento;
using SistemaAleitamentoMaternoApi.Exceptions.Endereco;
using SistemaAleitamentoMaternoApi.Exceptions.LeiteMaterno;
using SistemaAleitamentoMaternoApi.Exceptions.Operacao;
using SistemaAleitamentoMaternoApi.Exceptions.Pessoa;
using SistemaAleitamentoMaternoApi.Interfaces;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using System;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEntity> : ControllerBase, IBaseController<TEntity> where TEntity : BaseDto
    {
        private readonly IBaseApplicationService<TEntity> applicationService;

        public BaseController(IBaseApplicationService<TEntity> applicationService)
        {
            this.applicationService = applicationService;
        }

        [NonAction]
        public virtual void LidarComExcecoes(Exception exception)
        {
            if (exception is EnderecoInexistenteException)
            {
                ModelState.AddModelError("EnderecoNotFound", exception.Message);
            }
            else if (exception is BancoAleitamentoInexistenteException)
            {
                ModelState.AddModelError("BancoAleitamentoNotFound", exception.Message);
            }
            else if (exception is BancoAleitamentoPessoaInvalidaException)
            {
                ModelState.AddModelError("BancoAleitamentoPessoaInvalida", exception.Message);
            }
            else if (exception is LeiteMaternoIndisponivelException)
            {
                ModelState.AddModelError("LeiteMaternoIndisponivel", exception.Message);
            }
            else if (exception is LeiteMaternoInexistenteException)
            {
                ModelState.AddModelError("LeiteMaternoNotFound", exception.Message);
            }
            else if (exception is OperacaoInexistenteException)
            {
                ModelState.AddModelError("OperacaoNotFound", exception.Message);
            }
            else if (exception is PessoaInativaException)
            {
                ModelState.AddModelError("PessoaInativa", exception.Message);
            }
            else if (exception is PessoaInexistenteException)
            {
                ModelState.AddModelError("PessoaNotFound", exception.Message);
            }
            else
            {
                ModelState.AddModelError("Genérica", exception.Message);
            }
        }

        [HttpPost]
        public virtual ActionResult<TEntity> Adicionar([FromBody] TEntity entidadeDto)
        {
            try
            {
                if (entidadeDto == null)
                {
                    return NotFound();
                }
                applicationService.Adicionar(entidadeDto);
                var entidadePosOperacao = applicationService.FiltrarPorId(entidadeDto.Id);
                return Ok(entidadePosOperacao);
            }
            catch (Exception exception)
            {
                LidarComExcecoes(exception);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public ActionResult<TEntity> Atualizar([FromBody] TEntity entidadeDto)
        {
            try
            {
                var entidadeDtoCadastrada = applicationService.FiltrarPorId(entidadeDto.Id);
                if (entidadeDtoCadastrada == null)
                {
                    return NotFound();
                }
                applicationService.Atualizar(entidadeDto);
                var entidadePosOperacao = applicationService.FiltrarPorId(entidadeDto.Id);
                return Ok(entidadePosOperacao);
            }
            catch (Exception exception)
            {
                LidarComExcecoes(exception);
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TEntity> FiltrarPorId(Guid id)
        {
            var entidadeDto = applicationService.FiltrarPorId(id);
            if (entidadeDto == null)
            {
                return NotFound();
            }
            return Ok(entidadeDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> Listar()
        {
            return Ok(applicationService.Listar());
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(Guid id)
        {
            try
            {
                var entidadeDto = applicationService.FiltrarPorId(id);
                if (entidadeDto == null)
                {
                    return NotFound();
                }
                applicationService.Remover(entidadeDto);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
