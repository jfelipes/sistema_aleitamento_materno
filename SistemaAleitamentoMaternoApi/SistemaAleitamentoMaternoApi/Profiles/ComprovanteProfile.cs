using AutoMapper;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.Profiles
{
    public class ComprovanteProfile : Profile
    {
        public ComprovanteProfile()
        {
            CreateMap<Comprovante, ComprovanteDto>();
            CreateMap<ComprovanteDto, Comprovante>();
        }
    }
}
