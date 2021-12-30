using Aplicacao.Features.EmpresaFeature.Commands;
using Aplicacao.Features.EmpresaFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;

namespace PatrimonioDev.Controllers
{
    [Route("api/[controller]")]
    public class EmpresaController : BaseApiController
    {

        /// <summary>
        /// Método para cadastrar uma empresa
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para listar todas as empresas
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para a empresa por Id
        /// </summary>
        /// <param name="id"> Id da empresa</param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para atualizar a empresa
        /// </summary>
        /// <param name=""></param>
        /// <returns>teste</returns>
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

        /// <summary>
        /// Método para remover a empresa
        /// </summary>
        /// <param name="id"> Id da empresa para deletar</param>
        /// <returns>teste</returns>
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
