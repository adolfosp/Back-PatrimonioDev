using Aplicacao.Features.UsuarioFeature.Commands;
using Aplicacao.Features.UsuarioFeature.Queries;
using Microsoft.AspNetCore.Mvc;
using PatrimonioDev.Helpers;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class UsuarioController : BaseApiController
    {
        [HttpPost("/usuario")]
        public async Task<IActionResult> CriarUsuario(CriarUsuarioCommand command)
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


        [HttpGet("/usuario/{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {
            try
            {
                var usuario = await Mediator.Send(new ObterApenasUm { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(usuario));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }

        [HttpGet("/usuario/[action]")]
        public async Task<IActionResult> ObterUsuarioPorLogin(string email, string senha)
        {
            try
            {
                var usuario = await Mediator.Send(new ObterUsuarioPorLogin { senha = senha, email = email });

                return StatusCode(HTTPStatus.RetornaStatus(usuario));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }


        [HttpGet("/usuario")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var usuario = await Mediator.Send(new ObterTodosUsuarios());

                return StatusCode(HTTPStatus.RetornaStatus(usuario));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }

        }

        [HttpDelete("/usuario/{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new RemoverUsuarioCommand { Id = id }));

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

        [HttpPut("/usuario/[action]")]
        public async Task<IActionResult> AtualizarUsuario(AtualizarUsuarioCommand command)
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

