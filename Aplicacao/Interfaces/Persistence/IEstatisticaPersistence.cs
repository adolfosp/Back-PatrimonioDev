using Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IEstatisticaPersistence
    {
        Task<List<EstatisticaCategoriaDto>> ObterEstatisticaCategoria();
        Task<List<EstatisticaMediaEquipamentoDto>> ObterMediaEquipamentoPorFuncionario();
    }
}
