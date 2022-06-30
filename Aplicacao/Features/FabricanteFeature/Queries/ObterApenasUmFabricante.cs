using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FabricanteFeature.Queries
{
    public class ObterApenasUmFabricante : IRequest<Fabricante>
    {
        public int CodigoFabricante { get; set; }

        public class ObterApenasUmFabricanteHandler : IRequestHandler<ObterApenasUmFabricante, Fabricante>
        {
            private readonly IFabricantePersistence _persistence;

            public ObterApenasUmFabricanteHandler(IFabricantePersistence persistence)
                => _persistence = persistence;

            public async Task<Fabricante> Handle(ObterApenasUmFabricante request, CancellationToken cancellationToken)
                => await _persistence.ObterUm(request.CodigoFabricante);
        }
    }
}
