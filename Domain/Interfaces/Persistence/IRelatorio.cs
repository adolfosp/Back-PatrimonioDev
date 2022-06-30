using Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IRelatorio
    {
        Task<List<PerdaDto>> ObterPerdas();
    }
}
