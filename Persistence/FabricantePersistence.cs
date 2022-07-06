using Aplicacao.Interfaces;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FabricantePersistence : IFabricantePersistence
    {
        private readonly IApplicationDbContext _context;

        public FabricantePersistence(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Fabricante> Adicionar(Fabricante fabricante)
        {
            await _context.Fabricante.AddAsync(fabricante);

            await _context.SaveChangesAsync();

            return fabricante;
        }

        public async Task<int> Atualizar(int codigoFabricante, Fabricante fabricante)
        {
            var fabricanteAtualizacao = await _context.Fabricante.Where(x => x.CodigoFabricante == codigoFabricante)
                                                                 .AsNoTrackingWithIdentityResolution()                                        
                                                                 .FirstOrDefaultAsync();

            if (fabricanteAtualizacao == null) return 404;

            fabricante.CodigoFabricante = fabricanteAtualizacao.CodigoFabricante;

            _context.Fabricante.Update(fabricante);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<IEnumerable<Fabricante>> ObterTodos()
        {
            var listaDeFabricantes = await _context.Fabricante.ToListAsync();

            if (listaDeFabricantes == null)
                return null;

            return listaDeFabricantes.AsReadOnly();
        }

        public async Task<Fabricante> ObterUm(int codigoFabricante)
        {
            var listaDeFabricantes = await _context.Fabricante.Where(x => x.CodigoFabricante == codigoFabricante)
                                                              .FirstOrDefaultAsync();

            if (listaDeFabricantes == null)
                return null;

            return listaDeFabricantes;
        }

        public async Task<int> Remover(int codigoFabricante)
        {
            var fabricante = await _context.Fabricante.Where(x => x.CodigoFabricante == codigoFabricante)
                                                      .AsNoTrackingWithIdentityResolution()
                                                      .FirstOrDefaultAsync();

            if (fabricante == null) return 404;

            _context.Fabricante.Remove(fabricante);

            await _context.SaveChangesAsync();

            return 200;
        }
    }
}
