using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class BancoAleitamentoService : BaseService<BancoAleitamento>, IBancoAleitamentoService
    {
        private readonly IBancoAleitamentoRepository bancoRepository;
        private readonly IPessoaRepository pessoaRepository;

        public BancoAleitamentoService(IBancoAleitamentoRepository bancoRepository, IPessoaRepository pessoaRepository) : base(bancoRepository)
        {
            this.bancoRepository = bancoRepository;
            this.pessoaRepository = pessoaRepository;
        }

        public void TratarExcecoes(BancoAleitamento bancoLeite)
        {
            //var pessoa = pessoaRepository.FiltrarPorId(contato.PessoaId);
            //if (pessoa == null)
            //{
            //    throw new PessoaInexistenteException();
            //}
            //if (pessoa.Ativo == false)
            //{
            //    throw new PessoaInativaException();
            //}
        }

        public override void Adicionar(BancoAleitamento bancoLeite)
        {
            TratarExcecoes(bancoLeite);
            base.Adicionar(bancoLeite);
        }

        public override void Atualizar(BancoAleitamento bancoLeite)
        {
            TratarExcecoes(bancoLeite);
            base.Atualizar(bancoLeite);
        }
    }
}
