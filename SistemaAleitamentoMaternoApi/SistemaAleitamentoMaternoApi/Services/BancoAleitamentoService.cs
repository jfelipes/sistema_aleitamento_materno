using SistemaAleitamentoMaternoApi.Exceptions.BancoAleitamento;
using SistemaAleitamentoMaternoApi.Exceptions.Endereco;
using SistemaAleitamentoMaternoApi.Exceptions.Pessoa;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;
using System.ComponentModel;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class BancoAleitamentoService : BaseService<BancoAleitamento>, IBancoAleitamentoService
    {
        private readonly IBancoAleitamentoRepository bancoRepository;
        private readonly IPessoaRepository pessoaRepository;
        private readonly IEnderecoRepository enderecoRepository;

        public BancoAleitamentoService(IBancoAleitamentoRepository bancoRepository, IPessoaRepository pessoaRepository, IEnderecoRepository enderecoRepository) : base(bancoRepository)
        {
            this.bancoRepository = bancoRepository;
            this.pessoaRepository = pessoaRepository;
            this.enderecoRepository = enderecoRepository;
        }

        public void TratarExcecoes(BancoAleitamento bancoLeite)
        {
            var pessoa = pessoaRepository.FiltrarPorId(bancoLeite.ResponsavelId);
            if (pessoa == null)
            {
                throw new PessoaInexistenteException();
            }
            if (pessoa.Ativo == false)
            {
                throw new PessoaInativaException();
            }
            var pessoaJaEhResponsavelPorOutroBanco = bancoRepository.Listar().Any(banco =>  banco.ResponsavelId == pessoa.Id);
            if  (pessoaJaEhResponsavelPorOutroBanco == true)
            {
                throw new BancoAleitamentoPessoaInvalidaException();
            }
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
