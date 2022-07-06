using Aplicacao.Interfaces;
using Domain.Entidades;
using Domain.Helpers.Empresa;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia
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

        public async Task<string> ObterEmpresaPadrao()
        {
            var empresaPadrao = await _context.Empresa.Where(x => x.EmpresaPadraoImpressao).Select(x => x.NomeFantasia).FirstOrDefaultAsync();

            if (empresaPadrao == null)
                return string.Empty;

            return empresaPadrao;
        }

        public async Task<IEnumerable<Empresa>> ObterTodas()
        {
            var listaEmpresas = await _context.Empresa.ToListAsync();

            if (listaEmpresas == null)
            {
                return null;
            }

            return listaEmpresas.AsReadOnly();
        }

        public async Task<Empresa> ObterUma(int codigoEmpresa)
        {
            var listaEmpresa = await _context.Empresa.Where(x => x.CodigoEmpresa == codigoEmpresa).FirstOrDefaultAsync();

            if (listaEmpresa == null)
                return null;

            return listaEmpresa;
        }

        public async Task<int> Remover(int codigoEmpresa)
        {
            var empresa = await _context.Empresa.Where(x => x.CodigoEmpresa == codigoEmpresa).FirstOrDefaultAsync();

            if (empresa == null) return 404;

            _context.Empresa.Remove(empresa);

            await _context.SaveChangesAsync();

            return 200;
        }
    }
}
