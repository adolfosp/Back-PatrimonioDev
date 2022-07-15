using Aplicacao.Dtos;
using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IFuncionarioPersistence
    {
        Task<int> DesativarFuncionario(int codigoFuncionario);
        Task<Funcionario> CriarFuncionario(FuncionarioDto funcionario);
        Task<IEnumerable<Funcionario>> ObterTodosFuncionarios();
        Task<Funcionario> ObterFuncionarioPorId(int codigoFuncionario);
        Task<int> AtualizarFuncionario(int codigoFuncionario, FuncionarioDto funcionario);
    }
}
