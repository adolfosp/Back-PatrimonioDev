using Aplicacao.Features.EmpresaFeature.Commands;
using Aplicacao.Features.EmpresaFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Swashbuckle.AspNetCore.Annotations;

namespace PatrimonioDev.Controllers
{
    [Route("api/[controller]")]
    public class EmpresaController : BaseApiController
    {


        [SwaggerOperation(Summary = "Método para cadastrar uma empresa")]
        [ProducesResponseType(typeof(Empresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/empresa")]
        
        public async Task<IActionResult> CriarEmpresa(CriarEmpresaCommand command)
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


        [SwaggerOperation(Summary = "Método para listar todas as empresas")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Empresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/empresa")]
        public async Task<IActionResult> ListarTodasEmpresas()
        {
            try
            {
                var empresa = await Mediator.Send(new ObterTodasEmpresas());

                return StatusCode(HTTPStatus.RetornaStatus(empresa), empresa);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [SwaggerOperation(Summary = "Método para a empresa por Id")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Empresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/empresa/{id}")]
        public async Task<IActionResult> ListarEmpresaPorId(int id)
        {
            try
            {
                var empresa = await Mediator.Send(new ObterApenasUmaEmpresa { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(empresa), empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [SwaggerOperation(Summary = "Método para atualizar a empresa")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("/empresa/[action]")]
        public async Task<IActionResult> AtualizarEmpresa(AtualizarEmpresaCommand command)
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


        [SwaggerOperation(Summary = "Método para remover a empresa")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/empresa/{id}")]
        public async Task<IActionResult> DeletarEmpresa(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarEmpresaCommand() { Id = id }));

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
