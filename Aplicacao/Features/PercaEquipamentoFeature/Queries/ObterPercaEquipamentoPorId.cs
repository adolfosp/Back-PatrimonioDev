using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PercaEquipamentoFeature.Queries
{
    public class ObterPercaEquipamentoPorId : IRequest<PercaEquipamento>
    {
        public int Id { get; set; }

        public class ObterPercaEquipamentoPorIdHandler : IRequestHandler<ObterPercaEquipamentoPorId, PercaEquipamento>
        {
            private readonly IPercaEquipamentoPersistence _persistence;

            public ObterPercaEquipamentoPorIdHandler(IPercaEquipamentoPersistence persistence)
                =>  _persistence = persistence;

            public Task<PercaEquipamento> Handle(ObterPercaEquipamentoPorId request, CancellationToken cancellationToken)
                => _persistence.ObterPercaPorId(request.Id);
        }
    }
}
