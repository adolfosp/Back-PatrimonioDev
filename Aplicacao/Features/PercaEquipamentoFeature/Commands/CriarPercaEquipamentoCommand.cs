using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PercaEquipamentoFeature.Commands
{
    public class CriarPercaEquipamentoCommand : IRequest<PerdaEquipamento>
    {
        public PercaEquipamentoDto PercaDeEquipamento { get; set; }

        public class CriarPercaEquipamentoCommandHandler: IRequestHandler<CriarPercaEquipamentoCommand, PerdaEquipamento>
        {
            private readonly IPercaEquipamentoPersistence _persistence;

            public CriarPercaEquipamentoCommandHandler(IPercaEquipamentoPersistence persistence)
                => _persistence = persistence;


            public Task<PerdaEquipamento> Handle(CriarPercaEquipamentoCommand request,
                CancellationToken cancellationToken)
                => _persistence.CriarPercaEquipamento(request.PercaDeEquipamento);
        }
    }
}
