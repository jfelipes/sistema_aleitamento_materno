using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Profiles
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<Agendamento, AgendamentoDto>();
            CreateMap<AgendamentoDto, Agendamento>();
        }
    }
}
