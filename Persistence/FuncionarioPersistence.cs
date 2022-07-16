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

        public async Task<int> Atualizar(int codigoFuncionario, FuncionarioDto funcionarioDto)
        {
            var funcionario = await _context.Funcionario.Where(x => x.CodigoFuncionario == codigoFuncionario).Select(x => x).FirstOrDefaultAsync();

            if (funcionario is null) return 404;

            _mapper.Map(funcionarioDto, funcionario);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<Funcionario> Adicionar(Funcionario funcionario)
        {
            funcionario.Ativo = true;

            _context.Funcionario.Add(funcionario);

            await _context.SaveChangesAsync();

            return funcionario;
        }

        public async Task<int> Desativar(int codigoFuncionario)
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

        public async Task<IEnumerable<Funcionario>> ObterTodos()
        {
            var funcionario = await _context.Funcionario.Where(x => x.Ativo).ToListAsync();

            if (funcionario is null) return null;

            return funcionario.AsReadOnly();
        }
    }
}
