using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatosController : ControllerBase, IBaseController<Contato>
    {
        [HttpPost]
        public async Task<ActionResult<Contato>> Adicionar([FromServices] SistemaContext context, [FromBody] Contato entidade)
        {
            if (ModelState.IsValid)
            {
                await context.Contatos.AddAsync(entidade);
                await context.SaveChangesAsync();
                return entidade;
            } else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Contato>> Atualizar([FromServices] SistemaContext context, [FromBody] Contato entidade)
        {
            if (ModelState.IsValid)
            {
                var meioContatoCadastrado = await context.Contatos
                    .FirstOrDefaultAsync(meioContato => meioContato.Id == entidade.Id);
                if (meioContatoCadastrado == null)
                {
                    return NotFound("Meio de Contato informado não encontrado.");
                }
                context.Entry(meioContatoCadastrado).CurrentValues.SetValues(entidade);
                await context.SaveChangesAsync();
                return meioContatoCadastrado;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<Contato>> FiltrarPorId([FromServices] SistemaContext context, Guid id)
        {
            var entidade = await context.Contatos
                .AsNoTracking()
                .FirstOrDefaultAsync(entidade => entidade.Id == id);
            if (entidade == null)
            {
                return NotFound("Meio de Contato informado não encontrado.");
            }
            else
            {
                return Ok(entidade);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Contato>>> Listar([FromServices] SistemaContext context)
        {
            var entidades = await context.Contatos
                .ToListAsync();
            return entidades;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Contato>> Remover([FromServices] SistemaContext context, Guid id)
        {
            var entidade = await context.Contatos
                .AsNoTracking()
                .FirstOrDefaultAsync(entidade => entidade.Id == id);
            if (entidade == null)
            {
                return NotFound("Meio de Contato informado não encontrado.");
            }
            else
            {
                context.Contatos.Remove(entidade);
                await context.SaveChangesAsync();
                return NotFound("Meio de Contato removido com sucesso!");
            }
        }
    }
}
