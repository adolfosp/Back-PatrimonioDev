using Aplicacao.Dtos;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EquipamentoFeature.Commands
{
    public class CriarEquipamentoCommand : IRequest<Equipamento>
    {
        public EquipamentoDto EquipamentoDto  { get; set; }

        public class CriarEquipamentoCommandHandler : IRequestHandler<CriarEquipamentoCommand, Equipamento>
        {
            private readonly IEquipamentoPersistence _persistence;

            public CriarEquipamentoCommandHandler(IEquipamentoPersistence persistence)
                => _persistence = persistence;
            
            public Task<Equipamento> Handle(CriarEquipamentoCommand request, CancellationToken cancellationToken)
                => _persistence.CriarEquipamento(request.EquipamentoDto);
        }
    }
}
