using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EquipamentoFeature.Queries
{
    public class ObterApenasUmEquipamento : IRequest<Equipamento>
    {
        public int CodigoEquipamento { get; set; }

        public class ObterApenasUmEquipamentoHandler: IRequestHandler<ObterApenasUmEquipamento, Equipamento>
        {
            private readonly IEquipamentoPersistence _persistence;

            public ObterApenasUmEquipamentoHandler(IEquipamentoPersistence persistence)
                => _persistence = persistence;

            public Task<Equipamento> Handle(ObterApenasUmEquipamento request, CancellationToken cancellationToken)
                => _persistence.ObterEquipamentoPorId(request.CodigoEquipamento);
        }

    }
}
