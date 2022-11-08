using AutoMapper;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServicePessoa : IApplicationServicePessoa
    {
        private readonly IPessoaService service;
        private readonly IMapper mapper;

        public ApplicationServicePessoa(IPessoaService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Adicionar(PessoaDto entidade)
        {
            var pessoa = mapper.Map<Pessoa>(entidade);
            service.Adicionar(pessoa);
        }

        public void Atualizar(PessoaDto entidade)
        {
            var pessoa = mapper.Map<Pessoa>(entidade);
            service.Atualizar(pessoa);
        }

        public PessoaDto FiltrarPorId(Guid id)
        {
            var pessoaDto = mapper.Map<PessoaDto>(service.FiltrarPorId(id));
            return pessoaDto;
        }

        public IEnumerable<PessoaDto> Listar()
        {
            var pessoasDto =  mapper.Map<IEnumerable<Pessoa>, List<PessoaDto>>(service.Listar());
            return pessoasDto;
        }

        public void Remover(PessoaDto entidade)
        {
            var pessoa = mapper.Map<Pessoa>(entidade);
            service.Remover(pessoa);
        }
    }
}
