using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual void Adicionar(TEntity entidade)
        {
            repository.Adicionar(entidade);
        }

        public virtual void Atualizar(TEntity entidade)
        {
            repository.Atualizar(entidade);
        }

        public virtual TEntity FiltrarPorId(Guid id)
        {
            return repository.FiltrarPorId(id);
        }

        public virtual IEnumerable<TEntity> Listar()
        {
            return repository.Listar();
        }

        public virtual void Remover(TEntity entidade)
        {
            repository.Remover(entidade);
        }
    }
}
