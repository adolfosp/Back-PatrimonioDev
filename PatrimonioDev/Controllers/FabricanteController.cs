using Aplicacao.Features.FabricanteFeature.Commands;
using Aplicacao.Features.FabricanteFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class FabricanteController : BaseApiController
    {
        [HttpPost("/fabricante")]
        public async Task<IActionResult> CriarFabricante(CriarFabricanteCommand command)
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

        [HttpGet("/fabricante")]
        public async Task<IActionResult> ListarTodosFabricantes()
        {
            try
            {
                var fabricante = await Mediator.Send(new ObterTodosFabricantes());

                return StatusCode(HTTPStatus.RetornaStatus(fabricante));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }

        [HttpGet("/fabricante/{id}")]
        public async Task<IActionResult> ListarFabricantePorId(int id)
        {
            try
            {
                var fabricante = await Mediator.Send(new ObterApenasUmFabricante { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(fabricante));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }

        [HttpPut("/fabricante/[action]")]
        public async Task<IActionResult> AtualizarFabricante(AtualizarFabricanteCommand command)
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

        [HttpDelete("/fabricante/{id}")]
        public async Task<IActionResult> DeletarTipoEquipamento(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarFabricanteCommand() { Id = id }));

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
