using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<Pessoa, PessoaDto>();
            CreateMap<PessoaDto, Pessoa>();
        }
    }
}
