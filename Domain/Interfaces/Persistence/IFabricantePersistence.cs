using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IFabricantePersistence
    {

        Task<int> Atualizar(int codigoFabricante, Fabricante fabricante);
        Task<Fabricante> Adicionar(Fabricante fabricante);
        Task<int> Remover(int codigoFabricante);

        Task<Fabricante> ObterUm(int codigoFabricante);
        Task<IEnumerable<Fabricante>> ObterTodos();

    }
}
