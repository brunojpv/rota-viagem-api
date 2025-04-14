using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RotaViagem.Controllers;
using RotaViagem.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RotaDbContext>(opt => opt.UseInMemoryDatabase("RotasDB"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rota API", Version = "v1" });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RotaDbContext>();
    dbContext.Seed();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapRotasEndpoints();

await app.RunAsync();