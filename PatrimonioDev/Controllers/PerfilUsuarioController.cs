using Aplicacao.Features.PerfilUsuarioFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    [Route("api/[controller]")]
    public class PerfilUsuarioController: BaseApiController
    {

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
    }
}
