using Domain.Dtos;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PerdaEquipamentoFeature.Queries
{
    public class ObterTodasPerdas: IRequest<List<PerdaDto>>
    {
        public class ObterTodasPerdasHandler : IRequestHandler<ObterTodasPerdas, List<PerdaDto>>
        {
            private readonly IRelatorio _relatorio;
            public ObterTodasPerdasHandler(IRelatorio relatorio)
                => _relatorio = relatorio;

            public Task<List<PerdaDto>> Handle(ObterTodasPerdas request, CancellationToken cancellationToken)
                => _relatorio.ObterPerdas();
        }
    }
}
