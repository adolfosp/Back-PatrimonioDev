using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.SetorFeature.Queries
{
    public class ObterApenasUmSetor : IRequest<Setor>
    {
        public int CodigoSetor { get; set; }

        public class ObterApenasUmSetorHandler : IRequestHandler<ObterApenasUmSetor, Setor>
        {
            private readonly ISetorPersistence _persistence;

            public ObterApenasUmSetorHandler(ISetorPersistence persistence)
                 => _persistence = persistence;

            public async Task<Setor> Handle(ObterApenasUmSetor query, CancellationToken cancellationToken)
               => await _persistence.ObterPorCodigoSetor(query.CodigoSetor);
        }
    }
}
