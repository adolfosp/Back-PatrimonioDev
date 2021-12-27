using Aplicacao.Features.MovimentacaoEquipamentoFeature.Commands;
using Aplicacao.Features.MovimentacaoEquipamentoFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class MovimentacaoEquipamentoController : BaseApiController
    {
        [HttpPost("/movimentacao")]
        public async Task<IActionResult> CriarMovimentacaoEquipamento(CriarMovimentacaoEquipamentoCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }



        [HttpGet("/movimentacao/{codigoPatrimonio}")]
        public async Task<IActionResult> ObterTodasMovimentacoesPorCodigoPatrimonio(int codigoPatrimonio)
        {
            try
            {
                var movimentacao = await Mediator.Send(new ObterTodasAsMovimentacoesPorCodigoPatrimonio(){Id = codigoPatrimonio });

                return StatusCode(HTTPStatus.RetornaStatus(movimentacao), movimentacao);
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }

        }


        [HttpPut("/movimentacao/[action]")]
        public async Task<IActionResult> AtualizarSetor(AtualizarMovimentacaoEquipamentoCommand command)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(command));

                if (statusCode.StatusCode == 404)
                    return NotFound("Nenhum registro encontrado!");

                else
                    return Ok();


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.Message}");
            }
        }
    }
}
