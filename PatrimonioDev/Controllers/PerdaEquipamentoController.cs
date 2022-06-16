using Aplicacao.Features.PercaEquipamentoFeature.Commands;
using Aplicacao.Features.PerdaEquipamentoFeature.Queries;
using Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    [Route("api/perdas")]
    public class PerdaEquipamentoController : BaseApiController
    {

        [SwaggerOperation(Summary = "Método para criar perdas de equipamento")]
        [ProducesResponseType(typeof(PerdaEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarPerdaEquipamento([FromBody] CriarPerdaEquipamentoCommand command)
             => Ok(await Mediator.Send(command));

        [SwaggerOperation(Summary = "Método para obter todas as perdas")]
        [ProducesResponseType(typeof(PerdaEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> ObterTodasPerdas()
            => Ok(await Mediator.Send(new ObterTodasPerdas()));
    }
}
