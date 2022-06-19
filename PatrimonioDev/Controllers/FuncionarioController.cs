using Aplicacao.Features.FuncionarioFeature.Commands;
using Aplicacao.Features.FuncionarioFeature.Queries;
using Domain.Entidades;
using Domain.Enums;
using Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    [Route("api/funcionarios")]
    public class FuncionarioController : BaseApiController
    {

        [SwaggerOperation(Summary = "Método para cadastrar um funcionário")]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarFuncionario([FromBody] CriarFuncionarioCommand command)
                => Ok(await Mediator.Send(command));

        [SwaggerOperation(Summary = "Método para listar todos os funcionario")]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListarTodosFuncionario()
        {

            var fabricante = await Mediator.Send(new ObterTodosFuncionarios());

            return StatusCode(HTTPStatusHelper.RetornaStatus(fabricante), fabricante);
        }


        [SwaggerOperation(Summary = "Método para listar um funcionario")]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarFuncionarioPorId(int id)
        {

            var fabricante = await Mediator.Send(new ObterFuncionarioPorId { CodigoFuncionario = id });

            return StatusCode(HTTPStatusHelper.RetornaStatus(fabricante), fabricante);
        }


        [SwaggerOperation(Summary = "Método para atualizar funcionario específico")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPut("{codigoFuncionario}")]
        public async Task<IActionResult> AtualizarFuncionario(int codigoFuncionario, [FromBody] AtualizarFuncionarioCommand command)
        {

            if (TratamentoRegistroSistemaHelper.EhRegistroPadraoSistema(EntidadesRegistroPadrao.Funcionario, codigoFuncionario))
                return BadRequest(new { mensagem = "Não é possível realizar essa operação com registro padrão." });

            command.CodigoFuncionario = codigoFuncionario;

            var statusCode = StatusCode(await Mediator.Send(command));

            if (statusCode.StatusCode == 404)
                return NotFound("Nenhum registro encontrado!");

            return Ok();
        }


        [SwaggerOperation(Summary = "Método para desativar funcionário específico")]
        [ProducesResponseType(typeof(Fabricante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DesativarFuncionario(int id)
        {

            if (TratamentoRegistroSistemaHelper.EhRegistroPadraoSistema(EntidadesRegistroPadrao.Funcionario, id))
                return BadRequest(new { mensagem = "Não é possível realizar essa operação com registro padrão." });

            var statusCode = StatusCode(await Mediator.Send(new DesativarFuncionarioCommand() { CodigoFuncionario = id }));

            if (statusCode.StatusCode == 404)
                return NotFound("Não foi encontrado registro para deletar");

            return Ok();
        }
    }
}
