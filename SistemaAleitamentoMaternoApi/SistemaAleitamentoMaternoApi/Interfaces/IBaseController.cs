using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Data;

namespace SistemaAleitamentoMaternoApi.Interfaces
{
    public interface IBaseController<TEntity> where TEntity : class
    {
        Task<ActionResult<List<TEntity>>> Listar([FromServices] SistemaContext context);
        Task<ActionResult<TEntity>> FiltrarPorId([FromServices] SistemaContext context, Guid id);
        Task<ActionResult<TEntity>> Adicionar([FromServices] SistemaContext context, [FromBody] TEntity entidade);
        Task<ActionResult<TEntity>> Atualizar([FromServices] SistemaContext context, [FromBody] TEntity entidade);
        Task<ActionResult<TEntity>> Remover([FromServices] SistemaContext context, Guid id);
    }
}
