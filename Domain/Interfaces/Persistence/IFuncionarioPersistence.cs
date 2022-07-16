using Aplicacao.Dtos;
using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IFuncionarioPersistence
    {
        Task<int> Desativar(int codigoFuncionario);
        Task<Funcionario> Adicionar(Funcionario funcionario);
        Task<IEnumerable<Funcionario>> ObterTodos();
        Task<Funcionario> ObterFuncionarioPorId(int codigoFuncionario);
        Task<int> Atualizar(int codigoFuncionario, FuncionarioDto funcionario);
    }
}
