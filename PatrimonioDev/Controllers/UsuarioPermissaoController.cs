using Aplicacao.Features.UsuarioPermissaoFeature.Commands;
using Aplicacao.Features.UsuarioPermissaoFeature.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;

namespace PatrimonioDev.Controllers
{
    public class UsuarioPermissaoController : BaseApiController
    {

        /// <summary>
        /// Método para criar permissão 
        /// </summary>
        /// <param name=""> </param>
        /// <returns></returns>
        [ProducesResponseType(typeof(UsuarioPermissao), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/permissao")]
        public async Task<IActionResult> CriarUsuarioPermissao(CriarUsuarioPermissaoCommand command)
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
        /// Método para obter todas as permissões 
        /// </summary>
        /// <param name=""> </param>
        /// <returns></returns>
        [ProducesResponseType(typeof(UsuarioPermissao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UsuarioPermissao), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        /// <summary>
        /// Método para deletar permissão 
        /// </summary>
        /// <param name="id">  Id para deletar permissão</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/permissao/{id}")]
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

                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }
    }
}
