using Aplicacao.Features.MovimentacaoEquipamentoFeature.Commands;
using Aplicacao.Features.MovimentacaoEquipamentoFeature.Queries;
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
    [Route("api/movimentacoes")]
    public class MovimentacaoEquipamentoController : BaseApiController
    {

        [SwaggerOperation(Summary = "Método para criar movimentação do equipamento")]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarMovimentacaoEquipamento([FromBody]CriarMovimentacaoEquipamentoCommand command)
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

        [SwaggerOperation(Summary = "Método para criar movimentação do equipamento")]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("{codigoPatrimonio}")]
        public async Task<IActionResult> ObterTodasMovimentacoesPorCodigoPatrimonio(int codigoPatrimonio)
        {
            try
            {
                var movimentacao = await Mediator.Send(new ObterTodasAsMovimentacoesPorCodigoPatrimonio() { Id = codigoPatrimonio });

                return StatusCode(HTTPStatus.RetornaStatus(movimentacao), movimentacao);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }

        }

        [SwaggerOperation(Summary = "Método para atualizar movimentação do patrimonio")]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPut("{codigoPatrimonio}")]
        public async Task<IActionResult> AtualizarMovimentacao(int codigoPatrimonio, [FromBody]AtualizarMovimentacaoEquipamentoCommand command)
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
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.Message} {ex.InnerException}");
            }
        }
    }
}
