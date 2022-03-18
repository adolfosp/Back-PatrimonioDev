using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FuncionarioFeature.Commands
{
    public class DesativarFuncionarioCommand : IRequest<int>
    {
        public int CodigoFuncionario { get; set; }

        public class DesativarFuncionarioCommandHandler : IRequestHandler<DesativarFuncionarioCommand, int>
        {
            private readonly IFuncionarioPersistence _persistence;

            public DesativarFuncionarioCommandHandler(IFuncionarioPersistence persistence)
                => _persistence = persistence;

            public Task<int> Handle(DesativarFuncionarioCommand request, CancellationToken cancellationToken)
                => _persistence.DesativarFuncionario(request.CodigoFuncionario);
        }
    }
}
