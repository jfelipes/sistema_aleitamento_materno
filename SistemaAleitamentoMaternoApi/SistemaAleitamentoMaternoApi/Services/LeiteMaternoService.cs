using SistemaAleitamentoMaternoApi.ApplicationService;
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

        public override void Adicionar(LeiteMaterno entidade)
        {
            var receptor = pessoaRepository.FiltrarPorId(entidade.ReceptorId ?? Guid.Empty);
            if (receptor != null)
            {
                if (entidade.DataRetirada == null)
                {
                    entidade.DataRetirada = DateTime.UtcNow;
                }
                entidade.Disponivel = false;
            }
            base.Adicionar(entidade);
        }

        public void Retirar(Guid leiteId, Guid receptorId)
        {
            var leiteMaterno = leiteMaternoRepository.FiltrarPorId(leiteId);
            var receptor = pessoaRepository.FiltrarPorId(receptorId);
            if (leiteMaterno == null || receptor == null)
            {
                return;
            }
            if (leiteMaterno.DataRetirada == null)
            {
                leiteMaterno.DataRetirada = DateTime.UtcNow;
            }
            leiteMaterno.Disponivel = false;

            leiteMaternoRepository.Salvar();
            pessoaRepository.Salvar();
        }
    }
}
