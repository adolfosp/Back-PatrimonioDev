using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using AutoMapper;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class PercaEquipamentoPersistence : IPercaEquipamentoPersistence
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PercaEquipamentoPersistence(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> DeletarPercaEquipamento(int codigoPercaEquipamento)
        {
            var percaEquipamento = await _context.PercaEquipamento.Where(x => x.CodigoPerca == codigoPercaEquipamento).FirstOrDefaultAsync();

            if (percaEquipamento == null) return 404;

            _context.PercaEquipamento.Remove(percaEquipamento);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<PercaEquipamento> CriarPercaEquipamento(PercaEquipamentoDto percaEquipamentoDto)
        {
            var percaEquipamento = _mapper.Map<PercaEquipamento>(percaEquipamentoDto);

            _context.PercaEquipamento.Add(percaEquipamento);

            await _context.SaveChangesAsync();

            return percaEquipamento;
        }

        public async Task<PercaEquipamento> ObterPercaPorId(int codigoPercaEquipamento)
        {
            var percaEquipamento = await _context.PercaEquipamento.Where(x => x.CodigoPerca == codigoPercaEquipamento).Select(x => x).FirstOrDefaultAsync();

            if (percaEquipamento is null) return null;

            return percaEquipamento;
        }

        public async Task<int> AtualizarPercaEquipamento(int codigoPercaEquipamento, PercaEquipamentoDto percaEquipamentoDto)
        {
            var percaEquipamento = await _context.PercaEquipamento.Where(x => x.CodigoPerca == codigoPercaEquipamento).Select(x => x).FirstOrDefaultAsync();

            if (percaEquipamento is null) return 404;

            _mapper.Map(percaEquipamentoDto, percaEquipamento);

            await _context.SaveChangesAsync();

            return 200;
        }
    }
}
