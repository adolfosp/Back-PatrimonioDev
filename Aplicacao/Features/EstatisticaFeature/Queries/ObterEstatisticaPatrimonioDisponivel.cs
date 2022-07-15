using Domain.Dtos;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EstatisticaFeature.Queries
{
    public class ObterEstatisticaPatrimonioDisponivel: IRequest<IEnumerable<EstatisticaPatrimonioDisponivelDto>>
    {
        public class ObterEstatisticaPatrimonioDisponivelHandler : IRequestHandler<ObterEstatisticaPatrimonioDisponivel, IEnumerable<EstatisticaPatrimonioDisponivelDto>>
        {
            private readonly IEstatisticaPersistence _context;
            public ObterEstatisticaPatrimonioDisponivelHandler(IEstatisticaPersistence context)
                => _context = context;

            public async Task<IEnumerable<EstatisticaPatrimonioDisponivelDto>> Handle(ObterEstatisticaPatrimonioDisponivel request, CancellationToken cancellationToken)
                => await _context.ObterPatrimonioDisponivel();
      
        }
    }
}
