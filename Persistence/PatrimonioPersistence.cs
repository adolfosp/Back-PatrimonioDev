﻿using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using AutoMapper;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class PatrimonioPersistence : IPatrimonioPersistence
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PatrimonioPersistence(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AtualizarPatrimonio(int codigoPatrimonio, PatrimonioDto patrimonioDto)
        {
            var patrimonio = await _context.Patrimonio.Where(x => x.CodigoPatrimonio == codigoPatrimonio).Select(x => x).FirstOrDefaultAsync();

            if (patrimonio is null) return 404;

            _mapper.Map(patrimonioDto, patrimonio);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<Patrimonio> CriarPatrimonio(PatrimonioDto patrimonio)
        {
            var patrimonioDominio = _mapper.Map<Patrimonio>(patrimonio);

            _context.Patrimonio.Add(patrimonioDominio);

            await _context.SaveChangesAsync();

            return patrimonioDominio;
        }

        public async Task<int> DeletarPatrimonio(int codigoPatrimonio)
        {
            var patrimonio = await _context.Patrimonio.Where(x => x.CodigoPatrimonio == codigoPatrimonio).FirstOrDefaultAsync();

            if (patrimonio == null) return 404;

            _context.Patrimonio.Remove(patrimonio);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<Patrimonio> ObterPatrimonioPorId(int codigoPatrimonio)
        {
            var patrimonio = await _context.Patrimonio.Where(x => x.CodigoPatrimonio == codigoPatrimonio).Select(x => x).FirstOrDefaultAsync();

            if (patrimonio is null) return null;

            return patrimonio;
        }

        public async Task<IEnumerable<PatrimonioDto>> ObterTodosPatrimonio()
        {

            return  await (from p in _context.Patrimonio
                    join e in _context.Equipamento on p.CodigoTipoEquipamento equals e.CodigoTipoEquipamento
                    join f in _context.Funcionario on p.CodigoFuncionario equals f.CodigoFuncionario
                    select new PatrimonioDto() {
                        NomeFuncionario = f.NomeFuncionario,
                        TipoEquipamento = e.TipoEquipamento,
                        Modelo = p.Modelo,
                        CodigoPatrimonio = p.CodigoPatrimonio,
                        SituacaoEquipamento = p.SituacaoEquipamento
                    }).ToListAsync();
        }
    }
}
