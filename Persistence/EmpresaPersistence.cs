using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using Domain.Helpers.Empresa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class EmpresaPersistence : IEmpresaPersistence
    {

        private readonly IApplicationDbContext _context;

        public EmpresaPersistence(IApplicationDbContext context)
            => _context = context;


        public async Task<(int CodigoStatus, string NomeEmpresa)> AtualizarEmpresa(int codigoEmpresa, EmpresaDto empresaDto)
        {

            var empresa = await _context.Empresa.Where(x => x.CodigoEmpresa == codigoEmpresa).FirstOrDefaultAsync();

            if (empresa == null) return (404, "");

            if (empresaDto.EmpresaPadraoImpressao)
            {

                EmpresaPadraoHelper empresaHelper = new(_context);

                var retorno = await empresaHelper.ObterRetornoParaEmpresaPadrao(codigoEmpresa);

                if (retorno.StatusCode != 0)
                    return retorno;
                
            }

            //TODO: Validar situação
            empresa.CNPJ = empresaDto.CNPJ;
            empresa.NomeFantasia = empresaDto.NomeFantasia;
            empresa.RazaoSocial = empresaDto.RazaoSocial;
            empresa.EmpresaPadraoImpressao = empresaDto.EmpresaPadraoImpressao;

            await _context.SaveChangesAsync();

            return (200, "");
        }
    }
}
