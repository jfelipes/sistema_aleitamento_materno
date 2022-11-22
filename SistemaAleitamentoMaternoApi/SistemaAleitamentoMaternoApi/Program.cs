using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.Data;

var builder = WebApplication.CreateBuilder(args);
new DependencyInjector(builder.Services);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<SistemaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPostgre")));

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("*").WithHeaders("*").WithMethods("*");
    })
);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();

app.Run();
