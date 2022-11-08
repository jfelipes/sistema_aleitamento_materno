//using Microsoft.AspNetCore.Mvc;
//using SistemaAleitamentoMaternoApi.Data;
//using SistemaAleitamentoMaternoApi.Interfaces;
//using SistemaAleitamentoMaternoApi.Models;

//namespace SistemaAleitamentoMaternoApi.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AgendamentoController : ControllerBase, IBaseController<Agendamento>
//    {
//        public async TaskActionResult<Agendamento>> Adicionar([FromServices] SistemaContext context, [FromBody] Agendamento entidade)
//        {
//            if (ModelState.IsValid)
//            {
//                context.Agendamentos.Add(entidade);
//                await context.SaveChangesAsync();
//                return entidade;
//            }
//            else
//            {
//                return BadRequest(ModelState);
//            }
//        }

//        public Task<ActionResult<Agendamento>> Atualizar([FromServices] SistemaContext context, [FromBody] Agendamento entidade)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ActionResult<Agendamento>> FiltrarPorId([FromServices] SistemaContext context, Guid id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ActionResult<List<Agendamento>>> Listar([FromServices] SistemaContext context)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ActionResult<Agendamento>> Remover([FromServices] SistemaContext context, Guid id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
