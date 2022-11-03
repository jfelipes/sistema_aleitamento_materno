using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecosController : ControllerBase, IBaseController<Endereco>
    {
        [HttpPost]
        public async Task<ActionResult<Endereco>> Adicionar([FromServices] SistemaContext context, [FromBody] Endereco entidade)
        {
            if (ModelState.IsValid)
            {
                context.Enderecos.Add(entidade);
                await context.SaveChangesAsync();
                return entidade;
            } else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Endereco>> Atualizar([FromServices] SistemaContext context, [FromBody] Endereco entidade)
        {
            if (ModelState.IsValid)
            {
                var enderecoCadastrado = await context.Enderecos
                    .FirstOrDefaultAsync(endereco => endereco.Id == entidade.Id);
                if (enderecoCadastrado == null)
                {
                    return NotFound("Endereço informado não encontrado.");
                }
                context.Entry(enderecoCadastrado).CurrentValues.SetValues(entidade);
                await context.SaveChangesAsync();
                return enderecoCadastrado;
            } else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Endereco>> FiltrarPorId([FromServices] SistemaContext context, Guid id)
        {
            var entidade = await context.Enderecos
                .AsNoTracking()
                .FirstOrDefaultAsync(entidade => entidade.Id == id);
            if (entidade == null)
            {
                return NotFound("Endereço informado não encontrado.");
            }
            else
            {
                return Ok(entidade);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Endereco>>> Listar([FromServices] SistemaContext context)
        {
            var entidades = await context.Enderecos
                .ToListAsync();
            return entidades;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Endereco>> Remover([FromServices] SistemaContext context, Guid id)
        {
            var entidade = await context.Enderecos
                .AsNoTracking()
                .FirstOrDefaultAsync(entidade => entidade.Id == id);
            if (entidade == null)
            {
                return NotFound("Endereço informado não encontrado.");
            }
            else
            {
                List<Pessoa> pessoasLigadasAoEndereco = context.Pessoas
                    .Where(pessoa => pessoa.EnderecoId == id).ToList();
                foreach (Pessoa pessoa in pessoasLigadasAoEndereco)
                {
                    pessoa.EnderecoId = null;
                }
                context.Enderecos.Remove(entidade);
                await context.SaveChangesAsync();
                return Ok("Endereço removido com sucesso!");
            }
        }
    }
}
