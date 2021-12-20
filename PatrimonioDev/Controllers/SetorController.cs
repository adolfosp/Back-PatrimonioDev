using Aplicacao.Features.SetorFeature.Commands;
using Aplicacao.Features.SetorFeature.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class SetorController : BaseApiController
    {
        [Route("setor/")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        public async Task<IActionResult> CriarSetor(CriarSetorCommand command)
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

        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("/setor/{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new ObterApenasUmSetor { Id = id }));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }


        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("/setor")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                return Ok(await Mediator.Send(new ObterTodosSetores()));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }

        }

        [ApiExplorerSettings(GroupName = "v1")]
        [HttpDelete("/setor/{id}")]
        public async Task<IActionResult> DeletarSetor(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarSetorCommand { Id = id }));

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

        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPut("/setor/[action]")]
        public async Task<IActionResult> AtualizarSetor(AtualizarSetorCommand command)
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
