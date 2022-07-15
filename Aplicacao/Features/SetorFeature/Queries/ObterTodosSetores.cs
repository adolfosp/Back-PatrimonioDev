using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.SetorFeature.Queries
{
    public class ObterTodosSetores : IRequest<IEnumerable<Setor>>
    {
        public class ObterTodosSetoresQueryHandler : IRequestHandler<ObterTodosSetores, IEnumerable<Setor>>
        {
            private readonly ISetorPersistence _persistence;

            public ObterTodosSetoresQueryHandler(ISetorPersistence persistence)
                => _persistence = persistence;

            public async Task<IEnumerable<Setor>> Handle(ObterTodosSetores request, CancellationToken cancellationToken)
                => await _persistence.ObterTodosSetores();
        }
    }
}
