using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.InformacaoAdicionalFeature.Commands
{
    public class RemoverInformacaoAdicionalCommand : IRequest<int>
    {
        public int CodigoInformacaoAdicional { get; set; }

        public class RemoverInformacaoAdicionalHandler : IRequestHandler<RemoverInformacaoAdicionalCommand, int>
        {

            private readonly IInformacaoAdicionalPersistence _persistence;

            public RemoverInformacaoAdicionalHandler(IInformacaoAdicionalPersistence persistence)
                => _persistence = persistence;

            public async Task<int> Handle(RemoverInformacaoAdicionalCommand command, CancellationToken cancellationToken)
                => await _persistence.Remover(command.CodigoInformacaoAdicional);
        }
    }
}
