using AutoMapper;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;
using SistemaAleitamentoMaternoApi.Controllers;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceOperacao : IApplicationServiceOperacao
    {
        private readonly IOperacaoService service;
        private readonly IMapper mapper;

        public ApplicationServiceOperacao(IOperacaoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Adicionar(OperacaoDto entidade)
        {
            var operacao = mapper.Map<Operacao>(entidade);
            service.Adicionar(operacao);
        }

        public void Atualizar(OperacaoDto entidade)
        {
            var operacao = mapper.Map<Operacao>(entidade);
            service.Atualizar(operacao);
        }

        public OperacaoDto FiltrarPorId(Guid id)
        {
            var operacaoDto = mapper.Map<OperacaoDto>(service.FiltrarPorId(id));
            return operacaoDto;
        }

        public IEnumerable<OperacaoDto> Listar()
        {
            var operacoesDto =  mapper.Map<IEnumerable<Operacao>, List<OperacaoDto>>(service.Listar());
            return operacoesDto;
        }

        public void Remover(OperacaoDto entidade)
        {
            var operacao = mapper.Map<Operacao>(entidade);
            service.Remover(operacao);
        }
    }
}
