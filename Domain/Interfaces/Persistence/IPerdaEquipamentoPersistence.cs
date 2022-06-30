using Aplicacao.Dtos;
using Domain.Entidades;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IPerdaEquipamentoPersistence
    {
        Task<int> DeletarPercaEquipamento(int codigoPercaEquipamento);
        Task<PerdaEquipamento> CriarPerdaEquipamento(PerdaEquipamentoDto percaEquipamentoDto);
        Task<PerdaEquipamento> ObterPercaPorId(int codigoPercaEquipamento);
        Task<int> AtualizarPercaEquipamento(int codigoPercaEquipamento, PerdaEquipamentoDto percaEquipamentoDto);

    }
}
