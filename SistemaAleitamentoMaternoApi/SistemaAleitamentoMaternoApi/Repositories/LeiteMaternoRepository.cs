using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Repositories
{
    public class LeiteMaternoRepository : BaseRepository<LeiteMaterno>, ILeiteMaternoRepository
    {
        private readonly SistemaContext context;

        public LeiteMaternoRepository(SistemaContext context) : base(context)
        {
            this.context = context;
        }

        public void Retirar(LeiteMaterno leiteMaterno)
        {
            context.Entry(leiteMaterno).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
