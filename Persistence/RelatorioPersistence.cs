using Aplicacao.Interfaces;
using Domain.Dtos;
using Domain.Interfaces.Persistence;
using Persistence.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public class RelatorioPersistence : IRelatorio
    {
        private readonly IApplicationDbContext _context;
        public RelatorioPersistence(IApplicationDbContext context)
            => _context = context;

        public async Task<List<PerdaDto>> ObterPerdas()
        {
            _context.OpenConnection();

            using var command = _context.CreateCommand();

            command.CommandText = "SELECT pe.CodigoPerda, e.TipoEquipamento, pe.MotivoDaPerda, f.NomeFuncionario, u.Nome AS NomeUsuario FROM PercaEquipamento AS pe Inner join Patrimonio AS p ON p.codigopatrimonio = pe.CodigoPatrimonio inner join Equipamento AS e ON e.CodigoTipoEquipamento = p.CodigoTipoEquipamento inner join Funcionario AS f ON f.CodigoFuncionario = p.CodigoFuncionario inner join Usuario AS u ON u.CodigoUsuario = p.CodigoUsuario";

            using var result = await command.ExecuteReaderAsync();

            return DataReaderMapToList.DataReaderToList<PerdaDto>(result);
        }
    }
}
