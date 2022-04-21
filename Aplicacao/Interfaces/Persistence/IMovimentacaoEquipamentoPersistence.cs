using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao.Dtos;
using Domain.Entidades;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IMovimentacaoEquipamentoPersistence
    {
        Task<int> AtualizarMovimentacaoEquipamento(int codigoMovimentacao, MovimentacaoEquipamentoDto movimentacaoEquipamentoDto);
        Task<MovimentacaoEquipamento> CriarMovimentacaoEquipamento(MovimentacaoEquipamento movimentacaoEquipamentoDto);
        Task<IEnumerable<MovimentacaoEquipamentoDto>> ObterTodasAsMovimentacoesPorCodigoPatrimonio(int codigoPatrimonio);
        Task<MovimentacaoEquipamentoDto> ObterApenasUmaMovimentacao(int codigoMovimentacao);

    }
}
