using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Interfaces.ApplicationService
{
    public interface IBaseApplicationService<TEntity> where TEntity : BaseDto
    {
        void Adicionar(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Remover(TEntity entidade);
        IEnumerable<TEntity> Listar();
        TEntity FiltrarPorId(Guid id);
    }
}
