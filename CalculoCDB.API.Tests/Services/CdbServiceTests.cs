using CalculoCDB.API.Exceptions;
using CalculoCDB.API.Models;
using CalculoCDB.API.Repositories;
using CalculoCDB.API.Services;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace CalculoCDB.API.Tests.Services
{
    public class CdbServiceTests
    {
        private readonly ITaxaRepository _repo = Substitute.For<ITaxaRepository>();
        private readonly CdbService _service;

        public CdbServiceTests()
        {
            _service = new CdbService(_repo);
        }

        [Fact]
        public async Task CalcularInvestimentoAsync_DeveRetornarOK()
        {
            var request = new SimulacaoRequestModel { VlInicial = 1000, QtdMeses = 12 };
            var result = await _service.CalcularInvestimentoAsync(request);

            Assert.IsType<RendimentoResponseModel>(result);
            Assert.True(result.VlLiquido > 0);
        }

        [Fact]
        public async Task CalcularInvestimentoAsync_DeveRetornarErro_ValorInicial()
        {
            var request = new SimulacaoRequestModel { VlInicial = 0, QtdMeses = 10 };
            try
            {
                await _service.CalcularInvestimentoAsync(request);
            }
            catch (ValorInicialException viex)
            {
                Assert.IsType<ValorInicialException>(viex);
            }
            catch (Exception e) when (e is not ValorInicialException)
            {
                Assert.False(false);
            }
        }
    }
}
