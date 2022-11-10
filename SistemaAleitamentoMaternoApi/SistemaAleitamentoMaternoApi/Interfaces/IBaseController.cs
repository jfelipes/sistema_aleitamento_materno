using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Interfaces
{
    public interface IBaseController<TEntity> where TEntity : BaseDto
    {
        ActionResult<IEnumerable<TEntity>> Listar();
        ActionResult<TEntity> FiltrarPorId(Guid id);
        ActionResult<TEntity> Adicionar([FromBody] TEntity entidadeDto);
        ActionResult<TEntity> Atualizar([FromBody] TEntity entidadeDto);
        ActionResult Remover(Guid id);
    }
}
