using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class MovimentacaoEquipamentoPersistence : IMovimentacaoEquipamentoPersistence
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MovimentacaoEquipamentoPersistence(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AtualizarMovimentacaoEquipamento(int codigoMovimentacao, MovimentacaoEquipamentoDto movimentacaoEquipamentoDto)
        {
            var movimentacao = await _context.MovimentacaoEquipamento.Where(x => x.CodigoMovimentacao == codigoMovimentacao).Select(x => x).FirstOrDefaultAsync();

            if (movimentacao is null) return 404;

            _mapper.Map(movimentacaoEquipamentoDto, movimentacao);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<MovimentacaoEquipamento> CriarMovimentacaoEquipamento(MovimentacaoEquipamentoDto movimentacaoEquipamentoDto)
        {
            var movimentacaoEquipamento = _mapper.Map<MovimentacaoEquipamento>(movimentacaoEquipamentoDto);

            _context.MovimentacaoEquipamento.Add(movimentacaoEquipamento);

            await _context.SaveChangesAsync();

            return movimentacaoEquipamento;
        }

        public async Task<IEnumerable<MovimentacaoEquipamento>> ObterTodasAsMovimentacoesPorCodigoPatrimonio(int codigoPatrimonio)
        {
            var movimentacoesDeEquipamentos = await _context.MovimentacaoEquipamento.Where(x => x.CodigoPatrimonio == codigoPatrimonio).Select(x => x).ToListAsync();

            return movimentacoesDeEquipamentos;
        }
    }
}
