using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FuncionarioPersistence : IFuncionarioPersistence
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FuncionarioPersistence(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AtualizarFuncionario(int codigoFuncionario, FuncionarioDto funcionarioDto)
        {
            var funcionario = await _context.Funcionario.Where(x => x.CodigoFuncionario == codigoFuncionario).Select(x => x).FirstOrDefaultAsync();

            if (funcionario is null) return 404;

            _mapper.Map(funcionarioDto, funcionario);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<Funcionario> CriarFuncionario(FuncionarioDto funcionario)
        {
            funcionario.Ativo = true;

            var funcionarioDominio = _mapper.Map<Funcionario>(funcionario);

            _context.Funcionario.Add(funcionarioDominio);

            await _context.SaveChangesAsync();

            return funcionarioDominio;
        }

        public async Task<int> DesativarFuncionario(int codigoFuncionario)
        {
            var funcionario = await _context.Funcionario.Where(x => x.CodigoFuncionario == codigoFuncionario).Select(x => x).FirstOrDefaultAsync();

            if (funcionario is null) return 404;

            funcionario.Ativo = false;

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<Funcionario> ObterFuncionarioPorId(int codigoFuncionario)
        {
            var funcionario = await _context.Funcionario.Where(x => x.CodigoFuncionario == codigoFuncionario && x.Ativo).Select(x => x).FirstOrDefaultAsync();

            if (funcionario is null) return null;

            return funcionario;
        }

        public async Task<IEnumerable<Funcionario>> ObterTodosFuncionarios()
        {
            var funcionario = await _context.Funcionario.Where(x => x.Ativo).ToListAsync();

            if (funcionario is null) return null;

            return funcionario.AsReadOnly();
        }
    }
}
