using Aplicacao.Features.UsuarioFeature.Commands;
using Aplicacao.Features.UsuarioFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Microsoft.AspNetCore.Http;

namespace PatrimonioDev.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : BaseApiController
    {

        /// <summary>
        /// Método para criar um usuário
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/usuario")]
        public async Task<IActionResult> CriarUsuario(CriarUsuarioCommand command)
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
        /// Método para buscar um usuário específico
        /// </summary>
        /// <param name="id"> Id para buscar o usuário específico</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/usuario/{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {
            try
            {
                var usuario = await Mediator.Send(new ObterApenasUm { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(usuario), usuario);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        /// <summary>
        /// Método para buscar um usuário por email e senha 
        /// </summary>
        /// <param name="email"> E-mail do usuário</param>
        /// <param name="senha"> Senha do usuário</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/usuario/[action]")]
        public async Task<IActionResult> ObterUsuarioPorLogin(string email, string senha)
        {
            try
            {
                var usuario = await Mediator.Send(new ObterUsuarioPorLogin { senha = senha, email = email });

                return StatusCode(HTTPStatus.RetornaStatus(usuario), usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        /// <summary>
        /// Método para buscar todos os usuário 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/usuario")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var usuario = await Mediator.Send(new ObterTodosUsuarios());

                return StatusCode(HTTPStatus.RetornaStatus(usuario), usuario);

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }

        }

        /// <summary>
        /// Método para buscar todos os usuário 
        /// </summary>
        /// <param name="id"> Id para deletar o usuário específico</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/usuario/{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new RemoverUsuarioCommand { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        /// <summary>
        /// Método para atualizar o usuário específico 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("/usuario/[action]")]
        public async Task<IActionResult> AtualizarUsuario(AtualizarUsuarioCommand command)
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
    }
}

