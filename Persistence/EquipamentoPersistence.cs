using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class EquipamentoPersistence : IEquipamentoPersistence
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EquipamentoPersistence(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Equipamento> CriarEquipamento(EquipamentoDto equipamento)
        {
            var equipamentoDominio = _mapper.Map<Equipamento>(equipamento);
            _context.Equipamento.Add(equipamentoDominio);

            await _context.SaveChangesAsync();

            return equipamentoDominio;
        }

        public async Task<int> DeletarEquipamento(int codigoEquipamento)
        {
            var equipamento = await _context.Equipamento.Where(x => x.CodigoTipoEquipamento == codigoEquipamento).FirstOrDefaultAsync();

            if (equipamento == null) return 404;

            _context.Equipamento.Remove(equipamento);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<Equipamento> ObterEquipamentoPorId(int codigoEquipamento)
        {
            var equipamento = await _context.Equipamento.Where(x => x.CodigoTipoEquipamento == codigoEquipamento).Select(x => x).FirstOrDefaultAsync();

            if (equipamento is null) return null;

            return equipamento;
        }

        public async Task<int> AtualizarEquipamento(int codigoEquipamento, EquipamentoDto equipamentoDto)
        {
            var equipamento = await _context.Equipamento.Where(x => x.CodigoTipoEquipamento == codigoEquipamento ).Select(x => x).FirstOrDefaultAsync();

            if (equipamento is null) return 404;

            _mapper.Map(equipamentoDto, equipamento);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<List<EquipamentoDto>> ObterTodosEquipamentos() {

            return await (from e in _context.Equipamento
                    join f in _context.Fabricante on e.CodigoFabricante equals f.CodigoFabricante
                    join c in _context.CategoriaEquipamento on e.CodigoCategoria equals c.CodigoCategoria
                    select new EquipamentoDto
                    {
                        CodigoTipoEquipamento = e.CodigoTipoEquipamento,
                        TipoEquipamento = e.TipoEquipamento,
                        CodigoFabricante = e.CodigoFabricante,
                        CodigoCategoria = e.CodigoCategoria,
                        NomeCategoria = c.Descricao,
                        NomeFabricante = f.NomeFabricante

                    }).ToListAsync();

        }
    }
}
