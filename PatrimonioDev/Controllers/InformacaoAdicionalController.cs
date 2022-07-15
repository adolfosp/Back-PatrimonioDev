using Aplicacao.Features.InformacaoAdicionalFeature.Commands;
using Aplicacao.Features.InformacaoAdicionalFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace PatrimonioDev.Controllers
{
    [Route("api/informacoes")]
    [Obsolete]
    public class InformacaoAdicionalController : BaseApiController
    {

        [SwaggerOperation(Summary = "Método para criar info adicional")]
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarInformacaoAdicional([FromBody] CriarInformacaoAdicionalCommand command)
                => Ok(await Mediator.Send(command));

        [SwaggerOperation(Summary = "Método para listar info adicional específico")]
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {

            var informacaoAdicional = await Mediator.Send(new ObterInformacaoAdicionalPorId { CodigoInformacaoAdicional = id });

            return StatusCode(HTTPStatusHelper.RetornaStatus(informacaoAdicional), informacaoAdicional);

        }

        [SwaggerOperation(Summary = "Método para deletar info adicional específico")]
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarInformacaoAdicional(int id)
        {

            var statusCode = StatusCode(await Mediator.Send(new RemoverInformacaoAdicionalCommand { CodigoInformacaoAdicional = id }));

            if (statusCode.StatusCode == 404)
                return NotFound("Não foi encontrado registro para deletar");

            return Ok();
        }

        [SwaggerOperation(Summary = "Método para atualizar info adicional específico")]
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPut("{codigoInfo}")]
        public async Task<IActionResult> AtualizarInformacao(int codigoInfo, [FromBody] AtualizarInformacaoAdicionalCommand command)
        {

            command.CodigoInformacaoAdicional = codigoInfo;

            var statusCode = StatusCode(await Mediator.Send(command));

            if (statusCode.StatusCode == 404)
                return NotFound("Nenhum registro encontrado!");

            return Ok();

        }
    }
}

