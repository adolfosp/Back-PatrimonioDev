using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FuncionarioFeature.Commands
{
    public class CriarFuncionarioCommand : IRequest<Funcionario>
    {
        public FuncionarioDto FuncionarioDto { get; set; }

        public class CriarFuncionarioCommandHandler : IRequestHandler<CriarFuncionarioCommand, Funcionario>
        {

            private readonly IFuncionarioPersistence _persistence;
            public CriarFuncionarioCommandHandler(IFuncionarioPersistence persistence)
                => _persistence = persistence;

            public Task<Funcionario> Handle(CriarFuncionarioCommand request, CancellationToken cancellationToken)
                => _persistence.CriarFuncionario(request.FuncionarioDto);
        }
    }
}
