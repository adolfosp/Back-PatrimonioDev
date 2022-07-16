using Aplicacao.Dtos;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTests.TestesIntegracao.Repositories
{
    public class FuncionarioRepositoryFake : IFuncionarioPersistence
    {
        public Task<int> Atualizar(int codigoFuncionario, FuncionarioDto funcionario)
        {
            return Task.FromResult<int>(200);
        }

        public Task<Funcionario> Adicionar(Funcionario funcionario)
        {
            return Task.FromResult<Funcionario>(new Funcionario());
        }

        public Task<int> Desativar(int codigoFuncionario)
        {
            return Task.FromResult<int>(200);
        }

        public Task<Funcionario> ObterFuncionarioPorId(int codigoFuncionario)
        {
            return Task.FromResult<Funcionario>(new Funcionario());
        }

        public Task<IEnumerable<Funcionario>> ObterTodos()
        {
            return Task.FromResult<IEnumerable<Funcionario>>(new List<Funcionario>());
        }
    }
}
