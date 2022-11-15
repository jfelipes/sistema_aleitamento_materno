using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Interfaces.Repositories
{
    public interface ILeiteMaternoRepository : IBaseRepository<LeiteMaterno>
    {
        void Retirar(LeiteMaterno leiteMaterno);
    }
}
