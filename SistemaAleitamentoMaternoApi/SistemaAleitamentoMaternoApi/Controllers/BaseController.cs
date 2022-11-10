using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Dtos;
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
                return Ok(entidadeDto);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPatch]
        public ActionResult<TEntity> Atualizar([FromBody] TEntity entidadeDto)
        {
            try
            {
                if (entidadeDto == null)
                {
                    return NotFound();
                }
                applicationService.Atualizar(entidadeDto);
                return Ok(entidadeDto);
            }
            catch (Exception exception)
            {
                throw exception;
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
            return Ok(applicationService.FiltrarPorId(id));
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
                throw exception;
            }
        }
    }
}
