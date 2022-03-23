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
using Aplicacao.Features.UsuarioFeature.Queries;
using Domain.Enums;

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
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
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
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para buscar uma permissão específica")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "1,2")]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {
            try
            {
                var usuario = await Mediator.Send(new ObterApenasUmaPermissao { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(usuario), usuario);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para deletar permissão")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "1,2")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuarioPermissao(int id)
        {
            try
            {
                if (TratamentoRegistroSistema.EhRegistroPadraoSistema(EntidadesRegistroPadrao.Permissao, id))
                    return BadRequest(new { mensagem = "Não é possível realizar essa operação com registro padrão." });

                var statusCode = StatusCode(await Mediator.Send(new DeletarUsuarioPermissaoCommand() { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                return Ok();

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para atualizar uma permissão específica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "1,2")]
        [HttpPut("{codigoPermissao}")]
        public async Task<IActionResult> AtualizarPermissaoUsuario(int codigoPermissao, [FromBody] AtualizarPermissaoCommand command)
        {
            try
            {
                if (TratamentoRegistroSistema.EhRegistroPadraoSistema(EntidadesRegistroPadrao.Permissao, codigoPermissao))
                    return BadRequest(new { mensagem = "Não é possível realizar essa operação com registro padrão." });

                command.Id = codigoPermissao;

                var statusCode = StatusCode(await Mediator.Send(command));

                if (statusCode.StatusCode == 404)
                    return NotFound("Nenhum registro encontrado!");

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }
    }
}
