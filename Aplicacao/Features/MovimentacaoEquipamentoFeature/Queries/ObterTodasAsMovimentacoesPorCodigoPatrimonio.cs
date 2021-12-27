using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.MovimentacaoEquipamentoFeature.Queries
{
    public class ObterTodasAsMovimentacoesPorCodigoPatrimonio: IRequest<IEnumerable<MovimentacaoEquipamento>>
    {
        public int Id { get; set; }

        public class ObterTodasAsMovimentacoesPorCodigoPatrimonioHandler:
            IRequestHandler<ObterTodasAsMovimentacoesPorCodigoPatrimonio, IEnumerable<MovimentacaoEquipamento>>
        {
            private readonly IMovimentacaoEquipamentoPersistence _persistence;

            public ObterTodasAsMovimentacoesPorCodigoPatrimonioHandler(IMovimentacaoEquipamentoPersistence persistence)
                => _persistence = persistence;

            public Task<IEnumerable<MovimentacaoEquipamento>> Handle(
                ObterTodasAsMovimentacoesPorCodigoPatrimonio request, CancellationToken cancellationToken)
                => _persistence.ObterTodasAsMovimentacoesPorCodigoPatrimonio(request.Id);
        }
    }
}
