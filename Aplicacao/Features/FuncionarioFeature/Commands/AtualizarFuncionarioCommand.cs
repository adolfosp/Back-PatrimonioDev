using Aplicacao.Dtos;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FuncionarioFeature.Commands
{
    public class AtualizarFuncionarioCommand: IRequest<int>
    {
        public int CodigoFuncionario { get; set; }
        public FuncionarioDto Funcionario { get; set; }

        public class AtualizarFuncionarioCommandHandler : IRequestHandler<AtualizarFuncionarioCommand, int>
        {

            private readonly IFuncionarioPersistence _persistence;

            public AtualizarFuncionarioCommandHandler(IFuncionarioPersistence persistence)
                => _persistence = persistence;

            public Task<int> Handle(AtualizarFuncionarioCommand request, CancellationToken cancellationToken)
                => _persistence.Atualizar(request.CodigoFuncionario, request.Funcionario);
        }
    }
}
