using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FuncionarioFeature.Commands
{
    public class AtualizarFuncionarioCommand: IRequest<int>
    {
        public int CodigoFuncionario { get; set; }
        public FuncionarioDto FuncionaioDto { get; set; }

        public class AtualizarFuncionarioCommandHandler : IRequestHandler<AtualizarFuncionarioCommand, int>
        {

            private readonly IFuncionarioPersistence _persistence;

            public AtualizarFuncionarioCommandHandler(IFuncionarioPersistence persistence)
                => _persistence = persistence;

            public Task<int> Handle(AtualizarFuncionarioCommand request, CancellationToken cancellationToken)
                => _persistence.AtualizarFuncionario(request.CodigoFuncionario, request.FuncionaioDto);
        }
    }
}
