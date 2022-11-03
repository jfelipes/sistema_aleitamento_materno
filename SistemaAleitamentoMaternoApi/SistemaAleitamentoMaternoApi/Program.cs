using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.Data;
using SistemaAleitamentoMaternoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<SistemaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPostgre")));
builder.Services.AddScoped<SistemaContext, SistemaContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
