using CalculoCDB.API.Controllers;
using CalculoCDB.API.Models;
using CalculoCDB.API.Services;
using NSubstitute;
using System.Web.Http.Results;

namespace CalculoCDB.API.Tests.Controllers
{
    public class CdbControllerTests
    {
        private readonly ICdbService _service = Substitute.For<ICdbService>();
        private readonly CdbController _controller;

        public CdbControllerTests()
        {
            _controller = new CdbController(_service);
        }

        [Fact]
        public async Task Calcular_DeveRetornarOK()
        {
            var request = new SimulacaoRequestModel { VlInicial = 1000, QtdMeses = 12 };
            var response = new RendimentoResponseModel();
            
            _service.CalcularInvestimentoAsync(request).Returns(response);

            var result = await _controller.Get(request);

            Assert.IsType<OkNegotiatedContentResult<RendimentoResponseModel>>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Calcular_DeveRetornarErro_ValorInicial()
        {
            var request = new SimulacaoRequestModel { VlInicial = 0, QtdMeses = 10 };

            _controller.ModelState.AddModelError("VlInicial", "GreaterThan");
            var result = await _controller.Get(request);
            
            var invalidModelStateResult = Assert.IsType<InvalidModelStateResult>(result);
            Assert.True(invalidModelStateResult.ModelState.ContainsKey("VlInicial"));
        }

        [Fact]
        public async Task Calcular_DeveRetornarErro_Prazo()
        {
            var request = new SimulacaoRequestModel { VlInicial = 1000, QtdMeses = 1 };

            _controller.ModelState.AddModelError("QtdMeses", "GreaterThan");
            var result = await _controller.Get(request);
            
            var invalidModelStateResult = Assert.IsType<InvalidModelStateResult>(result);
            Assert.True(invalidModelStateResult.ModelState.ContainsKey("QtdMeses"));
        }
    }
}