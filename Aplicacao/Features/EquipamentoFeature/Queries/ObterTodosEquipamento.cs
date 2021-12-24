using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EquipamentoFeature.Queries
{
    public class ObterTodosEquipamento : IRequest<IEnumerable<Equipamento>>
    {

        public class ObterTodosEquipamentoHandler: IRequestHandler<ObterTodosEquipamento, IEnumerable<Equipamento>>
        {
            private readonly IEquipamentoPersistence _persistence;

            public ObterTodosEquipamentoHandler(IEquipamentoPersistence persistence)
                => _persistence = persistence;
            
            public Task<IEnumerable<Equipamento>> Handle(ObterTodosEquipamento request, CancellationToken cancellationToken)
                => _persistence.ObterTodosEquipamentos();
        }
    }
}
