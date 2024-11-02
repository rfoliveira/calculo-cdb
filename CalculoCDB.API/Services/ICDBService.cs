using CalculoCDB.API.Models;
using System.Threading.Tasks;

namespace CalculoCDB.API.Services
{
    public interface ICdbService
    {
        Task<RendimentoResponseModel> CalcularInvestimentoAsync(SimulacaoRequestModel simulacao);
    }
}
