using CalculoCDB.API.DTOs;

namespace CalculoCDB.API.Services;

public interface ICDBService
{
    Task<RendimentoResponse> CalcularInvestimento(SimulacaoRequest simulacao);
}
