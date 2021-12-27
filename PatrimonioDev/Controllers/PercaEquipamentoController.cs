using Aplicacao.Features.PercaEquipamentoFeature.Commands;
using Aplicacao.Features.PercaEquipamentoFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class PercaEquipamentoController : BaseApiController
    {

        [HttpPost("/perca")]
        public async Task<IActionResult> CriarPercaEquipamento(CriarPercaEquipamentoCommand command)
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

        [HttpGet("/perca/{id}")]
        public async Task<IActionResult> ListarPercaEquipamentoPorId(int id)
        {
            try
            {
                var empresa = await Mediator.Send(new ObterPercaEquipamentoPorId() { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(empresa), empresa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [HttpPut("/perca/[action]")]
        public async Task<IActionResult> AtualizarPercaEquipamento(AtualizarPercaEquipamentoCommand command)
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

        [HttpDelete("/perca/{id}")]
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
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }
    }
}
