using Aplicacao.Interfaces;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia
{
    public class SetorPersistence : ISetorPersistence
    {
        private readonly IApplicationDbContext _context;

        public SetorPersistence(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Setor> Adicionar(Setor setor)
        {

            _context.Setor.Add(setor);

            await _context.SaveChangesAsync();

            return setor;

        }

        public async Task<int> Atualizar(Setor setor, int codigoSetor)
        {
            var setorExiste = await _context.Setor.Where(x => x.CodigoSetor == codigoSetor).Select(x => x)
                                                  .AsNoTrackingWithIdentityResolution()
                                                  .FirstOrDefaultAsync() is not null;

            if (!setorExiste) return 404;

            setor.CodigoSetor = codigoSetor;

            _context.Setor.Update(setor);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<Setor> ObterPorCodigoSetor(int codigoSetor)
        {
            var setor = await _context.Setor.Where(x => x.CodigoSetor == codigoSetor)
                                            .AsNoTrackingWithIdentityResolution()
                                            .FirstOrDefaultAsync();
            if (setor == null) return null;

            return setor;
        }

        public async Task<IEnumerable<Setor>> ObterTodosSetores()
        {
            var listaSetor = await _context.Setor.ToListAsync();

            if (listaSetor == null) return null;

            return listaSetor.AsReadOnly();
        }


        public async Task<int> Remover(int codigoSetor)
        {
            var setor = await _context.Setor.Where(x => x.CodigoSetor == codigoSetor)
                                            .AsNoTrackingWithIdentityResolution()
                                            .FirstOrDefaultAsync();

            if (setor == null) return 404;

            _context.Setor.Remove(setor);

            await _context.SaveChangesAsync();

            return 200;

        }
    }
}
