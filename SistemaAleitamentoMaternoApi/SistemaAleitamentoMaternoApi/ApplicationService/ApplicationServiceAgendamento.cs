using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceAgendamento : IApplicationServiceAgendamento
    {
        private readonly IAgendamentoService service;
        private readonly IMapper mapper;

        public ApplicationServiceAgendamento(IAgendamentoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Adicionar(AgendamentoDto entidade)
        {
            var agendamento = mapper.Map<Agendamento>(entidade);
            service.Adicionar(agendamento);
        }

        public void Atualizar(AgendamentoDto entidade)
        {
            var agendamento = mapper.Map<Agendamento>(entidade);
            service.Atualizar(agendamento);
        }

        public AgendamentoDto FiltrarPorId(Guid id)
        {
            var enderecoDto = mapper.Map<AgendamentoDto>(service.FiltrarPorId(id));
            return enderecoDto;
        }

        public IEnumerable<AgendamentoDto> Listar()
        {
            var agendamentosDto = mapper.Map<IEnumerable<Agendamento>, List<AgendamentoDto>>(service.Listar());
            return agendamentosDto;
        }

        public void Remover(AgendamentoDto entidade)
        {
            var agendamento = mapper.Map<Agendamento>(entidade);
            service.Remover(agendamento);
        }
    }
}
