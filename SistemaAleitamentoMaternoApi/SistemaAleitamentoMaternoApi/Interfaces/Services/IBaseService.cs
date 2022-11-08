using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        void Adicionar(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Remover(TEntity entidade);
        IEnumerable<TEntity> Listar();
        TEntity FiltrarPorId(Guid id);
    }
}
