using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FuncionarioFeature.Queries
{
    public class ObterFuncionarioPorId : IRequest<Funcionario>
    {
        public int CodigoFuncionario { get; set; }

        public class ObterFuncionarioPorIdHandler : IRequestHandler<ObterFuncionarioPorId, Funcionario>
        {
            private readonly IFuncionarioPersistence _persistence;

            public ObterFuncionarioPorIdHandler(IFuncionarioPersistence persistence)
                => _persistence = persistence;

            public Task<Funcionario> Handle(ObterFuncionarioPorId request, CancellationToken cancellationToken)
                => _persistence.ObterFuncionarioPorId(request.CodigoFuncionario);
        }
    }
}
