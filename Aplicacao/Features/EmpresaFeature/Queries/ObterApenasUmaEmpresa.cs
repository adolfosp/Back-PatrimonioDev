using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Queries
{
    public class ObterApenasUmaEmpresa : IRequest<Empresa>
    {
        public int CodigoEmpresa { get; set; }

        public class ObterApenasUmaEmpresaQueryHandler : IRequestHandler<ObterApenasUmaEmpresa, Empresa>
        {
            private readonly IEmpresaPersistence _persistence;

            public ObterApenasUmaEmpresaQueryHandler(IEmpresaPersistence persistence)
              => _persistence = persistence;
            
            public async Task<Empresa> Handle(ObterApenasUmaEmpresa query, CancellationToken cancellationToken)
                => await _persistence.ObterUma(query.CodigoEmpresa);
        }
    }
}
