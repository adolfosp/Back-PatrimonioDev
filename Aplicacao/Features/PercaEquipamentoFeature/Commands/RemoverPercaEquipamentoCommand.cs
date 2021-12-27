using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PercaEquipamentoFeature.Commands
{
    public class RemoverPercaEquipamentoCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class RemoverPercaEquipamentoCommandHandler : IRequestHandler<RemoverPercaEquipamentoCommand, int>
        {
            private readonly IPercaEquipamentoPersistence _persistence;

            public RemoverPercaEquipamentoCommandHandler(IPercaEquipamentoPersistence persistence)
                => _persistence = persistence;

            public Task<int> Handle(RemoverPercaEquipamentoCommand request, CancellationToken cancellationToken)
                => _persistence.DeletarPercaEquipamento(request.Id);
        }
    }
}
