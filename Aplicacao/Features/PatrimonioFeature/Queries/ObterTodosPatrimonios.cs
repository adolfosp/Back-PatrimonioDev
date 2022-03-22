using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PatrimonioFeature.Queries
{
    public class ObterTodosPatrimonios: IRequest<IEnumerable<PatrimonioDto>>
    {
        public class ObterTodosPatrimoniosHandler : IRequestHandler<ObterTodosPatrimonios, IEnumerable<PatrimonioDto>>
        {
            private IPatrimonioPersistence _persistence;

            public ObterTodosPatrimoniosHandler(IPatrimonioPersistence persistence)
                => _persistence = persistence;

            public Task<IEnumerable<PatrimonioDto>> Handle(ObterTodosPatrimonios request, CancellationToken cancellationToken)
                => _persistence.ObterTodosPatrimonio();
               
        }
    }
}
