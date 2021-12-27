using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PercaEquipamentoFeature.Commands
{
    public class AtualizarPercaEquipamentoCommand : IRequest<int>
    {
        public int Id { get; set; }
        public PercaEquipamentoDto PercaEquipamentoDto { get; set; }

        public class AtualizarPercaEquipamentoCommandHandler : IRequestHandler<AtualizarPercaEquipamentoCommand, int>
        {
            private readonly IPercaEquipamentoPersistence _persistence;

            public AtualizarPercaEquipamentoCommandHandler(IPercaEquipamentoPersistence persistence)
                => _persistence = persistence;


            public Task<int> Handle(AtualizarPercaEquipamentoCommand request, CancellationToken cancellationToken)
                => _persistence.AtualizarPercaEquipamento(request.Id, request.PercaEquipamentoDto);
        }
    }
}
