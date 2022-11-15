using SistemaAleitamentoMaternoApi.Exceptions.Endereco;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class PessoaService : BaseService<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;
        private readonly IEnderecoRepository enderecoRepository;

        public PessoaService(IPessoaRepository pessoaRepository, IEnderecoRepository enderecoRepository) : base(pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
            this.enderecoRepository = enderecoRepository;
        }

        public void TratarExcecoes(Pessoa pessoa)
        {
            if (pessoa.Endereco != null)
            {
                pessoa.EnderecoId = pessoa.Endereco.Id;
            }
            else
            {
                var endereco = pessoaRepository.FiltrarPorId(pessoa.EnderecoId);
                if (pessoa.EnderecoId != null && endereco == null)
                {
                    throw new EnderecoInexistenteException();
                }
            }
        }

        public override void Adicionar(Pessoa pessoa)
        {
            TratarExcecoes(pessoa);
            base.Adicionar(pessoa);
        }

        public override void Atualizar(Pessoa pessoa)
        {
            TratarExcecoes(pessoa);
            var pessoaCadastrada = pessoaRepository.FiltrarPorId(pessoa.Id);
            base.Atualizar(pessoaCadastrada);
        }
    }
}
