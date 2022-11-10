using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Profiles
{
    public class LeiteMaternoProfile : Profile
    {
        public LeiteMaternoProfile()
        {

            CreateMap<LeiteMaterno, LeiteMaternoDto>();
            CreateMap<LeiteMaternoDto, LeiteMaterno>();
        }
    }
}
