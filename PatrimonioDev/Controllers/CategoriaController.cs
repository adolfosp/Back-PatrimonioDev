using Aplicacao.Features.CategoriaFeature.Commands;
using Aplicacao.Features.CategoriaFeature.Queries;
using Domain.Entidades;
using Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{

    [Route("api/categorias")]
    public class CategoriaController : BaseApiController
    {
        [SwaggerOperation(Summary = "Método para obter todas as categorias")]
        [ProducesResponseType(typeof(CategoriaEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ObterTodasCategorias()
        {

            var categorias = await Mediator.Send(new ObterTodasCategorias());

            return StatusCode(HTTPStatusHelper.RetornaStatus(categorias), categorias);

        }

        [SwaggerOperation(Summary = "Método para cadastrar categoria")]
        [ProducesResponseType(typeof(CategoriaEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarCategoria([FromBody] CriarCategoriaCommand command)
        {

            var categoria = await Mediator.Send(command);

            return StatusCode(HTTPStatusHelper.RetornaStatus(categoria), categoria);

        }

        [SwaggerOperation(Summary = "Método para deletar uma categoria específico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCategoria(int id)
        {

            var statusCode = StatusCode(await Mediator.Send(new DeletarCategoriaCommand { Id = id }));

            if (statusCode.StatusCode == 404)
                return NotFound("Não foi encontrado registro para deletar");

            return Ok();

        }

        [SwaggerOperation(Summary = "Método para atualizar a categoria")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize]
        [HttpPut("{codigoCategoria}")]
        public async Task<IActionResult> AtualizarCategoria(int codigoCategoria, [FromBody] AtualizarCategoriaCommand command)
        {

            command.Categoria.CodigoCategoria = codigoCategoria;

            var statusCode = StatusCode(await Mediator.Send(command));

            if (statusCode.StatusCode == 404)
                return NotFound("Nenhum registro encontrado!");

            return Ok();

        }

        [SwaggerOperation(Summary = "Método para buscar uma categoria específica")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {

            var usuario = await Mediator.Send(new ObterApenasUmaCategoria { Id = id });

            return StatusCode(HTTPStatusHelper.RetornaStatus(usuario), usuario);

        }
    }
}
