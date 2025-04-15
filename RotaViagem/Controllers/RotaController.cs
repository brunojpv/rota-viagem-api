using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RotaViagem.Data;
using RotaViagem.Models;
using RotaViagem.Services;

namespace RotaViagem.Controllers
{
    /// <summary>
    /// Define os endpoints de rota usando Minimal API.
    /// </summary>
    public static class RotaController
    {
        public static void MapRotasEndpoints(this WebApplication app)
        {
            app.MapGet("/api/rotas", async Task<Ok<List<Rota>>> (RotaDbContext db) =>
            {
                var rotas = await db.Rotas.ToListAsync();
                return TypedResults.Ok(rotas);
            })
            .WithName("ObterTodasAsRotas")
            .WithDescription("Retorna a lista de todas as rotas cadastradas.")
            .WithTags("Rotas");

            app.MapPost("/api/rotas", async Task<Created<Rota>> (RotaDbContext db, Rota rota) =>
            {
                db.Rotas.Add(rota);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/rotas/{rota.Id}", rota);
            })
            .WithName("CriarRota")
            .WithDescription("Cadastra uma nova rota com origem, destino e valor.")
            .WithTags("Rotas");

            app.MapPut("/api/rotas/{id}", async Task<Results<NoContent, NotFound>> (int id, RotaDbContext db, Rota rotaAtualizada) =>
            {
                var rota = await db.Rotas.FindAsync(id);
                if (rota is null) return TypedResults.NotFound();

                rota.Origem = rotaAtualizada.Origem;
                rota.Destino = rotaAtualizada.Destino;
                rota.Valor = rotaAtualizada.Valor;

                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            })
            .WithName("AtualizarRota")
            .WithDescription("Atualiza os dados de uma rota existente pelo ID.")
            .WithTags("Rotas");

            app.MapDelete("/api/rotas/{id}", async Task<Results<NoContent, NotFound>> (int id, RotaDbContext db) =>
            {
                var rota = await db.Rotas.FindAsync(id);
                if (rota is null) return TypedResults.NotFound();

                db.Rotas.Remove(rota);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            })
            .WithName("DeletarRota")
            .WithDescription("Remove uma rota do sistema pelo ID.")
            .WithTags("Rotas");

            app.MapGet("/api/rotas/melhor", async Task<Results<Ok<string>, NotFound<string>, BadRequest<string>>> (string origem, string destino, RotaDbContext db) =>
            {
                if (string.IsNullOrWhiteSpace(origem) || string.IsNullOrWhiteSpace(destino))
                    return TypedResults.BadRequest("Origem e destino são obrigatórios.");

                var service = new RotaService(db);
                var (caminho, custo) = await service.BuscarMelhorRotaAsync(origem, destino);

                if (custo == decimal.MaxValue)
                    return TypedResults.NotFound("Rota não encontrada");

                return TypedResults.Ok($"{string.Join(" - ", caminho)} ao custo de ${custo}");
            })
            .WithName("BuscarMelhorRota")
            .WithDescription("Retorna a rota mais barata entre dois pontos, independente de conexões.")
            .WithTags("Rotas");
        }
    }
}
