using Microsoft.EntityFrameworkCore;
using SistemaAleitamentoMaternoApi.Data;

var builder = WebApplication.CreateBuilder(args);

var dependencyInjector = new DependencyInjector(builder.Services);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SistemaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPostgre")));

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("*").WithHeaders("*").WithMethods("*");
    })
);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SistemaContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using(var scope = app.Services.CreateScope())
    {
        var salesContext = scope.ServiceProvider.GetRequiredService<SistemaContext>();
        salesContext.Database.EnsureCreated();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
