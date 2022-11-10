using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.ApplicationService;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Interfaces.ApplicationService;
using SistemaAleitamentoMaternoApi.Interfaces.Repositories;
using SistemaAleitamentoMaternoApi.Interfaces.Services;
using SistemaAleitamentoMaternoApi.Profiles;
using SistemaAleitamentoMaternoApi.Repositories;
using SistemaAleitamentoMaternoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<SistemaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPostgre")));

builder.Services.AddAutoMapper(typeof(AgendamentoProfile));
builder.Services.AddAutoMapper(typeof(ContatoProfile));
builder.Services.AddAutoMapper(typeof(EnderecoProfile));
builder.Services.AddAutoMapper(typeof(LeiteMaternoProfile));
builder.Services.AddAutoMapper(typeof(OperacaoProfile));
builder.Services.AddAutoMapper(typeof(PessoaProfile));

// Realizando Injeção de Dependências.
builder.Services.AddScoped<IApplicationServiceAgendamento, ApplicationServiceAgendamento>();
builder.Services.AddScoped<IApplicationServiceContato, ApplicationServiceContato>();
builder.Services.AddScoped<IApplicationServiceEndereco, ApplicationServiceEndereco>();
builder.Services.AddScoped<IApplicationServiceLeiteMaterno, ApplicationServiceLeiteMaterno>();
builder.Services.AddScoped<IApplicationServiceOperacao, ApplicationServiceOperacao>();
builder.Services.AddScoped<IApplicationServicePessoa, ApplicationServicePessoa>();

builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();
builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<ILeiteMaternoService, LeiteMaternoService>();
builder.Services.AddScoped<IOperacaoService, OperacaoService>();
builder.Services.AddScoped<IPessoaService, PessoaService>();

builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<ILeiteMaternoRepository, LeiteMaternoRepository>();
builder.Services.AddScoped<IOperacaoRepository, OperacaoRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
