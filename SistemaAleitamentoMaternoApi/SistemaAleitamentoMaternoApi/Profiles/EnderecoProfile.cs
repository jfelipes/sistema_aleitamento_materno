using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Endereco, EnderecoDto>();
            CreateMap<EnderecoDto, Endereco>();
        }
    }
}
