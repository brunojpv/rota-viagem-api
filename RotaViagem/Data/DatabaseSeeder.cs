using RotaViagem.Models;

namespace RotaViagem.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(this RotaDbContext context)
        {
            if (context.Rotas.Any()) return;

            var rotas = new List<Rota>
        {
            new Rota { Origem = "GRU", Destino = "BRC", Valor = 10 },
            new Rota { Origem = "BRC", Destino = "SCL", Valor = 5 },
            new Rota { Origem = "GRU", Destino = "CDG", Valor = 75 },
            new Rota { Origem = "GRU", Destino = "SCL", Valor = 20 },
            new Rota { Origem = "GRU", Destino = "ORL", Valor = 56 },
            new Rota { Origem = "ORL", Destino = "CDG", Valor = 5 },
            new Rota { Origem = "SCL", Destino = "ORL", Valor = 20 }
        };

            context.Rotas.AddRange(rotas);
            context.SaveChanges();
        }
    }
}
