using Aplicacao.Features.EquipamentoFeature.Commands;
using Aplicacao.Features.EquipamentoFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class EquipamentoController : BaseApiController
    {

        [HttpPost("/equipamento")]
        public async Task<IActionResult> CriarEquipamento(CriarEquipamentoCommand command)
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

        [HttpGet("/equipamento")]
        public async Task<IActionResult> ListarTodosEquipamento()
        {
            try
            {
                var equipamentos = await Mediator.Send(new ObterTodosEquipamento());

                return StatusCode(HTTPStatus.RetornaStatus(equipamentos), equipamentos);

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [HttpGet("/equipamento/{id}")]
        public async Task<IActionResult> ListarEquipamentoPorId(int id)
        {
            try
            {
                var equipamento = await Mediator.Send(new ObterApenasUmEquipamento { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(equipamento), equipamento);
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [HttpPut("/equipamento/[action]")]
        public async Task<IActionResult> AtualizarEquipamento(AtualizarEquipamentoCommand command)
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

        [HttpDelete("/equipamento/{id}")]
        public async Task<IActionResult> DeletarEquipamento(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarEquipamentoCommand() { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                else
                    return Ok();


            }
            catch (Exception ex)
            {

                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }
    }
}
