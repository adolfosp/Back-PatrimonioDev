using Aplicacao.Features.EmpresaFeature.Commands;
using Aplicacao.Features.EmpresaFeature.Queries;
using Aplicacao.Features.PatrimonioFeature.Commands;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Aplicacao.Features.PatrimonioFeature.Queries;
using Domain.Entidades;
using Microsoft.AspNetCore.Http;

namespace PatrimonioDev.Controllers
{
    public class PatrimonioController : BaseApiController
    {

        /// <summary>
        /// Método para criar patrimonio
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Patrimonio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/patrimonio")]
        public async Task<IActionResult> CriarPatrimonio(CriarPatrimonioCommand command)
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
        /// Método para buscar por patrimonio específico
        /// </summary>
        /// <param name="id"> Id para buscar o patrimonio específico</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Patrimonio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/patrimonio/{id}")]
        public async Task<IActionResult> ListarPatrimonioPorId(int id)
        {
            try
            {
                var patrimonio = await Mediator.Send(new ObterPatrimonioPorId() { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(patrimonio), patrimonio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        /// <summary>
        /// Método para atualizar patrimonio específico
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Patrimonio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("/patrimonio/[action]")]
        public async Task<IActionResult> AtualizarPatrimonio(AtualizarPatrimonioCommand command)
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

        /// <summary>
        /// Método para deletar patrimonio específico
        /// </summary>
        /// <param name="id"> Id para deletar o patrimonio específico</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Patrimonio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/patrimonio/{codigoPatrimonio}")]
        public async Task<IActionResult> DeletarPatrimonio(int codigoPatrimonio)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new RemoverPatrimonioCommand() { Id = codigoPatrimonio }));

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
