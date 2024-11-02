using CalculoCDB.API.Models;
using CalculoCDB.API.Services;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CalculoCDB.API.Controllers
{
    [RoutePrefix("api/cdb")]
    public class CdbController : ApiController
    {
        private readonly ICdbService _service;

        public CdbController(ICdbService service)
        {
            _service = service;
        }

        [Route("calcular")]
        [ResponseType(typeof(RendimentoResponseModel))]
        public async Task<IHttpActionResult> Get([FromUri] SimulacaoRequestModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rendimento = await _service.CalcularInvestimentoAsync(request);

            return Ok(rendimento);
        }
    }
}
