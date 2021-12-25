using Aplicacao.Features.EmpresaFeature.Commands;
using Aplicacao.Features.EmpresaFeature.Queries;
using Aplicacao.Features.PatrimonioFeature.Commands;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Aplicacao.Features.PatrimonioFeature.Queries;

namespace PatrimonioDev.Controllers
{
    public class PatrimonioController : BaseApiController
    {
        [HttpPost("/patrimonio")]
        public async Task<IActionResult> CriarPatrimonio(CriarPatrimonioCommand command)
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
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }

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
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.InnerException}");
            }
        }

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

                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }
    }
}
