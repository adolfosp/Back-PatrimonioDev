using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PatrimonioFeature.Commands
{
    public class RemoverPatrimonioCommand : IRequest<int>
    {
        public int CodigoPatrimonio { get; set; }

        public class RemoverPatrimonioCommandHandler : IRequestHandler<RemoverPatrimonioCommand, int>
        {
            private readonly IPatrimonioPersistence _persistence;

            public RemoverPatrimonioCommandHandler(IPatrimonioPersistence persistence)
                => _persistence = persistence;

            public Task<int> Handle(RemoverPatrimonioCommand request, CancellationToken cancellationToken)
                => _persistence.DeletarPatrimonio(request.CodigoPatrimonio);
        }
    }
}
