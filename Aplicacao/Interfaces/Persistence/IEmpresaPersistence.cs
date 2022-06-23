using Aplicacao.Dtos;
using Domain.Entidades;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IEmpresaPersistence
    {
        Task<(int CodigoStatus, string NomeEmpresa)> Atualizar(int codigoEmpresa, Empresa empresa);
        Task<(int CodigoStatus, string NomeEmpresa)> Adicionar(Empresa empresa);

    }
}
