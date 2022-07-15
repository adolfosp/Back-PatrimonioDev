using Domain.Dtos.Estatisticas;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EstatisticaFeature.Queries
{
    public class ObterQuantidadeMovimentacao: IRequest<EstatisticaQuantidadeMovimentacao>
    {
        public class ObterQuantidadeMovimentacaoHandler : IRequestHandler<ObterQuantidadeMovimentacao, EstatisticaQuantidadeMovimentacao>
        {
            private readonly IEstatisticaPersistence _context;
            public ObterQuantidadeMovimentacaoHandler(IEstatisticaPersistence context)
                => _context = context;

            public Task<EstatisticaQuantidadeMovimentacao> Handle(ObterQuantidadeMovimentacao request, CancellationToken cancellationToken)
                => _context.ObterQuantidadeMovimentacao();
        }
    }
}
