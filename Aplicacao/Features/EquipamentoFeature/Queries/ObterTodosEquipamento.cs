using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EquipamentoFeature.Queries
{
    public class ObterTodosEquipamento : IRequest<IEnumerable<EquipamentoDto>>
    {

        public class ObterTodosEquipamentoHandler: IRequestHandler<ObterTodosEquipamento, IEnumerable<EquipamentoDto>>
        {
            private readonly IEquipamentoPersistence _persistence;

            public ObterTodosEquipamentoHandler(IEquipamentoPersistence persistence)
                => _persistence = persistence;
            
            public async Task<IEnumerable<EquipamentoDto>> Handle(ObterTodosEquipamento request, CancellationToken cancellationToken)
                => await _persistence.ObterTodosEquipamentos();
        }
    }
}
