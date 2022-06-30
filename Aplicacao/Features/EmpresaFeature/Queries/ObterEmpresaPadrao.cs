using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Queries
{
    public class ObterEmpresaPadrao: IRequest<string>
    {
        public class ObterEmpresaPadraoHandler : IRequestHandler<ObterEmpresaPadrao, string>
        {
            private readonly IEmpresaPersistence _persistence;

            public ObterEmpresaPadraoHandler(IEmpresaPersistence persistence)
               => _persistence = persistence;
            
            public async Task<string> Handle(ObterEmpresaPadrao query, CancellationToken cancellationToken)
                => await _persistence.ObterEmpresaPadrao();
        }
    }
}
