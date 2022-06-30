using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FabricanteFeature.Commands
{
    public class DeletarFabricanteCommand : IRequest<int>
    {
        public int CodigoFabricante { get; set; }

        public class DeletarFabricanteHandler : IRequestHandler<DeletarFabricanteCommand, int>
        {
            private readonly IFabricantePersistence _persistence;

            public DeletarFabricanteHandler(IFabricantePersistence persistence)
                => _persistence = persistence;

            public async Task<int> Handle(DeletarFabricanteCommand command, CancellationToken cancellationToken)
                => await _persistence.Remover(command.CodigoFabricante);
        }
    }
}
