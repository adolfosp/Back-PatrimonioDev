using Aplicacao.Interfaces;
using System;
using System.Linq;

namespace Domain.Helpers.Empresa
{
    public class EmpresaPadraoHelper
    {

        private readonly IApplicationDbContext _context;

        public EmpresaPadraoHelper(IApplicationDbContext context)
            => _context = context;


        public (int StatusCode, string NomeFantasia) ObterRetornoParaEmpresaPadrao(int codigoEmpresaDaOperacao)
        {
            var nomeFantasia =  _context.Empresa.Where(x => x.EmpresaPadraoImpressao && x.CodigoEmpresa != codigoEmpresaDaOperacao).
                                                          Select(x => x.NomeFantasia).
                                                          FirstOrDefault();
            if (!String.IsNullOrEmpty(nomeFantasia))
                return (400, nomeFantasia);

            return (0, "");
        }


    }
}
