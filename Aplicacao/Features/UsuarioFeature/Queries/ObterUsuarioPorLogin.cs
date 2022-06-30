using Domain.Entidades;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioFeature.Queries
{
    public class ObterUsuarioPorLogin : IRequest<Usuario>
    {
        public string email { get; set; }
        public string senha { get; set; }
        private bool _autenticacaoAuth;

        public ObterUsuarioPorLogin(bool autenticacaoAuth)
        {
            _autenticacaoAuth = autenticacaoAuth;
        }

        public class ObterUsuarioPorLoginHandler : IRequestHandler<ObterUsuarioPorLogin, Usuario>
        {
            private readonly IUsuarioPersistence _persistence;

            public ObterUsuarioPorLoginHandler(IUsuarioPersistence persistence)
                => _persistence = persistence;

            public async Task<Usuario> Handle(ObterUsuarioPorLogin request, CancellationToken cancellationToken)
                => await _persistence.ObterUsuarioLogin(request.email, request.senha, request._autenticacaoAuth);
        }
    }
}
