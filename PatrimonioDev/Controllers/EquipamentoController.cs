using Aplicacao.Features.EquipamentoFeature.Commands;
using Aplicacao.Features.EquipamentoFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Swashbuckle.AspNetCore.Annotations;
using Aplicacao.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace PatrimonioDev.Controllers
{
    [Route("api/equipamentos")]
    public class EquipamentoController : BaseApiController
    {


        [SwaggerOperation(Summary = "Método para cadastrar um equipamento")]
        [ProducesResponseType(typeof(EquipamentoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarEquipamento([FromBody]CriarEquipamentoCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message} {ex.InnerException}");
            }

        }


        [SwaggerOperation(Summary = "Método para listar todos os equipamentos")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Equipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet]
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


        [SwaggerOperation(Summary = "Método para listar equipamento específico")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Equipamento),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("{id}")]
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

        [SwaggerOperation(Summary = "Método para atualizar o equipamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPut("{codigoEquipamento}")]
        public async Task<IActionResult> AtualizarEquipamento(int codigoEquipamento, [FromBody]AtualizarEquipamentoCommand command)
        {

            try
            {
                command.Id = codigoEquipamento;

                var statusCode = StatusCode(await Mediator.Send(command));

                if (statusCode.StatusCode == 404)
                    return NotFound("Nenhum registro encontrado!");

                return Ok();


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.Message} {ex.InnerException}");
            }
        }

 
        [SwaggerOperation(Summary = "Método para remover o equipamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpDelete("{id}")]
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
