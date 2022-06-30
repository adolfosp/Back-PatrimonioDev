using Domain.Dtos;
using Domain.Dtos.Estatisticas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IEstatisticaPersistence
    {
        Task<IEnumerable<EstatisticaCategoriaDto>> ObterEstatisticaCategoria();
        Task<IEnumerable<EstatisticaMediaEquipamentoDto>> ObterMediaEquipamentoPorFuncionario();
        Task<IEnumerable<EstatisticaPatrimonioDisponivelDto>> ObterPatrimonioDisponivel();
        Task<EstatisticaQuantidadeMovimentacao> ObterQuantidadeMovimentacao();

    }
}
