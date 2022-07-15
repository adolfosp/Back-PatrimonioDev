using Aplicacao.Dtos;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTests.TestesIntegracao.Repositories
{
    public class FuncionarioRepositoryFake : IFuncionarioPersistence
    {
        public Task<int> AtualizarFuncionario(int codigoFuncionario, FuncionarioDto funcionario)
        {
            return Task.FromResult<int>(200);
        }

        public Task<Funcionario> CriarFuncionario(FuncionarioDto funcionario)
        {
            return Task.FromResult<Funcionario>(new Funcionario());
        }

        public Task<int> DesativarFuncionario(int codigoFuncionario)
        {
            return Task.FromResult<int>(200);
        }

        public Task<Funcionario> ObterFuncionarioPorId(int codigoFuncionario)
        {
            return Task.FromResult<Funcionario>(new Funcionario());
        }

        public Task<IEnumerable<Funcionario>> ObterTodosFuncionarios()
        {
            return Task.FromResult<IEnumerable<Funcionario>>(new List<Funcionario>());
        }
    }
}
