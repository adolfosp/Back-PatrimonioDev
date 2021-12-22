using Aplicacao.Features.InformacaoAdicionalFeature.Commands;
using Aplicacao.Features.InformacaoAdicionalFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class InformacaoAdicionalController : BaseApiController
    {
        [HttpPost("/info")]
        public async Task<IActionResult> CriarInformacaoAdicional(CriarInformacaoAdicionalCommand command)
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


        [HttpGet("/info/{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {
            try
            {
                var informacaoAdicional = await Mediator.Send(new ObterInformacaoAdicionalPorId { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(informacaoAdicional));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }



        [HttpDelete("/info/{id}")]
        public async Task<IActionResult> DeletarInformacaoAdicional(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new RemoverInformacaoAdicionalCommand { Id = id }));

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

        [HttpPut("/info/[action]")]
        public async Task<IActionResult> AtualizarInformacao(AtualizarInformacaoAdicionalCommand command)
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
    }
}

