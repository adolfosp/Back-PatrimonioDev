using Aplicacao.Features.InformacaoAdicionalFeature.Commands;
using Aplicacao.Features.InformacaoAdicionalFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Microsoft.AspNetCore.Http;

namespace PatrimonioDev.Controllers
{
    [Route("api/[controller]")]
    public class InformacaoAdicionalController : BaseApiController
    {
        /// <summary>
        /// Método para criar info adicional
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/info")]
        public async Task<IActionResult> CriarInformacaoAdicional(CriarInformacaoAdicionalCommand command)
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
        /// Método para listar info adicional específico
        /// </summary>
        /// <param name="id"> Id para buscar informacao adicional específica</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/info/{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {
            try
            {
                var informacaoAdicional = await Mediator.Send(new ObterInformacaoAdicionalPorId { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(informacaoAdicional), informacaoAdicional);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }



        /// <summary>
        /// Método para deletar info adicional específico
        /// </summary>
        /// <param name="id"> Id para deletar informacao adicional específica</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/info/{id}")]
        public async Task<IActionResult> DeletarInformacaoAdicional(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new RemoverInformacaoAdicionalCommand { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        /// <summary>
        /// Método para atualizar info adicional específico
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InformacaoAdicional), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("/info/[action]")]
        public async Task<IActionResult> AtualizarInformacao(AtualizarInformacaoAdicionalCommand command)
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

