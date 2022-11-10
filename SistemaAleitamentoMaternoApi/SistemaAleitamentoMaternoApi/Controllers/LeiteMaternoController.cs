using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Dtos;

namespace SistemaAleitamentoMaternoApi.Controllers
{
    public class LeiteMaternoController : BaseController<LeiteMaternoDto>
    {
        private readonly IApplicationServiceLeiteMaterno applicationService;
        private readonly IApplicationServicePessoa applicationServicePessoa;

        public LeiteMaternoController(IApplicationServiceLeiteMaterno applicationService, IApplicationServicePessoa applicationServicePessoa) : base(applicationService)
        {
            this.applicationService = applicationService;
            this.applicationServicePessoa = applicationServicePessoa;
        }

        [HttpPost]
        public override ActionResult<LeiteMaternoDto> Adicionar([FromBody] LeiteMaternoDto entidadeDto)
        {
            Guid receptorId = entidadeDto.ReceptorId ?? Guid.Empty;
            if (receptorId != Guid.Empty)
            {
                var receptorDto = applicationServicePessoa.FiltrarPorId(receptorId);
                if (receptorDto == null)
                {
                    return NotFound("Receptor informado não encontrado.");
                }
                if (entidadeDto.DataRetirada == null)
                {
                    entidadeDto.DataRetirada = DateTime.UtcNow;
                }
                entidadeDto.Disponivel = false;

            }
            return base.Adicionar(entidadeDto);
        }

        [HttpPut("remover/{leiteId}&{receptorId}")]
        public ActionResult Remover(Guid leiteId, Guid receptorId)
        {
            try
            {
                var leiteMaternoDto = applicationService.FiltrarPorId(leiteId);
                var receptorDto = applicationServicePessoa.FiltrarPorId(receptorId);
                if (leiteMaternoDto == null)
                {
                    return NotFound("Leite materno informado não encontrado.");
                }
                if (receptorDto == null)
                {
                    return NotFound("Receptor informado não encontrado.");
                }
                if (leiteMaternoDto.Disponivel == false)
                {
                    return Ok(leiteMaternoDto);
                }
                leiteMaternoDto.Disponivel = false;
                leiteMaternoDto.ReceptorId = receptorId;
                leiteMaternoDto.DataRetirada = DateTime.UtcNow;
                applicationService.Atualizar(leiteMaternoDto);
                return Ok(leiteMaternoDto);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}