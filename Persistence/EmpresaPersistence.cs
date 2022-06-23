using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using Domain.Helpers.Empresa;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class EmpresaPersistence : IEmpresaPersistence
    {

        private readonly IApplicationDbContext _context;

        public EmpresaPersistence(IApplicationDbContext context)
            => _context = context;

        public async Task<(int CodigoStatus, string NomeEmpresa)> Adicionar(Empresa empresa)
        {

            if (empresa.EmpresaPadraoImpressao)
            {

                EmpresaPadraoHelper empresaHelper = new(_context);

                var retorno = empresaHelper.ObterRetornoParaEmpresaPadrao(empresa.CodigoEmpresa);

                if (retorno.StatusCode != 0)
                    return retorno;

            }

            await _context.Empresa.AddAsync(empresa);

            await _context.SaveChangesAsync();

            return (200, "");
        }

        public async Task<(int CodigoStatus, string NomeEmpresa)> Atualizar(int codigoEmpresa, Empresa empresa)
        {

            var empresaAtualizar = await _context.Empresa.Where(x => x.CodigoEmpresa == codigoEmpresa).AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync();

            if (empresaAtualizar == null) return (404, "");

            if (empresa.EmpresaPadraoImpressao)
            {

                EmpresaPadraoHelper empresaHelper = new(_context);

                var retorno = empresaHelper.ObterRetornoParaEmpresaPadrao(codigoEmpresa);

                if (retorno.StatusCode != 0)
                    return retorno;

            }

            empresa.CodigoEmpresa = codigoEmpresa;

            _context.Empresa.Update(empresa);

            await _context.SaveChangesAsync();

            return (200, "");
        }
    }
}
