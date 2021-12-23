using Aplicacao.Features.SetorFeature.Commands;
using Aplicacao.Features.SetorFeature.Queries;
using Microsoft.AspNetCore.Mvc;
using PatrimonioDev.Helpers;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class SetorController : BaseApiController
    {
        [HttpPost("/setor")]
        public async Task<IActionResult> CriarSetor(CriarSetorCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }


        [HttpGet("/setor/{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {
            try
            {
                var setor = await Mediator.Send(new ObterApenasUmSetor { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(setor));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }


        [HttpGet("/setor")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var setor =await Mediator.Send(new ObterTodosSetores());

                return StatusCode(HTTPStatus.RetornaStatus(setor));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }

        }

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
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }

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
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.InnerException}");
            }
        }
    }
}
