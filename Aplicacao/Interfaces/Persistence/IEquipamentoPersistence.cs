using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IEquipamentoPersistence
    {
        Task<int> DeletarEquipamento(int codigoEquipamento);
        Task<Equipamento> CriarEquipamento(Equipamento equipamento);
        Task<IEnumerable<Equipamento>> ObterTodosEquipamentos();
        Task<Equipamento> ObterEquipamentoPorId();


    }
}
