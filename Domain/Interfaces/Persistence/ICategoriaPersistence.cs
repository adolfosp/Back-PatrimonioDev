using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface ICategoriaPersistence
    {
        Task<IEnumerable<CategoriaEquipamento>> ObterTodasCategorias();
        Task<CategoriaEquipamento> ObterApenasUmaCategoria(int codigoCategoria);
        Task<CategoriaEquipamento> CriarCategoria(CategoriaEquipamento categoria);
        Task<int> DeletarCategoria(int codigoCategoria);
        Task<int> AtualizarCategoriaEquipamento(int codigoCategoria, CategoriaEquipamento categoria);

    }
}
