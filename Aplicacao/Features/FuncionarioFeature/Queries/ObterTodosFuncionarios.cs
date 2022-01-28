using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FuncionarioFeature.Queries
{
    public class ObterTodosFuncionarios : IRequest<IEnumerable<Funcionario>>
    {

        public class ObterTodosFuncionariosHandler : IRequestHandler<ObterTodosFuncionarios, IEnumerable<Funcionario>>
        {
            private readonly IFuncionarioPersistence _persistence;

            public ObterTodosFuncionariosHandler(IFuncionarioPersistence persistence)
                => _persistence = persistence;

            public Task<IEnumerable<Funcionario>> Handle(ObterTodosFuncionarios request, CancellationToken cancellationToken)
                => _persistence.ObterTodosFuncionarios();
        }
    }
}
