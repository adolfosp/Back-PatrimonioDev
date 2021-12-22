﻿using Aplicacao.Features.UsuarioPermissaoFeature.Commands;
using Aplicacao.Features.UsuarioPermissaoFeature.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class UsuarioPermissaoController : BaseApiController
    {
        [HttpPost("/permissao")]
        public async Task<IActionResult> CriarUsuarioPermissao(CriarUsuarioPermissaoCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }

        }

        [HttpGet("/permissao")]
        public async Task<IActionResult> ObterTodasPermissoes()
        {
            try
            {
                return Ok(await Mediator.Send(new ObterTodasPermissoes()));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }


        [HttpDelete("/permissao/{id}")]
        public async Task<IActionResult> DeletarUsuarioPermissao(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarUsuarioPermissaoCommand() { Id = id }));

                if (statusCode.StatusCode == 404)
                    return NotFound("Não foi encontrado registro para deletar");

                else
                    return Ok();


            }
            catch (Exception ex)
            {

                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.InnerException}");
            }
        }
    }
}
