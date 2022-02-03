using Aplicacao.Features.PercaEquipamentoFeature.Commands;
using Aplicacao.Features.PercaEquipamentoFeature.Queries;
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
    public class PercaEquipamentoController : BaseApiController
    {

        [SwaggerOperation(Summary = "Método para criar perca de equipamento")]
        [ProducesResponseType(typeof(PercaEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarPercaEquipamento([FromBody]CriarPercaEquipamentoCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.Message} {ex.InnerException}");
            }

        }

        [SwaggerOperation(Summary = "Método para buscar perca de equipamento específico")]
        [ProducesResponseType(typeof(PercaEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPercaEquipamentoPorId(int id)
        {
            try
            {
                var empresa = await Mediator.Send(new ObterPercaEquipamentoPorId() { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(empresa), empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [SwaggerOperation(Summary = "Método para atualizar perca de equipamento específico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{codigoPerda}")]
        public async Task<IActionResult> AtualizarPercaEquipamento(int codigoPerda, [FromBody]AtualizarPercaEquipamentoCommand command)
        {

            try
            {
                command.Id = codigoPerda;

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

        [SwaggerOperation(Summary = "Método para deletar perca de equipamento específico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPercaEquipamento(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new RemoverPercaEquipamentoCommand { Id = id }));

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
