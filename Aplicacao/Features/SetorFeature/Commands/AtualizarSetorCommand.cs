using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.SetorFeature.Commands
{
    public class AtualizarSetorCommand : IRequest<int>
    {
        public int CodigoSetor { get; set; }
        public SetorDto SetorDto { get; set; }


        public class AtualizarSetorCommandHandler : IRequestHandler<AtualizarSetorCommand, int>
        {
            private readonly ISetorPersistence _persistence;
            private readonly IMapper _mapper;

            public AtualizarSetorCommandHandler(ISetorPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            }
               

            public async Task<int> Handle(AtualizarSetorCommand command, CancellationToken cancellationToken)
            {
                var setor = _mapper.Map<Setor>(command.SetorDto);
                return await _persistence.Atualizar(setor, command.CodigoSetor);
            }
        }
    }
}
