using Aplicacao.Features.MovimentacaoEquipamentoFeature.Commands;
using Aplicacao.Features.MovimentacaoEquipamentoFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Microsoft.AspNetCore.Http;

namespace PatrimonioDev.Controllers
{
    [Route("api/[controller]")]
    public class MovimentacaoEquipamentoController : BaseApiController
    {
        /// <summary>
        /// Método para criar movimentação do equipamento
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/movimentacao")]
        public async Task<IActionResult> CriarMovimentacaoEquipamento(CriarMovimentacaoEquipamentoCommand command)
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


        /// <summary>
        /// Método para criar movimentação do equipamento
        /// </summary>
        /// <param name="codigoPatrimonio"> Id para buscar todas as movimentações do patrimonio</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/movimentacao/{codigoPatrimonio}")]
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

        /// <summary>
        /// Método para atualizar movimentação do patrimonio
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovimentacaoEquipamento), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("/movimentacao/[action]")]
        public async Task<IActionResult> AtualizarMovimentacao(AtualizarMovimentacaoEquipamentoCommand command)
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
    }
}
