using Domain.Entidades;
using System.Threading.Tasks;
using Aplicacao.Dtos;
using System.Collections.Generic;

namespace Domain.Interfaces.Persistence
{
    public interface IPatrimonioPersistence
    {
        Task<int> DeletarPatrimonio(int codigoPatrimonio);
        Task<Patrimonio> CriarPatrimonio(PatrimonioDto patrimonio, InformacaoAdicionalDto informacaoAdicionalDto);
        Task<Patrimonio> ObterPatrimonioPorId(int codigoPatrimonio);
        Task<int> AtualizarPatrimonio(int codigoPatrimonio, PatrimonioDto patrimonioDto, InformacaoAdicionalDto informacaoAdicionalDto);
        Task<IEnumerable<PatrimonioDto>> ObterTodosPatrimonio();
    }
}
