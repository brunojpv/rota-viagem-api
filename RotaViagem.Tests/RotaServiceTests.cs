using Microsoft.EntityFrameworkCore;
using RotaViagem.Data;
using RotaViagem.Services;

namespace RotaViagem.Tests
{
    public class RotaServiceTests
    {
        private static RotaDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RotaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RotaDbContext(options);
            context.Seed();
            return context;
        }

        [Fact]
        public async Task MelhorRota_GRU_CDG_DeveRetornarRotaDe40()
        {
            var context = GetDbContext();
            var service = new RotaService(context);

            var (caminho, custo) = await service.BuscarMelhorRotaAsync("GRU", "CDG");

            Assert.Equal(40, custo);
            Assert.Equal(new[] { "GRU", "BRC", "SCL", "ORL", "CDG" }, caminho);
        }

        [Fact]
        public async Task MelhorRota_BRC_SCL_DeveRetornar5()
        {
            var context = GetDbContext();
            var service = new RotaService(context);

            var (caminho, custo) = await service.BuscarMelhorRotaAsync("BRC", "SCL");

            Assert.Equal(5, custo);
            Assert.Equal(new[] { "BRC", "SCL" }, caminho);
        }

        [Fact]
        public async Task MelhorRota_Inexistente_DeveRetornarMaxValue()
        {
            var context = GetDbContext();
            var service = new RotaService(context);

            var (caminho, custo) = await service.BuscarMelhorRotaAsync("AAA", "BBB");

            Assert.Equal(decimal.MaxValue, custo);
            Assert.Empty(caminho);
        }
    }
}