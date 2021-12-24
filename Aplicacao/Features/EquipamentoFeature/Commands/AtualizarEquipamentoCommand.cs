using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EquipamentoFeature.Commands
{
    public class AtualizarEquipamentoCommand : IRequest<int>
    {
        public int Id { get; set; }
        public EquipamentoDto EquipamentoDto { get; set; }

        public class AtualizarEquipamentoCommandHandler : IRequestHandler<AtualizarEquipamentoCommand, int>
        {
            private readonly IEquipamentoPersistence _persistence;

            public AtualizarEquipamentoCommandHandler(IEquipamentoPersistence persistence)
                => _persistence = persistence;

            public Task<int> Handle(AtualizarEquipamentoCommand request, CancellationToken cancellationToken)
                => _persistence.AtualizarEquipamento(request.Id, request.EquipamentoDto);
        }
    }
}
