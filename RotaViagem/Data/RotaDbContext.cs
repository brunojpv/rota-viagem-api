using Microsoft.EntityFrameworkCore;
using RotaViagem.Models;

namespace RotaViagem.Data
{
    public class RotaDbContext : DbContext
    {
        public RotaDbContext(DbContextOptions<RotaDbContext> options) : base(options) { }

        public DbSet<Rota> Rotas => Set<Rota>();
    }
}
