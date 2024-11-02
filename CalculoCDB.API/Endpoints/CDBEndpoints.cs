using CalculoCDB.API.DTOs;
using CalculoCDB.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.API.Endpoints;

public static class CdbEndpoints
{
    public static void AddCDBEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/calcular", async (
            [AsParameters] SimulacaoRequest request, 
            [FromServices] ICDBService service) =>
        {
            var result = await service.CalcularInvestimento(request);

            return Results.Ok(result);
        });
    }
}
