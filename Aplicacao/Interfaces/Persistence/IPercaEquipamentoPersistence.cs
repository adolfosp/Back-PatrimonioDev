using Aplicacao.Dtos;
using Domain.Entidades;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IPercaEquipamentoPersistence
    {
        Task<int> DeletarPercaEquipamento(int codigoPercaEquipamento);
        Task<PercaEquipamento> CriarPercaEquipamento(PercaEquipamentoDto percaEquipamentoDto);
        Task<PercaEquipamento> ObterPercaPorId(int codigoPercaEquipamento);
        Task<int> AtualizarPercaEquipamento(int codigoPercaEquipamento, PercaEquipamentoDto percaEquipamentoDto);

    }
}
