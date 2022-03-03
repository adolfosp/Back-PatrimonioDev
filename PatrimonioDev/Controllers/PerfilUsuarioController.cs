using Aplicacao.Features.PerfilUsuarioFeature;
using Aplicacao.Features.PerfilUsuarioFeature.Commands;
using Aplicacao.Features.PerfilUsuarioFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    [Route("api/[controller]")]
    public class PerfilUsuarioController: BaseApiController
    {
        private readonly IWebHostEnvironment _host;

        public PerfilUsuarioController(IWebHostEnvironment host)
        {
           _host = host;
        }

        [SwaggerOperation(Summary = "Método para obter perfil do usuário")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize]
        [HttpGet("{codigoUsuario}")]
        public async Task<IActionResult> ObterInformacoesPerfil(int codigoUsuario)
        {
            try
            {
                var perfil = await Mediator.Send(new ObterPerfilUsuario { CodigoUsuario = codigoUsuario });

                return StatusCode(HTTPStatus.RetornaStatus(perfil), perfil);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [SwaggerOperation(Summary = "Método para alterar perfil do usuário")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> AlterarPerfilUsuario([FromBody]AtualizarPerfilCommand command)
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
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [SwaggerOperation(Summary = "Método para subir uma imagem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize]
        [HttpPost("upload-imagem/{codigoUsuario}")]
        public async Task<IActionResult> InserirImagem(int codigoUsuario)
        {
            try
            {
                var usuario = await Mediator.Send(new ObterPerfilUsuario { CodigoUsuario = codigoUsuario });


                if (usuario is null) return NoContent();

                var file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    DeletarImagem(usuario.ImagemUrl);

                    usuario.ImagemUrl = await SalvarImagem(file);
                }

                var novoUsuario = new AtualizarPerfilCommand();
                novoUsuario.Perfil = usuario;

                var usuarioRetorno = await AlterarPerfilUsuario(novoUsuario);


                return Ok(usuarioRetorno);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Erro interno no servidor. Mensagem:  {ex.Message} {ex.InnerException}" });
            }
        }

        [NonAction]
        private async Task<string> SalvarImagem(IFormFile imagemFile)
        {

            string nomeImagem = new String(Path.GetFileNameWithoutExtension(imagemFile.FileName)
                                            .Take(10)
                                            .ToArray())
                                            .Replace(" ", "-");

            nomeImagem = $"{nomeImagem}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imagemFile.FileName)}";

            var imagePath = Path.Combine(_host.ContentRootPath, @"Resources/Imagens", nomeImagem);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imagemFile.CopyToAsync(fileStream);
            }

            return nomeImagem;
        }

        [NonAction]
        private void DeletarImagem(string imagemUrl)
        {
            if (imagemUrl is null) return;

            var imagemPath = Path.Combine(_host.ContentRootPath, @"Resources/Imagens", imagemUrl);

            if (System.IO.File.Exists(imagemPath))
            {
                System.IO.File.Delete(imagemPath);
            }
        }
    }
}
