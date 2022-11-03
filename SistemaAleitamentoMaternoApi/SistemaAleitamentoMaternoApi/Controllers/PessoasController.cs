using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase, IBaseController<Pessoa>
    {
        [HttpPost]
        public async Task<ActionResult<Pessoa>> Adicionar([FromServices] SistemaContext context, [FromBody] Pessoa entidade)
        {
            if (ModelState.IsValid)
            {
                var pessoaJaCadastrada = await context.Pessoas
                    .AnyAsync(pessoa => pessoa.Cpf == entidade.Cpf || pessoa.Rg == entidade.Rg);
                if (pessoaJaCadastrada)
                {
                    return BadRequest("Pessoa informada ja se encontra cadastrada.");
                }
                context.Pessoas.Add(entidade);
                await context.SaveChangesAsync();
                return entidade;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Pessoa>> Atualizar([FromServices] SistemaContext context, [FromBody] Pessoa entidade)
        {
            if (ModelState.IsValid)
            {
                var pessoaCadastrada = await context.Pessoas
                    .Include(entidade => entidade.Contatos)
                    .FirstOrDefaultAsync(pessoa => pessoa.Id == entidade.Id);
                if (pessoaCadastrada == null)
                {
                    return NotFound("Pessoa informada não encontrada.");
                }
                context.Entry(pessoaCadastrada).CurrentValues.SetValues(entidade);
                await context.SaveChangesAsync();
                return pessoaCadastrada;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("id/{id}")]
        public async Task<ActionResult<Pessoa>> FiltrarPorId([FromServices] SistemaContext context, Guid id)
        {
            var entidade = await context.Pessoas
                .AsNoTracking()
                .Include(entidade => entidade.Contatos)
                .FirstOrDefaultAsync(entidade => entidade.Id == id);
            if (entidade == null)
            {
                return NotFound("Pessoa informada não encontrada.");
            }
            else
            {
                return Ok(entidade);
            }
        }

        [HttpGet]
        [Route("cpf/{cpf}")]
        public async Task<ActionResult<Pessoa>> FiltrarPorCpf([FromServices] SistemaContext context, string cpf)
        {
            var entidade = await context.Pessoas
                .AsNoTracking()
                .Include(entidade => entidade.Contatos)
                .FirstOrDefaultAsync(entidade => entidade.Cpf == cpf);
            if (entidade == null)
            {
                return NotFound("Pessoa informada não encontrada.");
            }
            else
            {
                return Ok(entidade);
            }
        }

        [HttpGet]
        [Route("rg/{rg}")]
        public async Task<ActionResult<Pessoa>> FiltrarPorRg([FromServices] SistemaContext context, string rg)
        {
            var entidade = await context.Pessoas
                .AsNoTracking()
                .Include(entidade => entidade.Contatos)
                .FirstOrDefaultAsync(entidade => entidade.Rg == rg);
            if (entidade == null)
            {
                return NotFound("Pessoa informada não encontrada.");
            }
            else
            {
                return Ok(entidade);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> Listar([FromServices] SistemaContext context)
        {
            var entidades = await context.Pessoas
                .Include(entidade => entidade.Contatos)
                .ToListAsync();
            return entidades;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Pessoa>> Remover([FromServices] SistemaContext context, Guid id)
        {
            var entidade = await context.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(entidade => entidade.Id == id);
            if (entidade == null)
            {
                return NotFound("Pessoa informada não encontrada.");
            }
            else
            {
                var endereco = await context.Enderecos
                    .FirstOrDefaultAsync(endereco => endereco.Id == entidade.EnderecoId);
                if (endereco != null)
                {
                    context.Enderecos.Remove(endereco);
                }
                context.Pessoas.Remove(entidade);
                await context.SaveChangesAsync();
                return Ok("Pessoa removida com sucesso!");
            }
        }
    }
}
