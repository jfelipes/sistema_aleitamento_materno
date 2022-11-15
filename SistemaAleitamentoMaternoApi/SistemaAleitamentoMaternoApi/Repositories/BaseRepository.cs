using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SistemaContext context;

        public BaseRepository(SistemaContext context)
        {
            this.context = context;
        }

        public void Adicionar(TEntity entidade)
        {
            context.Set<TEntity>().Add(entidade);
            context.SaveChanges();
        }

        public void Atualizar(TEntity entidade)
        {
            context.Entry(entidade).State = EntityState.Modified;
            context.SaveChanges();
        }

        public TEntity FiltrarPorId(Guid? id)
        {
            if (id == null)
            {
                return null;
            }
            return context.Set<TEntity>().AsNoTracking().FirstOrDefault(entidade => entidade.Id == id);
        }

        public IEnumerable<TEntity> Listar()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entidade)
        {
            context.Set<TEntity>().Remove(entidade);
            context.SaveChanges();
        }

        public void Salvar()
        {
            context.SaveChanges();
        }
    }
}
