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
        public async Task<IActionResult> CriarMovimentacaoEquipamento([FromBody] CriarMovimentacaoEquipamentoCommand command)
                => Ok(await Mediator.Send(command));

        [SwaggerOperation(Summary = "Método para criar movimentação do equipamento")]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("movimentacao/{codigoPatrimonio}")]
        public async Task<IActionResult> ObterTodasMovimentacoesPorCodigoPatrimonio(int codigoPatrimonio)
        {

            var movimentacao = await Mediator.Send(new ObterTodasAsMovimentacoesPorCodigoPatrimonio() { CodigoPatrimonio = codigoPatrimonio });

            return StatusCode(HTTPStatusHelper.RetornaStatus(movimentacao), movimentacao);

        }

        [SwaggerOperation(Summary = "Método para atualizar movimentação do patrimonio")]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPut("{codigoMovimentacao}")]
        public async Task<IActionResult> AtualizarMovimentacao(int codigoMovimentacao, [FromBody] AtualizarMovimentacaoEquipamentoCommand command)
        {

            command.CodigoMovimentacao = codigoMovimentacao;

            var statusCode = StatusCode(await Mediator.Send(command));

            if (statusCode.StatusCode == 404)
                return NotFound("Nenhum registro encontrado!");

            return Ok();

        }


        [SwaggerOperation(Summary = "Método para obter apenas uma movimentação")]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("{codigoMovimentacao}")]
        public async Task<IActionResult> ObterApenasUmaMovimentacao(int codigoMovimentacao)
        {
            var movimentacao = await Mediator.Send(new ObterApenasUmaMovimentacao() { CodigoMovimentacao = codigoMovimentacao });

            return StatusCode(HTTPStatusHelper.RetornaStatus(movimentacao), movimentacao);

        }
    }
}
