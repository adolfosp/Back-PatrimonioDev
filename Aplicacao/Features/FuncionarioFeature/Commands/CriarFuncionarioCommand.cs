using Aplicacao.Dtos;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FuncionarioFeature.Commands
{
    public class CriarFuncionarioCommand : IRequest<Funcionario>
    {
        public FuncionarioDto Funcionario { get; set; }

        public class CriarFuncionarioCommandHandler : IRequestHandler<CriarFuncionarioCommand, Funcionario>
        {

            private readonly IFuncionarioPersistence _persistence;
            public CriarFuncionarioCommandHandler(IFuncionarioPersistence persistence)
                => _persistence = persistence;

            public Task<Funcionario> Handle(CriarFuncionarioCommand request, CancellationToken cancellationToken)
                => _persistence.CriarFuncionario(request.Funcionario);
        }
    }
}
