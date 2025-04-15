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

        [Fact(DisplayName = "Deve retornar a rota mais barata de GRU para CDG com custo 40")]
        public async Task MelhorRota_GRU_CDG_DeveRetornarRotaDe40()
        {
            var context = GetDbContext();
            var service = new RotaService(context);

            var (caminho, custo) = await service.BuscarMelhorRotaAsync("GRU", "CDG");

            Assert.Equal(40, custo);
            Assert.Equal(new[] { "GRU", "BRC", "SCL", "ORL", "CDG" }, caminho);
        }

        [Fact(DisplayName = "Deve retornar rota direta de BRC para SCL com custo 5")]
        public async Task MelhorRota_BRC_SCL_DeveRetornar5()
        {
            var context = GetDbContext();
            var service = new RotaService(context);

            var (caminho, custo) = await service.BuscarMelhorRotaAsync("BRC", "SCL");

            Assert.Equal(5, custo);
            Assert.Equal(new[] { "BRC", "SCL" }, caminho);
        }

        [Fact(DisplayName = "Deve retornar MaxValue e caminho vazio quando n�o houver rota dispon�vel")]
        public async Task MelhorRota_Inexistente_DeveRetornarMaxValue()
        {
            var context = GetDbContext();
            var service = new RotaService(context);

            var (caminho, custo) = await service.BuscarMelhorRotaAsync("AAA", "BBB");

            Assert.Equal(decimal.MaxValue, custo);
            Assert.Empty(caminho);
        }

        [Theory(DisplayName = "Deve lan�ar exce��o quando origem ou destino forem nulos ou vazios")]
        [InlineData(null, "CDG")]
        [InlineData("", "CDG")]
        [InlineData("GRU", null)]
        [InlineData("GRU", "")]
        public async Task BuscarMelhorRotaAsync_DeveLancarExcecao_QuandoParametrosInvalidos(string? origem, string? destino)
        {
            var context = GetDbContext();
            var service = new RotaService(context);

            await Assert.ThrowsAsync<ArgumentException>(() => service.BuscarMelhorRotaAsync(origem!, destino!));
        }
    }
}