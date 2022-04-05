using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PercaEquipamentoFeature.Queries
{
    public class ObterPercaEquipamentoPorId : IRequest<PerdaEquipamento>
    {
        public int Id { get; set; }

        public class ObterPercaEquipamentoPorIdHandler : IRequestHandler<ObterPercaEquipamentoPorId, PerdaEquipamento>
        {
            private readonly IPercaEquipamentoPersistence _persistence;

            public ObterPercaEquipamentoPorIdHandler(IPercaEquipamentoPersistence persistence)
                =>  _persistence = persistence;

            public Task<PerdaEquipamento> Handle(ObterPercaEquipamentoPorId request, CancellationToken cancellationToken)
                => _persistence.ObterPercaPorId(request.Id);
        }
    }
}
