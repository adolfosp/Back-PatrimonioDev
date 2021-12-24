using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Aplicacao.Interfaces;

namespace Aplicacao.Features.UsuarioFeature.Queries
{
    public class ObterUsuarioPorLogin : IRequest<Usuario>
    {
        public string email { get; set; }
        public string senha { get; set; }

        public class ObterUsuarioPorLoginHandler : IRequestHandler<ObterUsuarioPorLogin, Usuario>
        {
            private readonly IUsuarioPersistence _persistence;

            public ObterUsuarioPorLoginHandler(IUsuarioPersistence persistence)
                => _persistence = persistence;

            public async Task<Usuario> Handle(ObterUsuarioPorLogin request, CancellationToken cancellationToken)
                => await _persistence.ObterUsuarioLogin(request.email, request.senha);
        }
    }
}
