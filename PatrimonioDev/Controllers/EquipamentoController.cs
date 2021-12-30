using Aplicacao.Features.EquipamentoFeature.Commands;
using Aplicacao.Features.EquipamentoFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;

namespace PatrimonioDev.Controllers
{
    [Route("api/[controller]")]
    public class EquipamentoController : BaseApiController
    {

        /// <summary>
        /// Método para cadastrar um equipamento
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Equipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/equipamento")]
        public async Task<IActionResult> CriarEquipamento(CriarEquipamentoCommand command)
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
        /// Método para listar todos os equipamentos
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Equipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        /// <summary>
        /// Método para listar equipamento específico
        /// </summary>
        /// <param name="id"> Id para listar o equipamento</param>
        /// <returns>Retonra algo</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Equipamento),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        /// <summary>
        /// Método para atualizar o equipamento
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("/equipamento/[action]")]
        public async Task<IActionResult> AtualizarEquipamento(AtualizarEquipamentoCommand command)
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
        /// Método para remover o equipamento
        /// </summary>
        /// <param name="id"> Id para remover o equipamento</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [HttpDelete("/equipamento/{id}")]
        public async Task<IActionResult> DeletarEquipamento(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarEquipamentoCommand() { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500 ,$"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }
    }
}
