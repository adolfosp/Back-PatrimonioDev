using Aplicacao.Dtos;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PatrimonioFeature.Commands
{
    public class CriarPatrimonioCommand : IRequest<Patrimonio>
    {
        public PatrimonioDto PatrimonioDto { get; set; }
        public InformacaoAdicionalDto InformacaoAdicionalDto { get; set; }

        public class CriarPatrimonioCommandHandler : IRequestHandler<CriarPatrimonioCommand, Patrimonio>
        {
            private readonly IPatrimonioPersistence _persistence;

            public CriarPatrimonioCommandHandler(IPatrimonioPersistence persistence)
                => _persistence = persistence;

            public Task<Patrimonio> Handle(CriarPatrimonioCommand request, CancellationToken cancellationToken)
                => _persistence.CriarPatrimonio(request.PatrimonioDto, request.InformacaoAdicionalDto);
        }
    }
}
