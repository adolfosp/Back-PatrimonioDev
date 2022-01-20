using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface ICategoriaPersistence
    {
        Task<IEnumerable<CategoriaEquipamento>> ObterTodasCategorias();
        Task<CategoriaEquipamento> CriarCategoria(CategoriaEquipamento categoria);

    }
}
