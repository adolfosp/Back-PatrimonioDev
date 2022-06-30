using Aplicacao.Interfaces;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class CategoriaPersistence : ICategoriaPersistence
    {
        private readonly IApplicationDbContext _context;

        public CategoriaPersistence(IApplicationDbContext context)
            => _context = context;

        public async Task<int> AtualizarCategoriaEquipamento(int codigoCategoria, CategoriaEquipamento categoria)
        {
            var categoriaEquipamento = await _context.CategoriaEquipamento.Where(x => x.CodigoCategoria == codigoCategoria).Select(x => x).FirstOrDefaultAsync();

            if (categoriaEquipamento is null) return 404;

            categoriaEquipamento.Descricao = categoria.Descricao;

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<CategoriaEquipamento> CriarCategoria(CategoriaEquipamento categoria)
        {
            await _context.CategoriaEquipamento.AddAsync(categoria);

            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<int> DeletarCategoria(int codigoCategoria)
        {
            //TODO: VALIDAR RETORNO PARA ACTIONRESULT
            var categoria = await _context.CategoriaEquipamento.Where(x => x.CodigoCategoria == codigoCategoria).FirstOrDefaultAsync();

            if (categoria is null) return 404;

            _context.CategoriaEquipamento.Remove(categoria);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<CategoriaEquipamento> ObterApenasUmaCategoria(int codigoCategoria)
        {
            var categoria = await _context.CategoriaEquipamento.Where(x => x.CodigoCategoria == codigoCategoria).Select(x => x).FirstOrDefaultAsync();

            if (categoria is null) return null;

            return categoria;
        }

        public async Task<IEnumerable<CategoriaEquipamento>> ObterTodasCategorias()
        {
            var categoria = await _context.CategoriaEquipamento.ToListAsync();

            if (categoria == null) return null;

            return categoria.AsReadOnly();
        }
    }
}
