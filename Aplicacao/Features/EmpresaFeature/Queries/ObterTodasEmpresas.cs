using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Queries
{
    public class ObterTodasEmpresas : IRequest<IEnumerable<Empresa>>
    {

        public class ObterTodasEmpresasQueryHandler : IRequestHandler<ObterTodasEmpresas, IEnumerable<Empresa>>
        {
            private readonly IEmpresaPersistence _persistence;

            public ObterTodasEmpresasQueryHandler(IEmpresaPersistence persistence)

              => _persistence = persistence;

            public async Task<IEnumerable<Empresa>> Handle(ObterTodasEmpresas query, CancellationToken cancellationToken)
                => await _persistence.ObterTodas();
        }
    }
}
