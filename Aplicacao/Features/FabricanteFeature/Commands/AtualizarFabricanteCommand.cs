using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FabricanteFeature.Commands
{
    public class AtualizarFabricanteCommand : IRequest<int>
    {
        public int CodigoFabricante { get; set; }

        public FabricanteDto FabricanteDto { get; set; }

        public class AtualizarFabricanteHandler : IRequestHandler<AtualizarFabricanteCommand, int>
        {
            private readonly IFabricantePersistence _persistence;
            private readonly IMapper _mapper;

            public AtualizarFabricanteHandler(IFabricantePersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            }


            public async Task<int> Handle(AtualizarFabricanteCommand command, CancellationToken cancellationToken)
            {
                var fabricante = _mapper.Map<Fabricante>(command.FabricanteDto);

                return await _persistence.Atualizar(command.CodigoFabricante, fabricante);

            }
        }
    }
}
