using Aplicacao.Interfaces.Persistence;
using Domain.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EstatisticaFeature.Queries
{
    public class ObterEstatisticaMediaEquipamentoPorFuncionario: IRequest<IEnumerable<EstatisticaMediaEquipamentoDto>>
    {
        public class ObterMediaEquipamentoPorFuncionarioHandler : IRequestHandler<ObterEstatisticaMediaEquipamentoPorFuncionario, IEnumerable<EstatisticaMediaEquipamentoDto>>
        {
            private readonly IEstatisticaPersistence _context;
            public ObterMediaEquipamentoPorFuncionarioHandler(IEstatisticaPersistence context)
                => _context = context;

            public async Task<IEnumerable<EstatisticaMediaEquipamentoDto>> Handle(ObterEstatisticaMediaEquipamentoPorFuncionario request, CancellationToken cancellationToken)
                => await _context.ObterMediaEquipamentoPorFuncionario();
        }
    }
}
