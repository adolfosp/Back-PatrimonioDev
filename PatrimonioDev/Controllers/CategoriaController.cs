using Aplicacao.Features.CategoriaFeature.Commands;
using Aplicacao.Features.CategoriaFeature.Queries;
using Domain.Entidades;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{

    [Route("api/[controller]")]
    public class CategoriaController : BaseApiController
    {
        [SwaggerOperation(Summary = "Método para obter todas as categorias")]
        [ProducesResponseType(typeof(CategoriaEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> ObterTodasCategorias()
        {
            try
            {
                var categorias = await Mediator.Send(new ObterTodasCategorias());

                return StatusCode(HTTPStatus.RetornaStatus(categorias), categorias);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [SwaggerOperation(Summary = "Método para cadastrar categoria")]
        [ProducesResponseType(typeof(CategoriaEquipamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CriarCategoria(CriarCategoriaCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.Message} {ex.InnerException}");
            }
        }
    }
}
