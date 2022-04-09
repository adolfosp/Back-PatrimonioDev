using Aplicacao.Interfaces.Persistence;
using Domain.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EstatisticaFeature.Queries
{
    public class ObterEstatisticaPatrimonioDisponivel: IRequest<List<EstatisticaPatrimonioDisponivelDto>>
    {
        public class ObterEstatisticaPatrimonioDisponivelHandler : IRequestHandler<ObterEstatisticaPatrimonioDisponivel, List<EstatisticaPatrimonioDisponivelDto>>
        {
            private readonly IEstatisticaPersistence _context;
            public ObterEstatisticaPatrimonioDisponivelHandler(IEstatisticaPersistence context)
                => _context = context;

            public async Task<List<EstatisticaPatrimonioDisponivelDto>> Handle(ObterEstatisticaPatrimonioDisponivel request, CancellationToken cancellationToken)
                => await _context.ObterPatrimonioDisponivel();

          
        }
    }
}
