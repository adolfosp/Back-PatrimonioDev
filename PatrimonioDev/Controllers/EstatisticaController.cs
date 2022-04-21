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
                var estatistica = await Mediator.Send(new ObterEstatisticaCategoria());

                return StatusCode(HTTPStatus.RetornaStatus(estatistica), estatistica);

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
                var estatistica = await Mediator.Send(new ObterEstatisticaMediaEquipamentoPorFuncionario());

                return StatusCode(HTTPStatus.RetornaStatus(estatistica), estatistica);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para obter quantidade de patrimônio disponível")]
        [ProducesResponseType(typeof(EstatisticaCategoriaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("patrimonio-disponivel")]
        public async Task<IActionResult> ObterPatrimoniosDisponivel()
        {
            try
            {
                var estatistica = await Mediator.Send(new ObterEstatisticaPatrimonioDisponivel());

                return StatusCode(HTTPStatus.RetornaStatus(estatistica), estatistica);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para obter quantidade de patrimônio disponível")]
        [ProducesResponseType(typeof(EstatisticaCategoriaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("quantidade-movimentacao")]
        public async Task<IActionResult> ObterQuantidadeDeMovimentacao()
        {
            try
            {
                var estatistica = await Mediator.Send(new ObterQuantidadeMovimentacao());

                return StatusCode(HTTPStatus.RetornaStatus(estatistica), estatistica);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }
    }
}

