using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceContato : IApplicationServiceContato
    {
        private readonly IContatoService service;
        private readonly IMapper mapper;

        public ApplicationServiceContato(IContatoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Adicionar(ContatoDto entidade)
        {
            var contato = mapper.Map<Contato>(entidade);
            service.Adicionar(contato);
        }

        public void Atualizar(ContatoDto entidade)
        {
            var contato = mapper.Map<Contato>(entidade);
            service.Atualizar(contato);
        }

        public ContatoDto FiltrarPorId(Guid id)
        {
            var contato = mapper.Map<ContatoDto>(service.FiltrarPorId(id));
            return contato;
        }

        public IEnumerable<ContatoDto> Listar()
        {
            var contatosDto = mapper.Map<IEnumerable<Contato>, List<ContatoDto>>(service.Listar());
            return contatosDto;
        }

        public void Remover(ContatoDto entidade)
        {
            var contato = mapper.Map<Contato>(entidade);
            service.Remover(contato);
        }
    }
}
