using Aplicacao.Features.EstatisticaFeature.Queries;
using Domain.Dtos;
using Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    [Route("api/estatisticas")]
    public class EstatisticaController : BaseApiController
    {


        [SwaggerOperation(Summary = "Método para obter resultados da quantidade de equipamento por categoria")]
        [ProducesResponseType(typeof(EstatisticaCategoriaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ObterTodasCategorias()
        {
            try
            {
                var categorias = await Mediator.Send(new ObterEstatisticaCategoria());

                return StatusCode(HTTPStatus.RetornaStatus(categorias), categorias);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para obter resultados da quantidade media de equipamentos por funcionário")]
        [ProducesResponseType(typeof(EstatisticaCategoriaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("media")]
        public async Task<IActionResult> ObterMediaEquipamentosPorFuncionario()
        {
            try
            {
                var categorias = await Mediator.Send(new ObterMediaEquipamentoPorFuncionario());

                return StatusCode(HTTPStatus.RetornaStatus(categorias), categorias);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }
    }
}

