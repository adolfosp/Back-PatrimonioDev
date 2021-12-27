using Aplicacao.Features.UsuarioPermissaoFeature.Commands;
using Aplicacao.Features.UsuarioPermissaoFeature.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Helpers;

namespace PatrimonioDev.Controllers
{
    public class UsuarioPermissaoController : BaseApiController
    {
        [HttpPost("/permissao")]
        public async Task<IActionResult> CriarUsuarioPermissao(CriarUsuarioPermissaoCommand command)
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

        [HttpGet("/permissao")]
        public async Task<IActionResult> ObterTodasPermissoes()
        {
            try
            {
                var permissoes = await Mediator.Send(new ObterTodasPermissoes());

                return StatusCode(HTTPStatus.RetornaStatus(permissoes), permissoes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }


        [HttpDelete("/permissao/{id}")]
        public async Task<IActionResult> DeletarUsuarioPermissao(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarUsuarioPermissaoCommand() { Id = id }));

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
