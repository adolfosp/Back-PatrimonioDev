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
    [Route("api/perfils")]
    public class PerfilUsuarioController : BaseApiController
    {
        private readonly IWebHostEnvironment _host;

        public PerfilUsuarioController(IWebHostEnvironment host)
          => _host = host;


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

            var perfil = await Mediator.Send(new ObterPerfilUsuario { CodigoUsuario = codigoUsuario });

            return StatusCode(HTTPStatusHelper.RetornaStatus(perfil), perfil);

        }

        [SwaggerOperation(Summary = "Método para alterar perfil do usuário")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> AlterarPerfilUsuario([FromBody] AtualizarPerfilCommand command)
        {
            var statusCode = StatusCode(await Mediator.Send(command));

            if (statusCode.StatusCode == 404)
                return NotFound("Nenhum registro encontrado!");

            return Ok();

        }

        [SwaggerOperation(Summary = "Método para subir uma imagem do perfil")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize]
        [HttpPost("upload-imagem/{codigoUsuario}")]
        public async Task<IActionResult> InserirImagem(int codigoUsuario)
        {

            var usuario = await Mediator.Send(new ObterPerfilUsuario { CodigoUsuario = codigoUsuario });

            if (usuario is null) return NoContent();

            var file = Request.Form.Files[0];

            if (file.Length > 0)
            {
                new ImagemUsuarioHelper(usuario.ImagemUrl, _host).ApagarImagem();

                usuario.ImagemUrl = await SalvarImagem(file);
            }

            var novoUsuario = new AtualizarPerfilCommand();
            novoUsuario.PerfilDto = usuario;

            var usuarioRetorno = await AlterarPerfilUsuario(novoUsuario);

            return Ok(usuarioRetorno);

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
    }
}
