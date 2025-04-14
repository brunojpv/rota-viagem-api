using Microsoft.EntityFrameworkCore;
using RotaViagem.Data;
using RotaViagem.Models;
using RotaViagem.Services;

namespace RotaViagem.Controllers
{
    public static class RotaController
    {
        public static void MapRotasEndpoints(this WebApplication app)
        {
            app.MapGet("/api/rotas", async (RotaDbContext db) => await db.Rotas.ToListAsync());

            app.MapPost("/api/rotas", async (RotaDbContext db, Rota rota) =>
            {
                db.Rotas.Add(rota);
                await db.SaveChangesAsync();
                return Results.Created($"/api/rotas/{rota.Id}", rota);
            });

            app.MapPut("/api/rotas/{id}", async (int id, RotaDbContext db, Rota rotaAtualizada) =>
            {
                var rota = await db.Rotas.FindAsync(id);
                if (rota is null) return Results.NotFound();

                rota.Origem = rotaAtualizada.Origem;
                rota.Destino = rotaAtualizada.Destino;
                rota.Valor = rotaAtualizada.Valor;

                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapDelete("/api/rotas/{id}", async (int id, RotaDbContext db) =>
            {
                var rota = await db.Rotas.FindAsync(id);
                if (rota is null) return Results.NotFound();

                db.Rotas.Remove(rota);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapGet("/api/rotas/melhor", async (string origem, string destino, RotaDbContext db) =>
            {
                var service = new RotaService(db);
                var (caminho, custo) = await service.BuscarMelhorRotaAsync(origem, destino);

                if (custo == decimal.MaxValue)
                    return Results.NotFound("Rota não encontrada");

                return Results.Ok($"{string.Join(" - ", caminho)} ao custo de ${custo}");
            });
        }
    }
}
