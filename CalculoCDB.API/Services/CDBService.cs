using CalculoCDB.API.Models;
using CalculoCDB.API.Repositories;
using System.Threading.Tasks;

namespace CalculoCDB.API.Services
{
    public class CdbService : ICdbService
    {
        private readonly ITaxaRepository _repo;

        public CdbService(ITaxaRepository repo)
        {
            _repo = repo;
        }

        public async Task<RendimentoResponseModel> CalcularInvestimentoAsync(SimulacaoRequestModel simulacao)
        {
            var refJuros = 1 + (((decimal)_repo.TB) / 100) * (_repo.CDI / 100);
            var vlBruto = simulacao.VlInicial * refJuros;
            var qtdMesesAux = simulacao.QtdMeses;
            qtdMesesAux--;

            var rendimentoTotal = vlBruto - simulacao.VlInicial;

            while (qtdMesesAux > 0)
            {
                rendimentoTotal += (vlBruto - (vlBruto * refJuros)) * -1;
                vlBruto = (vlBruto * refJuros);
                qtdMesesAux--;
            }

            var vlIR = (rendimentoTotal * (_repo.GetAliquotaIR(qtdMesesAux) / 100));
            var vlLiquido = vlBruto - vlIR;

            return await Task.FromResult(new RendimentoResponseModel
            {
                VlLiquido = vlLiquido,
                VlBruto = vlBruto
            });
        }
    }
}