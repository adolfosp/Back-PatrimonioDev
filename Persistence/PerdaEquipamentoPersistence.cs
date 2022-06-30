using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class PerdaEquipamentoPersistence : IPerdaEquipamentoPersistence
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PerdaEquipamentoPersistence(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> DeletarPercaEquipamento(int codigoPercaEquipamento)
        {
            var percaEquipamento = await _context.PercaEquipamento.Where(x => x.CodigoPerda == codigoPercaEquipamento).FirstOrDefaultAsync();

            if (percaEquipamento == null) return 404;

            _context.PercaEquipamento.Remove(percaEquipamento);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<PerdaEquipamento> CriarPerdaEquipamento(PerdaEquipamentoDto percaEquipamentoDto)
        {
            var percaEquipamento = _mapper.Map<PerdaEquipamento>(percaEquipamentoDto);

            _context.PercaEquipamento.Add(percaEquipamento);

            await _context.SaveChangesAsync();

            return percaEquipamento;
        }

        public async Task<PerdaEquipamento> ObterPercaPorId(int codigoPercaEquipamento)
        {
            var percaEquipamento = await _context.PercaEquipamento.Where(x => x.CodigoPerda == codigoPercaEquipamento).Select(x => x).FirstOrDefaultAsync();

            if (percaEquipamento is null) return null;

            return percaEquipamento;
        }

        public async Task<int> AtualizarPercaEquipamento(int codigoPercaEquipamento, PerdaEquipamentoDto percaEquipamentoDto)
        {
            var percaEquipamento = await _context.PercaEquipamento.Where(x => x.CodigoPerda == codigoPercaEquipamento).Select(x => x).FirstOrDefaultAsync();

            if (percaEquipamento is null) return 404;

            _mapper.Map(percaEquipamentoDto, percaEquipamento);

            await _context.SaveChangesAsync();

            return 200;
        }
    }
}
