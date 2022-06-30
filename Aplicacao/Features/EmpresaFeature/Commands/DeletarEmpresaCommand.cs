using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Commands
{
    public class DeletarEmpresaCommand : IRequest<int>
    {
        public int CodigoEmpresa { get; set; }

        public class DeletarEmpresaCommandHandler : IRequestHandler<DeletarEmpresaCommand, int>
        {
            private readonly IEmpresaPersistence _persistence;

            public DeletarEmpresaCommandHandler(IEmpresaPersistence persistence)
                 => _persistence = persistence;

            public async Task<int> Handle(DeletarEmpresaCommand command, CancellationToken cancellationToken)
                => await _persistence.Remover(command.CodigoEmpresa);
        }
    }
}
