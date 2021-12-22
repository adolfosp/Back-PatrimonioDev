using Aplicacao.Features.EmpresaFeature.Commands;
using Aplicacao.Features.EmpresaFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class EmpresaController : BaseApiController
    {

        [HttpPost("/empresa")]
        public async Task<IActionResult> CriarEmpresa(CriarEmpresaCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }

        }

        [HttpGet("/empresa")]
        public async Task<IActionResult> ListarTodasEmpresas()
        {
            try
            {
                return Ok(await Mediator.Send(new ObterTodasEmpresas()));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }

        [HttpGet("/empresa/{id}")]
        public async Task<IActionResult> ListarEmpresaPorId(int id)
        {
            try
            {
                var empresa = await Mediator.Send(new ObterApenasUmaEmpresa { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(empresa));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }

        [HttpPut("/empresa/[action]")]
        public async Task<IActionResult> AtualizarEmpresa(AtualizarEmpresaCommand command)
        {

            try
            {
                var statusCode = StatusCode(await Mediator.Send(command));

                if (statusCode.StatusCode == 404)
                    return NotFound("Nenhum registro encontrado!");

                else
                    return Ok();


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.InnerException}");
            }
        }

        [HttpDelete("/empresa/{id}")]
        public async Task<IActionResult> DeletarEmpresa(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarEmpresaCommand() { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                else
                    return Ok();


            }
            catch (Exception ex)
            {

                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }
    }
}
