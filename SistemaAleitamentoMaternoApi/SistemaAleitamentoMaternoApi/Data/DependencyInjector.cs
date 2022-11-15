using SistemaAleitamentoMaternoApi.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Profiles;
using SistemaAleitamentoMaternoApi.Repositories;
using SistemaAleitamentoMaternoApi.Services;

namespace SistemaAleitamentoMaternoApi.Data
{
    public class DependencyInjector
    {
        public DependencyInjector(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(AgendamentoProfile));
            serviceCollection.AddAutoMapper(typeof(BancoAleitamentoProfile));
            serviceCollection.AddAutoMapper(typeof(ComprovanteProfile));
            serviceCollection.AddAutoMapper(typeof(ContatoProfile));
            serviceCollection.AddAutoMapper(typeof(EnderecoProfile));
            serviceCollection.AddAutoMapper(typeof(LeiteMaternoProfile));
            serviceCollection.AddAutoMapper(typeof(OperacaoProfile));
            serviceCollection.AddAutoMapper(typeof(PessoaProfile));

            // Realizando Injeção de Dependências.
            serviceCollection.AddScoped<IApplicationServiceAgendamento, ApplicationServiceAgendamento>();
            serviceCollection.AddScoped<IApplicationServiceBancoAleitamento, ApplicationServiceBancoAleitamento>();
            serviceCollection.AddScoped<IApplicationServiceComprovante, ApplicationServiceComprovante>();
            serviceCollection.AddScoped<IApplicationServiceContato, ApplicationServiceContato>();
            serviceCollection.AddScoped<IApplicationServiceEndereco, ApplicationServiceEndereco>();
            serviceCollection.AddScoped<IApplicationServiceLeiteMaterno, ApplicationServiceLeiteMaterno>();
            serviceCollection.AddScoped<IApplicationServiceOperacao, ApplicationServiceOperacao>();
            serviceCollection.AddScoped<IApplicationServicePessoa, ApplicationServicePessoa>();

            serviceCollection.AddScoped<IAgendamentoService, AgendamentoService>();
            serviceCollection.AddScoped<IBancoAleitamentoService, BancoAleitamentoService>();
            serviceCollection.AddScoped<IComprovanteService, ComprovanteService>();
            serviceCollection.AddScoped<IContatoService, ContatoService>();
            serviceCollection.AddScoped<IEnderecoService, EnderecoService>();
            serviceCollection.AddScoped<ILeiteMaternoService, LeiteMaternoService>();
            serviceCollection.AddScoped<IOperacaoService, OperacaoService>();
            serviceCollection.AddScoped<IPessoaService, PessoaService>();

            serviceCollection.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            serviceCollection.AddScoped<IBancoAleitamentoRepository, BancoAleitamentoRepository>();
            serviceCollection.AddScoped<IComprovanteRepository, ComprovanteRepository>();
            serviceCollection.AddScoped<IContatoRepository, ContatoRepository>();
            serviceCollection.AddScoped<IEnderecoRepository, EnderecoRepository>();
            serviceCollection.AddScoped<ILeiteMaternoRepository, LeiteMaternoRepository>();
            serviceCollection.AddScoped<IOperacaoRepository, OperacaoRepository>();
            serviceCollection.AddScoped<IPessoaRepository, PessoaRepository>();
        }
    }
}
