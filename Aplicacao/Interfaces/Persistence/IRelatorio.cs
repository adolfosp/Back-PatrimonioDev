using Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IRelatorio
    {
        Task<List<PerdaDto>> ObterPerdas();
    }
}
