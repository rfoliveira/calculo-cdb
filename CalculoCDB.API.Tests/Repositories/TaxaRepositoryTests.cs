using CalculoCDB.API.Repositories;
using NSubstitute;

namespace CalculoCDB.API.Tests.Repositories
{
    public class TaxaRepositoryTests
    {
        private readonly TaxaRepository _repo = new();

        [Theory]
        [InlineData(-11)]
        [InlineData(5)]
        [InlineData(11)]
        [InlineData(15)]
        [InlineData(48)]
        public void GetAliquotaIR_DeveRetornarOK(short value)
        {
            var result = _repo.GetAliquotaIR(value);
            Assert.Contains(result, [22.5m, 20m, 17.5m, 15m]);            
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void GetAliquotaIR_DeveRetornar_Aliquota22_5(short value)
        {
            var result = _repo.GetAliquotaIR(value);
            Assert.Equal(22.5m, result);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void GetAliquotaIR_DeveRetornar_Aliquota20(short value)
        {
            var result = _repo.GetAliquotaIR(value);
            Assert.Equal(20m, result);
        }

        [Theory]
        [InlineData(22)]
        [InlineData(23)]
        [InlineData(24)]
        public void GetAliquotaIR_DeveRetornar_Aliquota17_5(short value)
        {
            var result = _repo.GetAliquotaIR(value);
            Assert.Equal(17.5m, result);
        }

        [Theory]
        [InlineData(25)]
        [InlineData(32)]
        [InlineData(48)]
        public void GetAliquotaIR_DeveRetornar_Aliquota15(short value)
        {
            var result = _repo.GetAliquotaIR(value);
            Assert.Equal(15m, result);
        }
    }
}
