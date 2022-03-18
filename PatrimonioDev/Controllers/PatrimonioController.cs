using Aplicacao.Features.PatrimonioFeature.Commands;
using Aplicacao.Features.PatrimonioFeature.Queries;
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
    [Route("api/patrimonios")]
    public class PatrimonioController : BaseApiController
    {

        [SwaggerOperation(Summary = "Método para criar patrimonio")]
        [ProducesResponseType(typeof(Patrimonio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarPatrimonio([FromBody]CriarPatrimonioCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }

        }

        [SwaggerOperation(Summary = "Método para buscar por patrimonio específico")]
        [ProducesResponseType(typeof(Patrimonio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPatrimonioPorId(int id)
        {
            try
            {
                var patrimonio = await Mediator.Send(new ObterPatrimonioPorId() { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(patrimonio), patrimonio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para atualizar patrimonio específico")]
        [ProducesResponseType(typeof(Patrimonio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPut("{codigoPatrimonio}")]
        public async Task<IActionResult> AtualizarPatrimonio(int codigoPatrimonio, [FromBody]AtualizarPatrimonioCommand command)
        {

            try
            {
                command.Id = codigoPatrimonio;

                var statusCode = StatusCode(await Mediator.Send(command));

                if (statusCode.StatusCode == 404)
                    return NotFound("Nenhum registro encontrado!");

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }


        [SwaggerOperation(Summary = "Método para deletar patrimonio específico")]
        [ProducesResponseType(typeof(Patrimonio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpDelete("{codigoPatrimonio}")]
        public async Task<IActionResult> DeletarPatrimonio(int codigoPatrimonio)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new RemoverPatrimonioCommand() { Id = codigoPatrimonio }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                return Ok();


            }
            catch (Exception ex)
            {

                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }
    }
}
