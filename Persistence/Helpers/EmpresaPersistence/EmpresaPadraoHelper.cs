using Aplicacao.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Helpers.Empresa
{
    public class EmpresaPadraoHelper
    {

        private readonly IApplicationDbContext _context;

        public EmpresaPadraoHelper(IApplicationDbContext context)
            => _context = context;


        public async Task<(int StatusCode, string NomeFantasia)> ObterRetornoParaEmpresaPadrao(int codigoEmpresaDaOperacao)
        {
            var nomeFantasia =  await _context.Empresa.Where(x => x.EmpresaPadraoImpressao == true && x.CodigoEmpresa != codigoEmpresaDaOperacao).
                                                          Select(x => x.NomeFantasia).
                                                          FirstOrDefaultAsync();
            if (!String.IsNullOrEmpty(nomeFantasia))
                return (400, nomeFantasia);

            return (0,"");
        }
    }
}
