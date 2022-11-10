using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Interfaces.ApplicationService
{
    public interface IBaseApplicationService<TEntity> where TEntity : BaseDto
    {
        void Adicionar(TEntity entidadeDto);
        void Atualizar(TEntity entidadeDto);
        void Remover(TEntity entidadeDto);
        IEnumerable<TEntity> Listar();
        TEntity FiltrarPorId(Guid id);
    }
}
