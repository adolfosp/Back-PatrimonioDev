using Aplicacao.Features.FabricanteFeature.Commands;
using Aplicacao.Features.FabricanteFeature.Queries;
using Domain.Entidades;
using Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    [Route("api/fabricantes")]
    public class FabricanteController : BaseApiController
    {

        [SwaggerOperation(Summary = "Método para cadastrar um fabricante")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarFabricante([FromBody] CriarFabricanteCommand command)
                => Ok(await Mediator.Send(command));

        [SwaggerOperation(Summary = "Método para buscar todos os fabricantes")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListarTodosFabricantes()
        {
            var fabricante = await Mediator.Send(new ObterTodosFabricantes());

            return StatusCode(HTTPStatusHelper.RetornaStatus(fabricante), fabricante);
        }


        [SwaggerOperation(Summary = "Método para listar fabricante específico")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarFabricantePorId(int id)
        {
            var fabricante = await Mediator.Send(new ObterApenasUmFabricante { CodigoFabricante = id });

            return StatusCode(HTTPStatusHelper.RetornaStatus(fabricante), fabricante);

        }


        [SwaggerOperation(Summary = "Método para atualizar fabricante específico")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPut("{codigoFabricante}")]
        public async Task<IActionResult> AtualizarFabricante(int codigoFabricante, [FromBody] AtualizarFabricanteCommand command)
        {

            command.CodigoFabricante = codigoFabricante;

            var statusCode = StatusCode(await Mediator.Send(command));

            if (statusCode.StatusCode == 404)
                return NotFound("Nenhum registro encontrado!");

            return Ok();
        }


        [SwaggerOperation(Summary = "Método para deletar fabricante específico")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTipoEquipamento(int id)
        {

            var statusCode = StatusCode(await Mediator.Send(new DeletarFabricanteCommand() { CodigoFabricante = id }));

            if (statusCode.StatusCode == 404)
                return NotFound(new { mensagem = "Não foi encontrado registro para deletar" });

            return Ok();
        }
    }
}
