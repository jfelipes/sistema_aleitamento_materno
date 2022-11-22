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

        public virtual void Adicionar(TEntity entidade)
        {
            context.Set<TEntity>().Add(entidade);
            context.SaveChanges();
        }

        public virtual void Atualizar(TEntity entidade)
        {
            //context.Entry(entidade).State = EntityState.Modified;
            context.Update(entidade);
            context.SaveChanges();
        }

        public virtual TEntity FiltrarPorId(Guid? id)
        {
            if (id == null)
            {
                return null;
            }
            return context.Set<TEntity>().AsNoTracking().FirstOrDefault(entidade => entidade.Id == id);
        }

        public virtual IEnumerable<TEntity> Listar()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual void Remover(TEntity entidade)
        {
            context.Set<TEntity>().Remove(entidade);
            context.SaveChanges();
        }

        public virtual void Salvar()
        {
            context.SaveChanges();
        }
    }
}
