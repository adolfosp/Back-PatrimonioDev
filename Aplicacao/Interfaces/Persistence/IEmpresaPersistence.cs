using Aplicacao.Dtos;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IEmpresaPersistence
    {
        Task<(int CodigoStatus, string NomeEmpresa)> AtualizarEmpresa(int codigoEmpresa, EmpresaDto empresa);

    }
}
