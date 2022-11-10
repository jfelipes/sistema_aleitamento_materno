using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class BaseApplicationService<TEntity, TEntityDto> : IBaseApplicationService<TEntityDto>
        where TEntity : BaseEntity
        where TEntityDto : BaseDto
    {
        private readonly IBaseService<TEntity> service;
        private readonly IMapper mapper;

        public BaseApplicationService(IBaseService<TEntity> service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Adicionar(TEntityDto entidadeDto)
        {
            var entidade = mapper.Map<TEntity>(entidadeDto);
            service.Adicionar(entidade);
        }

        public void Atualizar(TEntityDto entidadeDto)
        {
            var entidade = mapper.Map<TEntity>(entidadeDto);
            service.Atualizar(entidade);
        }

        public TEntityDto FiltrarPorId(Guid id)
        {
            var entidadeDto = mapper.Map<TEntityDto>(service.FiltrarPorId(id));
            return entidadeDto;
        }

        public IEnumerable<TEntityDto> Listar()
        {
            var entidadesDto = mapper.Map<IEnumerable<TEntity>, List<TEntityDto>>(service.Listar());
            return entidadesDto;
        }

        public void Remover(TEntityDto entidadeDto)
        {
            var entidade = mapper.Map<TEntity>(entidadeDto);
            service.Remover(entidade);
        }
    }
}
