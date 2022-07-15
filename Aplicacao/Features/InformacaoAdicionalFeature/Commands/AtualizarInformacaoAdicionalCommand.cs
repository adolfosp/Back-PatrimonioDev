using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.InformacaoAdicionalFeature.Commands
{
    public class AtualizarInformacaoAdicionalCommand : IRequest<int>
    {
        public int CodigoInformacaoAdicional { get; set; }

        public InformacaoAdicionalDto InformacaoAdicionalDto { get; set; }

        public class AtualizarInformacaoAdicionalHandler : IRequestHandler<AtualizarInformacaoAdicionalCommand, int>
        {
            private readonly IInformacaoAdicionalPersistence _persistence;
            private readonly IMapper _mapper;


            public AtualizarInformacaoAdicionalHandler(IInformacaoAdicionalPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            }

            public async Task<int> Handle(AtualizarInformacaoAdicionalCommand command, CancellationToken cancellationToken)
            {

                InformacaoAdicional informacaoAdicional = _mapper.Map<InformacaoAdicional>(command.InformacaoAdicionalDto);

                return await _persistence.Atualizar(informacaoAdicional, command.CodigoInformacaoAdicional);

            }
        }
    }
}
