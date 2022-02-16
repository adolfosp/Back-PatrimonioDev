using Aplicacao.Features.UsuarioFeature.Commands;
using Aplicacao.Features.UsuarioFeature.Queries;
using Domain.Entidades;
using Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : BaseApiController
    {


        [SwaggerOperation(Summary = "Método para criar um usuário")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Produces("application/json")]
        [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioCommand command)
        {
            try
            {
                var usuario = await ObterUsuarioPorEmail(command.Usuario.Email);

                if (usuario)
                    return StatusCode(500, new { mensagem = $"Não é possível realizar o cadastro pois o e-mail já foi utilizado em outro registro." });

                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Erro interno no servidor. Mensagem:  {ex.Message} {ex.InnerException}" });
            }
        }

        [NonAction]
        public async Task<bool> ObterUsuarioPorEmail(string email)
             => await Mediator.Send(new ObterUsuarioPorEmail { Email = email });


        [SwaggerOperation(Summary = "Método para buscar um usuário específico")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
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

        [SwaggerOperation(Summary = "Método para buscar um usuário por email e senha ")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpGet("{email}/{senha}")]
        public async Task<IActionResult> ObterUsuarioPorLogin(string email, string senha)
        {
            try
            {
                var usuario = await Mediator.Send(new ObterUsuarioPorLogin { senha = senha, email = email });

                if (usuario is null)
                    return StatusCode(400, new { mensagem = "Não foi encontrado usuário com as credencias informadas" });

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345!"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptios = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new[] {
                        new Claim(ClaimTypes.Name,usuario.Nome),
                        new Claim(ClaimTypes.Role,usuario.CodigoUsuarioPermissao.ToString())
                    },
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials);;

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptios);


                usuario.Token = tokenString;

                return StatusCode(HTTPStatus.RetornaStatus(usuario), usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }


        [SwaggerOperation(Summary = "Método para buscar todos os usuário")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpGet]
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

        [SwaggerOperation(Summary = "Método para buscar todos os usuário ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
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

        [SwaggerOperation(Summary = "Método para atualizar o usuário específico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpPut("{codigoFuncionario}")]
        public async Task<IActionResult> AtualizarUsuario(int codigoFuncionario, [FromBody] AtualizarUsuarioCommand command)
        {
            try
            {
                command.Id = codigoFuncionario;

                var statusCode = StatusCode(await Mediator.Send(command));

                if (statusCode.StatusCode == 404)
                    return NotFound("Nenhum registro encontrado!");

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.Message} {ex.InnerException}");
            }
        }
    }
}

