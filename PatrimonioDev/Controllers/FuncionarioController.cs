using Aplicacao.Features.FuncionarioFeature.Commands;
using Aplicacao.Features.FuncionarioFeature.Queries;
using Domain.Entidades;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class FuncionarioController: BaseApiController
    {

        [SwaggerOperation(Summary = "Método para cadastrar um funcionário")]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarFuncionario([FromBody] CriarFuncionarioCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.Message} {ex.InnerException}");
            }

        }


        [SwaggerOperation(Summary = "Método para listar todos os funcionario")]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> ListarTodosFuncionario()
        {
            try
            {
                var fabricante = await Mediator.Send(new ObterTodosFuncionarios());

                return StatusCode(HTTPStatus.RetornaStatus(fabricante), fabricante);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }


        [SwaggerOperation(Summary = "Método para listar um funcionario")]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarFuncionarioPorId(int id)
        {
            try
            {
                var fabricante = await Mediator.Send(new ObterFuncionarioPorId { CodigoFuncionario = id });

                return StatusCode(HTTPStatus.RetornaStatus(fabricante), fabricante);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }


        [SwaggerOperation(Summary = "Método para atualizar funcionario específico")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{codigoFuncionario}")]
        public async Task<IActionResult> AtualizarFuncionario(int codigoFuncionario, [FromBody]AtualizarFuncionarioCommand command)
        {

            try
            {
                command.CodigoFuncionario = codigoFuncionario;

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


        [SwaggerOperation(Summary = "Método para desativar funcionário específico")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarFuncionario(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DesativarFuncionarioCommand() { CodigoFuncionario = id }));

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
