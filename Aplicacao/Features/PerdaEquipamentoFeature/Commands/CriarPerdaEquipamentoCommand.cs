using Aplicacao.Dtos;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PercaEquipamentoFeature.Commands
{
    public class CriarPerdaEquipamentoCommand : IRequest<PerdaEquipamento>
    {
        public PerdaEquipamentoDto PerdaEquipamento { get; set; }

        public class CriarPercaEquipamentoCommandHandler: IRequestHandler<CriarPerdaEquipamentoCommand, PerdaEquipamento>
        {
            private readonly IPerdaEquipamentoPersistence _persistence;

            public CriarPercaEquipamentoCommandHandler(IPerdaEquipamentoPersistence persistence)
                => _persistence = persistence;


            public Task<PerdaEquipamento> Handle(CriarPerdaEquipamentoCommand request,
                CancellationToken cancellationToken)
                => _persistence.CriarPerdaEquipamento(request.PerdaEquipamento);
        }
    }
}
