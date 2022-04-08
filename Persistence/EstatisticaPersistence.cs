using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using Domain.Dtos;
using Persistence.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public class EstatisticaPersistence : IEstatisticaPersistence
    {

        private readonly IApplicationDbContext _context;

        public EstatisticaPersistence(IApplicationDbContext context)    
           => _context = context;     

        public async Task<List<EstatisticaCategoriaDto>> ObterEstatisticaCategoria()
        {
            _context.OpenConnection();

            using var command = _context.CreateCommand();

            command.CommandText = "SELECT C.Descricao AS NomeCategoria, Count(E.Codigotipoequipamento) AS QuantidadeEquipamento FROM CategoriaEquipamento AS C INNER JOIN Equipamento AS E ON E.Codigocategoria = C.Codigocategoria GROUP BY C.Descricao ";
     
            using var result = await command.ExecuteReaderAsync();

            return DataReaderMapToList.DataReaderToList<EstatisticaCategoriaDto>(result);

        }

        public async Task<List<EstatisticaMediaEquipamentoDto>> ObterMediaEquipamentoPorFuncionario()
        {
            _context.OpenConnection();

            using var command = _context.CreateCommand();

            command.CommandText = "SELECT Sum(quantidadeequipamentoporfuncionario) AS QuantidadeTotalDeEquipamento, Count(codigofuncionario) AS QuantidadeTotalFuncionario FROM(SELECT Count(f.codigofuncionario) AS QuantidadeEquipamentoPorFuncionario , f.codigofuncionario FROM patrimonio AS p LEFT JOIN funcionario AS f ON f.codigofuncionario = p.codigofuncionario LEFT JOIN equipamento AS eq ON eq.codigotipoequipamento = p.codigotipoequipamento LEFT JOIN percaequipamento AS perca ON perca.codigopatrimonio = p.codigopatrimonio WHERE perca.codigopatrimonio IS NULL GROUP BY f.codigofuncionario, f.nomefuncionario) grp ";

            using var result = await command.ExecuteReaderAsync();

            return DataReaderMapToList.DataReaderToList<EstatisticaMediaEquipamentoDto>(result);
        }
    }
}
