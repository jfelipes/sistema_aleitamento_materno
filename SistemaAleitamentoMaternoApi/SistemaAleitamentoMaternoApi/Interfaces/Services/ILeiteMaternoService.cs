using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Interfaces.Services
{
    public interface ILeiteMaternoService : IBaseService<LeiteMaterno>
    {
        void Retirar(Guid leiteId, Guid receptorId);
    }
}
