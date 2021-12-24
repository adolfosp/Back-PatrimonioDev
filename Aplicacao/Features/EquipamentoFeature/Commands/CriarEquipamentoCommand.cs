using Aplicacao.Dtos;
using Domain.Entidades;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Aplicacao.Interfaces.Persistence;
using AutoMapper;

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
            {
                var equipamento = _mapper.Map<Equipamento>(request.Equipamento);

                return _persistence.CriarEquipamento(equipamento);
            }
                
        }
    }
}
