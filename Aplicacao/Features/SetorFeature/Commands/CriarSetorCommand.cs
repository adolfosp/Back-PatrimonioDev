using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.SetorFeature.Commands
{
    public class CriarSetorCommand : IRequest<Setor>
    {
        public SetorDto SetorDto { get; set; }

        public class CriarSetorCommandHandler : IRequestHandler<CriarSetorCommand, Setor>
        {
            private readonly ISetorPersistence _persistence;
            private readonly IMapper _mapper;

            public CriarSetorCommandHandler(ISetorPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            }
                
            public async Task<Setor> Handle(CriarSetorCommand command, CancellationToken cancellationToken)
            {
                var novoSetor = _mapper.Map<Setor>(command.SetorDto);
                return await _persistence.Adicionar(novoSetor);
            }
        }
    }
}
