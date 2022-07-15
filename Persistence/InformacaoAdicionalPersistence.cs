using Aplicacao.Interfaces;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia
{
    public class InformacaoAdicionalPersistence : IInformacaoAdicionalPersistence
    {
        private readonly IApplicationDbContext _context;

        public InformacaoAdicionalPersistence(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InformacaoAdicional> Adicionar(InformacaoAdicional informacaoAdicional)
        {
            await _context.InformacaoAdicional.AddAsync(informacaoAdicional);

            await _context.SaveChangesAsync();

            return informacaoAdicional;
        }

        public async Task<int> Atualizar(InformacaoAdicional informacaoAdicionalAtualiza, int codigoInformacaoAdicional)
        {
            var informacaoAdicional = await _context.InformacaoAdicional.Where(x => x.CodigoInformacao == codigoInformacaoAdicional)
                                                                        .AsNoTrackingWithIdentityResolution()
                                                                        .FirstOrDefaultAsync();

            if (informacaoAdicional == null) return 404;

            informacaoAdicionalAtualiza.CodigoInformacao = informacaoAdicional.CodigoInformacao;

            _context.InformacaoAdicional.Update(informacaoAdicionalAtualiza);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<InformacaoAdicional> ObterPorCodigoInformacao(int codigoInformacaoAdicional)
        {
            var informacaoAdicional = await _context.InformacaoAdicional.Where(x => x.CodigoPatrimonio == codigoInformacaoAdicional).FirstOrDefaultAsync();

            if (informacaoAdicional == null)
                return null;

            return informacaoAdicional;
        }

        public async Task<int> Remover(int codigoInformacaoAdicional)
        {
            var informacaoAdicional = await _context.InformacaoAdicional.Where(x => x.CodigoInformacao == codigoInformacaoAdicional).FirstOrDefaultAsync();

            if (informacaoAdicional == null) return 404;

            _context.InformacaoAdicional.Remove(informacaoAdicional);

            await _context.SaveChangesAsync();

            return 200;
        }
    }
}
