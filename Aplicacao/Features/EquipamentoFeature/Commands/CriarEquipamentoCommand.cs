using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EquipamentoFeature.Commands
{
    public class CriarEquipamentoCommand : IRequest<Equipamento>
    {
        public EquipamentoDto Equipamento  { get; set; }

        public class CriarEquipamentoCommandHandler : IRequestHandler<CriarEquipamentoCommand, Equipamento>
        {
            private readonly IEquipamentoPersistence _persistence;
            private readonly IMapper _mapper;

            public CriarEquipamentoCommandHandler(IEquipamentoPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            }
               

            public Task<Equipamento> Handle(CriarEquipamentoCommand request, CancellationToken cancellationToken)
                => _persistence.CriarEquipamento(request.Equipamento);
        }
    }
}
