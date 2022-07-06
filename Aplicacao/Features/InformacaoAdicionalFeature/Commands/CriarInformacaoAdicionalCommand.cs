using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.InformacaoAdicionalFeature.Commands
{
    public class CriarInformacaoAdicionalCommand : IRequest<InformacaoAdicional>
    {
        public InformacaoAdicionalDto InformacaoAdicionalDto { get; set; }

        public class CriarInformacaoCommandHandler : IRequestHandler<CriarInformacaoAdicionalCommand, InformacaoAdicional>
        {

            private readonly IInformacaoAdicionalPersistence _persistence;
            private readonly IMapper _mapper;

            public CriarInformacaoCommandHandler(IInformacaoAdicionalPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            }

            public async Task<InformacaoAdicional> Handle(CriarInformacaoAdicionalCommand request, CancellationToken cancellationToken)
            {
                InformacaoAdicional informacaoAdicional = _mapper.Map<InformacaoAdicional>(request.InformacaoAdicionalDto);

                return await _persistence.Adicionar(informacaoAdicional);
            }
        }
    }
}
