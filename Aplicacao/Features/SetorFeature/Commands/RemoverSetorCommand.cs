using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.SetorFeature.Commands
{
    public class RemoverSetorCommand : IRequest<int>
    {
        public int CodigoSetor { get; set; }

        public class DeletarSetorCommandHandler : IRequestHandler<RemoverSetorCommand, int>
        {
            private readonly ISetorPersistence _persistence;

            public DeletarSetorCommandHandler(ISetorPersistence persistence)
                => _persistence = persistence;

            public async Task<int> Handle(RemoverSetorCommand command, CancellationToken cancellationToken)
                => await _persistence.Remover(command.CodigoSetor);
        }
    }
}
