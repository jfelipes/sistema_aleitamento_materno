using AutoMapper;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;
using SistemaAleitamentoMaternoApi.Controllers;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceLeiteMaterno : IApplicationServiceLeiteMaterno
    {
        private readonly ILeiteMaternoService service;
        private readonly IMapper mapper;

        public ApplicationServiceLeiteMaterno(ILeiteMaternoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Adicionar(LeiteMaternoDto entidade)
        {
            var leiteMaterno = mapper.Map<LeiteMaterno>(entidade);
            service.Adicionar(leiteMaterno);
        }

        public void Atualizar(LeiteMaternoDto entidade)
        {
            var leiteMaterno = mapper.Map<LeiteMaterno>(entidade);
            service.Atualizar(leiteMaterno);
        }

        public LeiteMaternoDto FiltrarPorId(Guid id)
        {
            var leiteMaternoDto = mapper.Map<LeiteMaternoDto>(service.FiltrarPorId(id));
            return leiteMaternoDto;
        }

        public IEnumerable<LeiteMaternoDto> Listar()
        {
            var leitesMaternoDto =  mapper.Map<IEnumerable<LeiteMaterno>, List<LeiteMaternoDto>>(service.Listar());
            return leitesMaternoDto;
        }

        public void Remover(LeiteMaternoDto entidade)
        {
            var leiteMaterno = mapper.Map<LeiteMaterno>(entidade);
            service.Remover(leiteMaterno);
        }
    }
}
