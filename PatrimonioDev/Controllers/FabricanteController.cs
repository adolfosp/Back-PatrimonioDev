using Aplicacao.Features.FabricanteFeature.Commands;
using Aplicacao.Features.FabricanteFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace PatrimonioDev.Controllers
{
    [Route("api/[controller]")]
    public class FabricanteController : BaseApiController
    {

        [SwaggerOperation(Summary = "Método para cadastrar um fabricante")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/fabricante")]
        public async Task<IActionResult> CriarFabricante(CriarFabricanteCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }

        }


        [SwaggerOperation(Summary = "Método para cadastrar um fabricante")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/fabricante")]
        public async Task<IActionResult> ListarTodosFabricantes()
        {
            try
            {
                var fabricante = await Mediator.Send(new ObterTodosFabricantes());

                return StatusCode(HTTPStatus.RetornaStatus(fabricante), fabricante);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }


        [SwaggerOperation(Summary = "Método para listar fabricante específico")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/fabricante/{id}")]
        public async Task<IActionResult> ListarFabricantePorId(int id)
        {
            try
            {
                var fabricante = await Mediator.Send(new ObterApenasUmFabricante { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(fabricante), fabricante);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }


        [SwaggerOperation(Summary = "Método para atualizar fabricante específico")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("/fabricante/[action]")]
        public async Task<IActionResult> AtualizarFabricante(AtualizarFabricanteCommand command)
        {

            try
            {
                var statusCode = StatusCode(await Mediator.Send(command));

                if (statusCode.StatusCode == 404)
                    return NotFound("Nenhum registro encontrado!");

                return Ok();


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.Message}");
            }
        }


        [SwaggerOperation(Summary = "Método para deletar fabricante específico")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/fabricante/{id}")]
        public async Task<IActionResult> DeletarTipoEquipamento(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarFabricanteCommand() { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                return Ok();

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }
    }
}
