using SistemaAleitamentoMaternoApi.ApplicationService;
using SistemaAleitamentoMaternoApi.Exceptions.BancoAleitamento;
using SistemaAleitamentoMaternoApi.Exceptions.LeiteMaterno;
using SistemaAleitamentoMaternoApi.Exceptions.Pessoa;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class LeiteMaternoService : BaseService<LeiteMaterno>, ILeiteMaternoService
    {
        private readonly ILeiteMaternoRepository leiteMaternoRepository;
        private readonly IPessoaRepository pessoaRepository;

        public LeiteMaternoService(ILeiteMaternoRepository leiteMaternoRepository, IPessoaRepository pessoaRepository) : base(leiteMaternoRepository)
        {
            this.leiteMaternoRepository = leiteMaternoRepository;
            this.pessoaRepository = pessoaRepository;
        }

        public void TratarExcecoes(LeiteMaterno leiteMaterno)
        {
            var doador = pessoaRepository.FiltrarPorId(leiteMaterno.DoadorId);
            var receptor = pessoaRepository.FiltrarPorId(leiteMaterno.ReceptorId);
            bool foiInformadoReceptor = leiteMaterno.ReceptorId != null;
            if (doador == null || (foiInformadoReceptor && receptor == null))
            {
                throw new PessoaInexistenteException();
            }
            if (doador.Ativo == false || (foiInformadoReceptor && receptor.Ativo == false))
            {
                throw new PessoaInativaException();
            }
            if (foiInformadoReceptor)
            {
                if (leiteMaterno.DataRetirada == null)
                {
                    throw new Exception("Você deve informar a data de retirada.");
                }
                if (leiteMaterno.Disponivel == true)
                {
                    throw new Exception("Você não pode cadastrar um leite materno com status disponivel, uma vez que você informou um receptor.");
                }
            }
            else
            {
                if (leiteMaterno.Disponivel == false)
                {
                    throw new Exception("Você não pode cadastrar um leite materno com status indisponivel sem informar o receptor.");
                }
            }
            if (leiteMaterno.DataRetirada != null)
            {
                if (DateTime.Compare((DateTime)leiteMaterno.DataEntrada, (DateTime)leiteMaterno.DataRetirada) > 0)
                {
                    throw new Exception("Não é possível realizar cadastrar uma retirada anterior à data de entrada.");
                }
            }
        }

        public override void Adicionar(LeiteMaterno leiteMaterno)
        {
            if (leiteMaterno.ReceptorId != null)
            {
                if (leiteMaterno.DataRetirada == null)
                {
                    leiteMaterno.DataRetirada = DateTime.UtcNow;
                }
            }
            else
            {
                if (leiteMaterno.BancoAleitamentoId != null)
                {
                    throw new BancoAleitamentoInexistenteException();
                }
            }
            TratarExcecoes(leiteMaterno);
            base.Adicionar(leiteMaterno);
        }

        public override void Atualizar(LeiteMaterno leiteMaterno)
        {
            TratarExcecoes(leiteMaterno);
            base.Atualizar(leiteMaterno);
        }

        public void Retirar(Guid leiteId, Guid receptorId)
        {
            var leiteMaterno = leiteMaternoRepository.FiltrarPorId(leiteId);
            if (leiteMaterno == null)
            {
                throw new LeiteMaternoInexistenteException();
            }
            if (leiteMaterno.Disponivel == false)
            {
                throw new LeiteMaternoIndisponivelException();
            }
            leiteMaterno.ReceptorId = receptorId;
            leiteMaterno.Disponivel = false;
            leiteMaterno.DataRetirada = DateTime.UtcNow;
            TratarExcecoes(leiteMaterno);
            leiteMaternoRepository.Retirar(leiteMaterno);
        }
    }
}
