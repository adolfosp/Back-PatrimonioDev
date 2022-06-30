using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EquipamentoFeature.Commands
{
    public class DeletarEquipamentoCommand : IRequest<int>
    {
        public int CodigoEquipamento { get; set; }

        public class DeletarEquipamentoCommandHandler : IRequestHandler<DeletarEquipamentoCommand, int>
        {
            private readonly IEquipamentoPersistence _persistence;

            public DeletarEquipamentoCommandHandler(IEquipamentoPersistence persistence)
                => _persistence = persistence;

            public Task<int> Handle(DeletarEquipamentoCommand request, CancellationToken cancellationToken)
                => _persistence.DeletarEquipamento(request.CodigoEquipamento);
        }
    }
}
