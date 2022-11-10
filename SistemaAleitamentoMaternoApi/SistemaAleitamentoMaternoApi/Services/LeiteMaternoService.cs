using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Services
{
    public class LeiteMaternoService : BaseService<LeiteMaterno>, ILeiteMaternoService
    {
        private readonly ILeiteMaternoRepository leiteMaternoRepository;

        public LeiteMaternoService(ILeiteMaternoRepository leiteMaternoRepository) : base(leiteMaternoRepository)
        {
            this.leiteMaternoRepository = leiteMaternoRepository;
        }
    }
}
