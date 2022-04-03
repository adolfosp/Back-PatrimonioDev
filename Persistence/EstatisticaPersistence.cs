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
    }
}
