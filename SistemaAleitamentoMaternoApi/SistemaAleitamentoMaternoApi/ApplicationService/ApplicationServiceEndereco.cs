using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Dtos;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Models;

namespace SistemaAleitamentoMaternoApi.ApplicationService
{
    public class ApplicationServiceEndereco : IApplicationServiceEndereco
    {
        private readonly IEnderecoService service;
        private readonly IMapper mapper;

        public ApplicationServiceEndereco(IEnderecoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Adicionar(EnderecoDto entidade)
        {
            var endereco = mapper.Map<Endereco>(entidade);
            service.Adicionar(endereco);
        }

        public void Atualizar(EnderecoDto entidade)
        {
            var endereco = mapper.Map<Endereco>(entidade);
            service.Atualizar(endereco);
        }

        public EnderecoDto FiltrarPorId(Guid id)
        {
            var enderecoDto = mapper.Map<EnderecoDto>(service.FiltrarPorId(id));
            return enderecoDto;
        }

        public IEnumerable<EnderecoDto> Listar()
        {
            var enderecosDto = mapper.Map<IEnumerable<Endereco>, List<EnderecoDto>>(service.Listar());
            return enderecosDto;
        }

        public void Remover(EnderecoDto entidade)
        {
            var endereco = mapper.Map<Endereco>(entidade);
            service.Remover(endereco);
        }
    }
}
