using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FabricanteFeature.Queries
{
    public class ObterTodosFabricantes : IRequest<IEnumerable<Fabricante>>
    {
        public class ObterTodosFabricantesHanlder : IRequestHandler<ObterTodosFabricantes, IEnumerable<Fabricante>>
        {
            private readonly IFabricantePersistence _persistence;

            public ObterTodosFabricantesHanlder(IFabricantePersistence persistence)
                => _persistence = persistence;

            public async Task<IEnumerable<Fabricante>> Handle(ObterTodosFabricantes request, CancellationToken cancellationToken)
                => await _persistence.ObterTodos();
        }
    }
}
