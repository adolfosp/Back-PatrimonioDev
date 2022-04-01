using Aplicacao.Features.EmpresaFeature.Commands;
using Aplicacao.Features.EmpresaFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Domain.Enums;

namespace PatrimonioDev.Controllers
{
    [Route("api/empresas")]
    public class EmpresaController : BaseApiController
    {


        [SwaggerOperation(Summary = "Método para cadastrar uma empresa")]
        [ProducesResponseType(typeof(Empresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> CriarEmpresa([FromBody]CriarEmpresaCommand command)
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


        [SwaggerOperation(Summary = "Método para listar todas as empresas")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Empresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpGet]
        public async Task<IActionResult> ListarTodasEmpresas()
        {
            try
            {
                var empresa = await Mediator.Send(new ObterTodasEmpresas());

                return StatusCode(HTTPStatus.RetornaStatus(empresa), empresa);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para buscar a empresa por Id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Empresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarEmpresaPorId(int id)
        {
            try
            {
                var empresa = await Mediator.Send(new ObterApenasUmaEmpresa { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(empresa), empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para buscar empresa empresa padrão de impressão")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Empresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpGet("empresaPadrao")]
        public async Task<IActionResult> ListarEmpresaPadrao()
        {
            try
            {
                var empresa = await Mediator.Send(new ObterEmpresaPadrao());

                return StatusCode(HTTPStatus.RetornaStatus(empresa), empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para atualizar a empresa")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpPut("{codigoEmpresa}")]
        public async Task<IActionResult> AtualizarEmpresa(int codigoEmpresa, [FromBody]AtualizarEmpresaCommand command)
        {

            try
            {
                if (TratamentoRegistroSistema.EhRegistroPadraoSistema(EntidadesRegistroPadrao.Empresa, codigoEmpresa))
                    return BadRequest(new { mensagem = "Não é possível realizar essa operação com registro padrão." });

                command.Id = codigoEmpresa;

                var resposta = await Mediator.Send(command);

                if (resposta.CodigoStatus == 404)
                    return NotFound("Nenhum registro encontrado!");

                if (resposta.CodigoStatus == 400)
                    return BadRequest(new { mensagem = $"A empresa de nome fantasia '{resposta.NomeEmpresa}' já está com a opção 'Empresa Padrão Impressão' marcada" });

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }


        [SwaggerOperation(Summary = "Método para remover a empresa")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEmpresa(int id)
        {
            try
            {
                if (TratamentoRegistroSistema.EhRegistroPadraoSistema(EntidadesRegistroPadrao.Empresa, id))
                    return BadRequest(new { mensagem = "Não é possível realizar essa operação com registro padrão." });

                var statusCode = StatusCode(await Mediator.Send(new DeletarEmpresaCommand() { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }
    }
}
