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

        public void Adicionar(TEntity entidade)
        {
            repository.Adicionar(entidade);
        }

        public void Atualizar(TEntity entidade)
        {
            repository.Atualizar(entidade);
        }

        public TEntity FiltrarPorId(Guid id)
        {
            return repository.FiltrarPorId(id);
        }

        public IEnumerable<TEntity> Listar()
        {
            return repository.Listar();
        }

        public void Remover(TEntity entidade)
        {
            repository.Remover(entidade);
        }
    }
}
