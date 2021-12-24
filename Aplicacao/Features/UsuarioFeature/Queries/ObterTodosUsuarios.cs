using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioFeature.Queries
{
    public class ObterTodosUsuarios : IRequest<IEnumerable<Usuario>>
    {

        public class ObterTodosUsuariosHandler : IRequestHandler<ObterTodosUsuarios, IEnumerable<Usuario>>
        {
            private readonly IUsuarioPersistence _persistence;
            public ObterTodosUsuariosHandler(IUsuarioPersistence persistence)
                => _persistence = persistence;

            public Task<IEnumerable<Usuario>> Handle(ObterTodosUsuarios request, CancellationToken cancellationToken)
                => _persistence.ObterTodosUsuario();
        }
    }
}
