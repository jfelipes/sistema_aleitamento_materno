using SistemaAleitamentoMaternoApi.Exceptions.Endereco;
using SistemaAleitamentoMaternoApi.Exceptions.Pessoa;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;
using SistemaAleitamentoMaternoApi.Repositories;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class ContatoService : BaseService<Contato>, IContatoService
    {
        private readonly IContatoRepository contatoRepository;
        private readonly IPessoaRepository pessoaRepository;

        public ContatoService(IContatoRepository contatoRepository, IPessoaRepository pessoaRepository) : base(contatoRepository)
        {
            this.contatoRepository = contatoRepository;
            this.pessoaRepository = pessoaRepository;
        }

        public void TratarExcecoes(Contato contato)
        {
            var pessoa = pessoaRepository.FiltrarPorId(contato.PessoaId);
            if (pessoa == null)
            {
                throw new PessoaInexistenteException();
            }
            if (pessoa.Ativo == false)
            {
                throw new PessoaInativaException();
            }
        }

        public override void Adicionar(Contato contato)
        {
            TratarExcecoes(contato);
            base.Adicionar(contato);
        }

        public override void Atualizar(Contato contato)
        {
            TratarExcecoes(contato);
            base.Atualizar(contato);
        }
    }
}
