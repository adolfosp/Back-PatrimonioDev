﻿using Aplicacao.Features.SetorFeature.Commands;
using Aplicacao.Features.SetorFeature.Queries;
using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Domain.Enums;

namespace PatrimonioDev.Controllers
{
    [Route("api/setores")]
    public class SetorController : BaseApiController
    {

        [SwaggerOperation(Summary = "Método para criar setor")]
        [ProducesResponseType(typeof(Setor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> CriarSetor([FromBody]CriarSetorCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para buscar setor específico")]
        [ProducesResponseType(typeof(Setor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {
            try
            {
                var setor = await Mediator.Send(new ObterApenasUmSetor { Id = id });

                return StatusCode(HTTPStatus.RetornaStatus(setor), setor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

 
        [SwaggerOperation(Summary = "Método para buscar todos os setores")]
        [ProducesResponseType(typeof(Setor), StatusCodes.Status200OK)]
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
                var setor = await Mediator.Send(new ObterTodosSetores());

                return StatusCode(HTTPStatus.RetornaStatus(setor), setor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }

        }


        [SwaggerOperation(Summary = "Método para deletar um setor específico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarSetor(int id)
        {
            try
            {
                if (TratamentoRegistroSistema.EhRegistroPadraoSistema(EntidadesRegistroPadrao.Setor, id))
                    return BadRequest(new { mensagem = "Não é possível realizar essa operação com registro padrão." });

                var statusCode = StatusCode(await Mediator.Send(new DeletarSetorCommand { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound(new { mensagem = "Não foi encontrado registro para excluir" });

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }

        [SwaggerOperation(Summary = "Método para atualizar um setor específico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "1")]
        [HttpPut("{codigoSetor}")]
        public async Task<IActionResult> AtualizarSetor(int codigoSetor, [FromBody]AtualizarSetorCommand command)
        {
            try
            {
                if (TratamentoRegistroSistema.EhRegistroPadraoSistema(EntidadesRegistroPadrao.Setor, codigoSetor))
                    return BadRequest(new { mensagem = "Não é possível realizar essa operação com registro padrão." });

                command.Id = codigoSetor;

                var statusCode = StatusCode(await Mediator.Send(command));

                if (statusCode.StatusCode == 404)
                    return NotFound("Nenhum registro encontrado!");

                return Ok();


            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {ex.Message}{ex.InnerException}" });
            }
        }
    }
}
