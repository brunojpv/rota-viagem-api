using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RotaViagem.Controllers;
using RotaViagem.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RotaDbContext>(opt =>
    opt.UseInMemoryDatabase("RotasDB"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Rota Viagem API",
        Version = "v1",
        Description = "API para cadastro de rotas e consulta da melhor rota de viagem",
        Contact = new OpenApiContact
        {
            Name = "Bruno Vieira",
            Url = new Uri("https://github.com/brunojpv")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RotaDbContext>();
    dbContext.Seed();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rota Viagem API v1");
});

app.MapRotasEndpoints();

await app.RunAsync();