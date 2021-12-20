﻿using Aplicacao.Features.EmpresaFeature.Commands;
using Aplicacao.Features.EmpresaFeature.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Controllers
{
    public class EmpresaController : BaseApiController
    {

        [Route("/empresa")]
        [HttpPost]
        public async Task<IActionResult> CriarEmpresa(CriarEmpresaCommand command)
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

        [Route("/empresa")]
        [HttpGet]
        public async Task<IActionResult> ListarTodasEmpresas()
        {
            try
            {
                return Ok(await Mediator.Send(new ObterTodasEmpresas()));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [HttpGet("/empresa/{id}")]
        public async Task<IActionResult> ListarEmpresaPorId(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new ObterApenasUmaEmpresa { Id = id }));

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar a operação! Mensagem: {ex.Message}");
            }
        }

        [HttpPut("/empresa/[action]")]
        public async Task<IActionResult> AtualizarEmpresa(AtualizarEmpresaCommand command)
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

        [HttpDelete("/empresa/{id}")]
        public async Task<IActionResult> DeletarTipoEquipamento(int id)
        {
            try
            {
                var statusCode = StatusCode(await Mediator.Send(new DeletarEmpresaCommand() { Id = id }));

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
    }
}
