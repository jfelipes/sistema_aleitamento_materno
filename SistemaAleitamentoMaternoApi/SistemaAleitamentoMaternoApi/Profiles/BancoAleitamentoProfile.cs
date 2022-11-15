using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Profiles
{
    public class BancoAleitamentoProfile : Profile
    {
        public BancoAleitamentoProfile()
        {
            CreateMap<BancoAleitamento, BancoAleitamentoDto>();
            CreateMap<BancoAleitamentoDto, BancoAleitamento>();
        }
    }
}
