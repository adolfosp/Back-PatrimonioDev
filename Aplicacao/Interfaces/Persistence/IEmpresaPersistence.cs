using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IEmpresaPersistence
    {
        Task<(int CodigoStatus, string NomeEmpresa)> Atualizar(int codigoEmpresa, Empresa empresa);
        Task<(int CodigoStatus, string NomeEmpresa)> Adicionar(Empresa empresa);
        Task<int> Remover(int codigoEmpresa);

        Task<Empresa> ObterUma(int codigoEmpresa);
        Task<string> ObterEmpresaPadrao();
        Task<IEnumerable<Empresa>> ObterTodas();

    }
}
