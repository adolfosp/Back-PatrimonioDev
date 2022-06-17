using Aplicacao.Interfaces.Persistence;
using Dapper;
using Domain.Dtos;
using Domain.Dtos.Estatisticas;
using Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public class EstatisticaPersistence : IEstatisticaPersistence
    {

        private readonly DapperContext _context;

        public EstatisticaPersistence(DapperContext context)
           => _context = context;

        public async Task<IEnumerable<EstatisticaCategoriaDto>> ObterEstatisticaCategoria()
        {
            var query = "SELECT C.Descricao AS NomeCategoria, Count(E.Codigotipoequipamento) AS QuantidadeEquipamento FROM CategoriaEquipamento AS C INNER JOIN Equipamento AS E ON E.Codigocategoria = C.Codigocategoria GROUP BY C.Descricao";

            using (var connection = _context.CreateConnection())
                return await connection.QueryAsync<EstatisticaCategoriaDto>(query);

        }

        public async Task<IEnumerable<EstatisticaMediaEquipamentoDto>> ObterMediaEquipamentoPorFuncionario()
        {

            var query = "SELECT Sum(quantidadeequipamentoporfuncionario) AS QuantidadeTotalDeEquipamento, Count(codigofuncionario) AS QuantidadeTotalFuncionario FROM(SELECT Count(f.codigofuncionario) AS QuantidadeEquipamentoPorFuncionario , f.codigofuncionario FROM patrimonio AS p LEFT JOIN funcionario AS f ON f.codigofuncionario = p.codigofuncionario LEFT JOIN equipamento AS eq ON eq.codigotipoequipamento = p.codigotipoequipamento LEFT JOIN percaequipamento AS perca ON perca.codigopatrimonio = p.codigopatrimonio WHERE perca.codigopatrimonio IS NULL GROUP BY f.codigofuncionario, f.nomefuncionario) grp ";

            using (var connection = _context.CreateConnection())
                return await connection.QueryAsync<EstatisticaMediaEquipamentoDto>(query);
        }

        public async Task<IEnumerable<EstatisticaPatrimonioDisponivelDto>> ObterPatrimonioDisponivel()
        {
            var query = "WITH CTE_Patrimonios AS( SELECT COUNT(P.CodigoPatrimonio) AS QuantidadePatrimonioDisponivel FROM Patrimonio AS P LEFT JOIN PercaEquipamento AS PE ON PE.CodigoPatrimonio = P.CodigoPatrimonio WHERE P.SituacaoEquipamento = 2 AND PE.CodigoPatrimonio IS NULL GROUP BY P.CodigoPatrimonio) SELECT Sum(QuantidadePatrimonioDisponivel) AS QuantidadePatrimonioDisponivel, COALESCE(OT.QuantidadeTotalPatrimonio,1) AS QuantidadeTotalPatrimonio FROM CTE_Patrimonios AS CTO FULL JOIN( SELECT Count(p.CodigoPatrimonio) AS QuantidadeTotalPatrimonio FROM Patrimonio AS p LEFT JOIN PercaEquipamento AS eq on eq.CodigoPatrimonio = p.CodigoPatrimonio WHERE eq.CodigoPatrimonio IS NULL ) AS OT ON OT.QuantidadeTotalPatrimonio != CTO.QuantidadePatrimonioDisponivel GROUP BY QuantidadePatrimonioDisponivel, OT.QuantidadeTotalPatrimonio ";

            using (var connection = _context.CreateConnection())
                return await connection.QueryAsync<EstatisticaPatrimonioDisponivelDto>(query);

        }

        public async Task<EstatisticaQuantidadeMovimentacao> ObterQuantidadeMovimentacao()
        {
            var query = "SELECT COUNT(CodigoMovimentacao) AS QuantidadeMovimentacao FROM MovimentacaoEquipamento AS me LEFT JOIN PercaEquipamento AS pe ON PE.CodigoPatrimonio = ME.CodigoPatrimonio WHERE PE.CodigoPatrimonio IS NULL";

            using (var connection = _context.CreateConnection())
                return await connection.QueryFirstOrDefaultAsync<EstatisticaQuantidadeMovimentacao>(query);
        }
    }
}
