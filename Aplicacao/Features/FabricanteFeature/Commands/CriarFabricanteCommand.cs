using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FabricanteFeature.Commands
{
    public class CriarFabricanteCommand : IRequest<Fabricante>
    {
        public FabricanteDto FabricanteDto { get; set; }

        public class CriarFabricanteHandler : IRequestHandler<CriarFabricanteCommand, Fabricante>

        {
            private readonly IFabricantePersistence _persistence;
            private readonly IMapper _mapper;

            public CriarFabricanteHandler(IFabricantePersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;

            }

            public async Task<Fabricante> Handle(CriarFabricanteCommand command, CancellationToken cancellationToken)
            {
                var fabricante = _mapper.Map<Fabricante>(command.FabricanteDto);

                return await _persistence.Adicionar(fabricante);
            }
        }
    }
}
