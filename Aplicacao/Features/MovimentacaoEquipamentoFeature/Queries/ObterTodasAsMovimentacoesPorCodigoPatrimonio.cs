using Aplicacao.Dtos;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.MovimentacaoEquipamentoFeature.Queries
{
    public class ObterTodasAsMovimentacoesPorCodigoPatrimonio: IRequest<IEnumerable<MovimentacaoEquipamentoDto>>
    {
        public int CodigoPatrimonio { get; set; }

        public class ObterTodasAsMovimentacoesPorCodigoPatrimonioHandler:
            IRequestHandler<ObterTodasAsMovimentacoesPorCodigoPatrimonio, IEnumerable<MovimentacaoEquipamentoDto>>
        {
            private readonly IMovimentacaoEquipamentoPersistence _persistence;

            public ObterTodasAsMovimentacoesPorCodigoPatrimonioHandler(IMovimentacaoEquipamentoPersistence persistence)
                => _persistence = persistence;

            public Task<IEnumerable<MovimentacaoEquipamentoDto>> Handle(
                ObterTodasAsMovimentacoesPorCodigoPatrimonio request, CancellationToken cancellationToken)
                => _persistence.ObterTodasAsMovimentacoesPorCodigoPatrimonio(request.CodigoPatrimonio);
        }
    }
}
