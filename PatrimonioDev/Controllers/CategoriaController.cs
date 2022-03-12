using Aplicacao.Features.CategoriaFeature.Commands;
using Aplicacao.Features.CategoriaFeature.Queries;
using Domain.Entidades;
using Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
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
            try
            {
                var categorias = await Mediator.Send(new ObterTodasCategorias());

                return StatusCode(HTTPStatus.RetornaStatus(categorias), categorias);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [SwaggerOperation(Summary = "Método para cadastrar categoria")]
        [ProducesResponseType(typeof(CategoriaEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarCategoria([FromBody]CriarCategoriaCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Erro interno no servidor. Mensagem: {ex.Message} {ex.InnerException}"});
            }
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
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarCategoriaCommand { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [SwaggerOperation(Summary = "Método para atualizar a categoria")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize]
        [HttpPut("{codigoCategoria}")]
        public async Task<IActionResult> AtualizarEmpresa(int codigoCategoria, [FromBody] AtualizarCategoriaCommand command)
        {

            try
            {
                command.Categoria.CodigoCategoria = codigoCategoria;

                var statusCode = StatusCode(await Mediator.Send(command));

                if (statusCode.StatusCode == 404)
                    return NotFound("Nenhum registro encontrado!");

                return Ok();


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.Message} {ex.InnerException}");
            }
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
            try
            {
                var usuario = await Mediator.Send(new ObterApenasUmaCategoria { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(usuario), usuario);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}" });
            }
        }
    }
}
