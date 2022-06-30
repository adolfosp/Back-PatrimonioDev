using Domain.Dtos;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EstatisticaFeature.Queries
{
    public class ObterEstatisticaCategoria: IRequest<IEnumerable<EstatisticaCategoriaDto>>
    {

        public class ObterEstatisticaCategoriaHandler : IRequestHandler<ObterEstatisticaCategoria, IEnumerable<EstatisticaCategoriaDto>>
        {

            private readonly IEstatisticaPersistence _repository;
            public ObterEstatisticaCategoriaHandler(IEstatisticaPersistence repository)
                => _repository = repository;

            public async Task<IEnumerable<EstatisticaCategoriaDto>> Handle(ObterEstatisticaCategoria request, CancellationToken cancellationToken)
                => await _repository.ObterEstatisticaCategoria();
        }
    }
}
