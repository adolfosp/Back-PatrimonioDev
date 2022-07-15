using Aplicacao.Dtos;
using AutoMapper;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PatrimonioFeature.Commands
{
    public class AtualizarPatrimonioCommand : IRequest<int>
    {
        public int CodigoPatrimonio { get; set; }

        public PatrimonioDto PatrimonioDto { get; set; }
        public InformacaoAdicionalDto InformacaoAdicionalDto { get; set; }

        public class AtualizarPatrimonioCommandHandler: IRequestHandler<AtualizarPatrimonioCommand,int>
        {
            private readonly IPatrimonioPersistence _persistence;

            public AtualizarPatrimonioCommandHandler(IPatrimonioPersistence persistence)
            {
                _persistence = persistence;
            }

            public Task<int> Handle(AtualizarPatrimonioCommand request, CancellationToken cancellationToken)
                => _persistence.AtualizarPatrimonio(request.CodigoPatrimonio, request.PatrimonioDto, request.InformacaoAdicionalDto);
            
        }
    }
}
