using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Adicionar(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Remover(TEntity entidade);
        IEnumerable<TEntity> Listar();
        TEntity FiltrarPorId(Guid id);
    }
}
