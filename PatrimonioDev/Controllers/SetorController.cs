﻿using Aplicacao.Features.SetorFeature.Commands;
using Aplicacao.Features.SetorFeature.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class SetorController : BaseApiController
    {
        [HttpPost("/setor")]
        public async Task<IActionResult> CriarSetor(CriarSetorCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }


        [HttpGet("/setor/{id}")]
        public async Task<IActionResult> ObterApenasUm(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new ObterApenasUmSetor { Id = id }));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }


        [HttpGet("/setor")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                return Ok(await Mediator.Send(new ObterTodosSetores()));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }

        }

        [HttpDelete("/setor/{id}")]
        public async Task<IActionResult> DeletarSetor(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarSetorCommand { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                else
                    return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [HttpPut("/setor/[action]")]
        public async Task<IActionResult> AtualizarSetor(AtualizarSetorCommand command)
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
                return StatusCode(500, $"Erro interno no servidor. Mensagem: {ex.Message}");
            }
        }
    }
}
