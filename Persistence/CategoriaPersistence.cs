using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public class CategoriaPersistence : ICategoriaPersistence
    {
        private readonly IApplicationDbContext _context;

        public CategoriaPersistence(IApplicationDbContext context)
            => _context = context;

        public async Task<CategoriaEquipamento> CriarCategoria(CategoriaEquipamento categoria)
        {
            _context.CategoriaEquipamento.Add(categoria);

            await _context.SaveChangesAsync();

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
