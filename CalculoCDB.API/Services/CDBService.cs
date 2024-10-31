using CalculoCDB.API.DTOs;
using CalculoCDB.API.Repositories;

namespace CalculoCDB.API.Services;

public class CDBService(ITaxaRepository repo) : ICDBService
{
    private readonly ITaxaRepository _repo = repo;

    public async Task<RendimentoResponse> CalcularInvestimento(SimulacaoRequest simulacao)
    {
        decimal refJuros = 1 + (((decimal)_repo.TB) / 100) * (_repo.CDI / 100);
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

        return await Task.FromResult(new RendimentoResponse(vlLiquido, vlBruto));
    }
}
