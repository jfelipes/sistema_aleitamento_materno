using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Interfaces.ApplicationService
{
    public interface IApplicationServiceLeiteMaterno : IBaseApplicationService<LeiteMaternoDto>
    {
        void Retirar(Guid leiteId, Guid receptorId);
    }
}
