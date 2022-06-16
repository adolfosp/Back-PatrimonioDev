using Domain.Dtos;
using Domain.Dtos.Estatisticas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IEstatisticaPersistence
    {
        Task<List<EstatisticaCategoriaDto>> ObterEstatisticaCategoria();
        Task<List<EstatisticaMediaEquipamentoDto>> ObterMediaEquipamentoPorFuncionario();
        Task<List<EstatisticaPatrimonioDisponivelDto>> ObterPatrimonioDisponivel();
        Task<EstatisticaQuantidadeMovimentacao> ObterQuantidadeMovimentacao();

    }
}
