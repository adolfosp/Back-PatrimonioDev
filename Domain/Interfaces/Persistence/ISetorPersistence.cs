using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface ISetorPersistence
    {
        Task<int> Atualizar(Setor setor, int codigoSetor);
        Task<Setor> Adicionar(Setor setor);
        Task<int> Remover(int codigoSetor);

        Task<Setor> ObterPorCodigoSetor(int codigoSetor);
        Task<IEnumerable<Setor>> ObterTodosSetores();

    }
}
