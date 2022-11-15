using SistemaAleitamentoMaternoApi.Exceptions.Pessoa;
using SistemaAleitamentoMaternoApi.Exceptions.Endereco;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class OperacaoService : BaseService<Operacao>, IOperacaoService
    {
        private readonly IOperacaoRepository operacaoRepository;
        private readonly IPessoaRepository pessoaRepository;
        private readonly IEnderecoRepository enderecoRepository;

        public OperacaoService(IOperacaoRepository operacaoRepository, IPessoaRepository pessoaRepository, IEnderecoRepository enderecoRepository) : base(operacaoRepository)
        {
            this.operacaoRepository = operacaoRepository;
            this.pessoaRepository = pessoaRepository;
            this.enderecoRepository = enderecoRepository;
        }

        public void TratarExcecoes(Operacao operacao)
        {
            var pessoa = pessoaRepository.FiltrarPorId(operacao.PessoaId);
            var responsavel = pessoaRepository.FiltrarPorId(operacao.ResponsavelId);
            if (pessoa == null || (operacao.ResponsavelId != null && responsavel == null))
            {
                throw new PessoaInexistenteException();
            }
            if (pessoa.Ativo == false || (operacao.ResponsavelId != null && responsavel.Ativo == false))
            {
                throw new PessoaInativaException();
            }
            var local = enderecoRepository.FiltrarPorId(operacao.LocalId);
            if (operacao.LocalId != null && local == null)
            {
                throw new EnderecoInexistenteException();
            }
        }

        public override void Adicionar(Operacao operacao)
        {
            TratarExcecoes(operacao);
            base.Adicionar(operacao);
        }

        public override void Atualizar(Operacao operacao)
        {
            TratarExcecoes(operacao);
            base.Atualizar(operacao);
        }
    }
}
