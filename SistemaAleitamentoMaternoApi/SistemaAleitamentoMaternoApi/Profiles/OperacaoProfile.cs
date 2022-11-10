using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Profiles
{
    public class OperacaoProfile : Profile
    {
        public OperacaoProfile()
        {

            CreateMap<Operacao, OperacaoDto>();
            CreateMap<OperacaoDto, Operacao>();
        }
    }
}
