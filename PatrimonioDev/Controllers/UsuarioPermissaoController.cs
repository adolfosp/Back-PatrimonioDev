using Aplicacao.Features.UsuarioPermissaoFeature.Commands;
using Aplicacao.Features.UsuarioPermissaoFeature.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace PatrimonioDev.Controllers
{
    [Route("api/permissoes")]
    public class UsuarioPermissaoController : BaseApiController
    {

        [SwaggerOperation(Summary = "Método para criar permissão")]
        [ProducesResponseType(typeof(UsuarioPermissao), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1,2")]
        [HttpPost]
        public async Task<IActionResult> CriarUsuarioPermissao([FromBody]CriarUsuarioPermissaoCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Erro interno no servidor. Mensagem: {ex.Message} {ex.InnerException}"});
            }

        }

        [SwaggerOperation(Summary = "Método para obter todas as permissões ")]
        [ProducesResponseType(typeof(UsuarioPermissao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UsuarioPermissao), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1,2")]
        [HttpGet]
        public async Task<IActionResult> ObterTodasPermissoes()
        {
            try
            {
                var permissoes = await Mediator.Send(new ObterTodasPermissoes());

                return StatusCode(HTTPStatus.RetornaStatus(permissoes), permissoes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}" });
            }
        }

        [SwaggerOperation(Summary = "Método para deletar permissão")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1,2")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuarioPermissao(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarUsuarioPermissaoCommand() { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                return Ok();

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}"});
            }
        }
    }
}
