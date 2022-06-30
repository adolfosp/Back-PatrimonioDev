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
        public PatrimonioDto Patrimonio { get; set; }
        public InformacaoAdicionalDto InformacaoAdicional { get; set; }

        public class CriarPatrimonioCommandHandler : IRequestHandler<CriarPatrimonioCommand, Patrimonio>
        {
            private readonly IPatrimonioPersistence _persistence;

            public CriarPatrimonioCommandHandler(IPatrimonioPersistence persistence)
                => _persistence = persistence;

            public Task<Patrimonio> Handle(CriarPatrimonioCommand request, CancellationToken cancellationToken)
                => _persistence.CriarPatrimonio(request.Patrimonio, request.InformacaoAdicional);
        }
    }
}
