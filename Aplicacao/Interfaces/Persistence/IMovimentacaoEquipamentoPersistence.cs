using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao.Dtos;
using Domain.Entidades;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IMovimentacaoEquipamentoPersistence
    {
        Task<int> AtualizarMovimentacaoEquipamento(int codigoMovimentacao, MovimentacaoEquipamentoDto movimentacaoEquipamentoDto);
        Task<MovimentacaoEquipamento> CriarMovimentacaoEquipamento(MovimentacaoEquipamentoDto movimentacaoEquipamentoDto);
        Task<IEnumerable<MovimentacaoEquipamento>> ObterTodasAsMovimentacoesPorCodigoPatrimonio(int codigoPatrimonio);
    }
}
