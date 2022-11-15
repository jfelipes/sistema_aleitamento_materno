using SistemaAleitamentoMaternoApi.Exceptions.Operacao;
using SistemaAleitamentoMaternoApi.Exceptions.Pessoa;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class ComprovanteService : BaseService<Comprovante>, IComprovanteService
    {
        private readonly IComprovanteRepository comprovanteRepository;
        private readonly IOperacaoRepository operacaoRepository;
        private readonly IPessoaRepository pessoaRepository;

        public ComprovanteService(IComprovanteRepository comprovanteRepository, IOperacaoRepository operacaoRepository, IPessoaRepository pessoaRepository) : base(comprovanteRepository)
        {
            this.comprovanteRepository = comprovanteRepository;
            this.operacaoRepository = operacaoRepository;
            this.pessoaRepository = pessoaRepository;
        }

        public void TratarExcecoes(Comprovante comprovante)
        {
            var operacao = operacaoRepository.FiltrarPorId(comprovante.OperacaoId);
            if (operacao == null)
            {
                throw new OperacaoInexistenteException();
            }
            var pessoa = pessoaRepository.FiltrarPorId(comprovante.PessoaId);
            if (pessoa == null)
            {
                throw new PessoaInexistenteException();
            }
            if (pessoa.Ativo == false)
            {
                throw new PessoaInativaException();
            }
        }

        public override void Adicionar(Comprovante comprovante)
        {
            TratarExcecoes(comprovante);
            base.Adicionar(comprovante);
        }

        public override void Atualizar(Comprovante comprovante)
        {
            TratarExcecoes(comprovante);
            base.Atualizar(comprovante);
        }
    }
}
