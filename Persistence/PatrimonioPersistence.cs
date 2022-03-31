using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using AutoMapper;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public async Task<int> AtualizarPatrimonio(int codigoPatrimonio, PatrimonioDto patrimonioDto, InformacaoAdicionalDto informacaoAdicionalDto)
        {
            using (IDbContextTransaction transaction = await _context.BeginTransactionAsync())
            {
                try
                {
                    var patrimonio = await _context.Patrimonio.Where(x => x.CodigoPatrimonio == codigoPatrimonio).Select(x => x).FirstOrDefaultAsync();
                    var informacaoAdicional = await _context.InformacaoAdicional.Where(x => x.CodigoPatrimonio == codigoPatrimonio).Select(x => x).FirstOrDefaultAsync();

                    if (patrimonio is null) return 404;

                    _mapper.Map(patrimonioDto, patrimonio);

                    await _context.SaveChangesAsync();

                    if (informacaoAdicional is not null)
                    {
                        _mapper.Map(informacaoAdicionalDto, informacaoAdicional);

                        await _context.SaveChangesAsync();

                    }
                    await transaction.CommitAsync();

                    return 200;
                }
                catch (System.Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new System.Exception($"Não foi possível gravar o patrimônio. Mensagem: {ex.Message}");
                }
            }
        }

        public async Task<Patrimonio> CriarPatrimonio(PatrimonioDto patrimonio, InformacaoAdicionalDto informacaoAdicional)
        {

            using (IDbContextTransaction transaction = await _context.BeginTransactionAsync())
            {
                try
                {
                    var patrimonioDominio = _mapper.Map<Patrimonio>(patrimonio);
                    var informacaoDominio = _mapper.Map<InformacaoAdicional>(informacaoAdicional);

                    _context.Patrimonio.Add(patrimonioDominio);
                    await _context.SaveChangesAsync();

                    informacaoDominio.CodigoPatrimonio = patrimonioDominio.CodigoPatrimonio;
                    _context.InformacaoAdicional.Add(informacaoDominio);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return patrimonioDominio;
                }
                catch (System.Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new System.Exception($"Não foi possível gravar o patrimônio. Mensagem: {ex.Message}");
                }
            }
        }

        public async Task<int> DeletarPatrimonio(int codigoPatrimonio)
        {
            using (IDbContextTransaction transaction = await _context.BeginTransactionAsync())
            {
                try
                {

                    var informacaoAdicional = await _context.InformacaoAdicional.Where(x => x.CodigoPatrimonio == codigoPatrimonio).FirstOrDefaultAsync();

                    if (informacaoAdicional is not null)
                    {
                        _context.InformacaoAdicional.Remove(informacaoAdicional);

                        await _context.SaveChangesAsync();
                    }
                   
                    var patrimonio = await _context.Patrimonio.Where(x => x.CodigoPatrimonio == codigoPatrimonio).FirstOrDefaultAsync();

                    if (patrimonio == null) return 404;

                    _context.Patrimonio.Remove(patrimonio);

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return 200;
                }
                catch (System.Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new System.Exception($"Não foi possível gravar o patrimônio. Mensagem: {ex.Message}");
                }
            }
        }

        public async Task<Patrimonio> ObterPatrimonioPorId(int codigoPatrimonio)
        {
            var patrimonio = await _context.Patrimonio.Where(x => x.CodigoPatrimonio == codigoPatrimonio).Select(x => x).FirstOrDefaultAsync();

            if (patrimonio is null) return null;

            return patrimonio;
        }

        public async Task<IEnumerable<PatrimonioDto>> ObterTodosPatrimonio()
        {

            return await (from p in _context.Patrimonio
                          join e in _context.Equipamento on p.CodigoTipoEquipamento equals e.CodigoTipoEquipamento
                          join f in _context.Funcionario on p.CodigoFuncionario equals f.CodigoFuncionario
                          select new PatrimonioDto()
                          {
                              NomeFuncionario = f.NomeFuncionario,
                              TipoEquipamento = e.TipoEquipamento,
                              Modelo = p.Modelo,
                              CodigoPatrimonio = p.CodigoPatrimonio,
                              SituacaoEquipamento = p.SituacaoEquipamento,
                              ServiceTag = p.ServiceTag
                          }).ToListAsync();
        }
    }
}
