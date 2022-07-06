using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.InformacaoAdicionalFeature.Queries
{
    public class ObterInformacaoAdicionalPorId : IRequest<InformacaoAdicional>
    {
        public int CodigoInformacaoAdicional { get; set; }

        public class ObterInformacaoAdicionalPorIdHandler : IRequestHandler<ObterInformacaoAdicionalPorId, InformacaoAdicional>
        {

            private readonly IInformacaoAdicionalPersistence _persistence;

            public ObterInformacaoAdicionalPorIdHandler(IInformacaoAdicionalPersistence persistence)
                => _persistence = persistence;

            public async Task<InformacaoAdicional> Handle(ObterInformacaoAdicionalPorId request, CancellationToken cancellationToken)
                => await _persistence.ObterPorCodigoInformacao(request.CodigoInformacaoAdicional);
        }
    }
}
