using Aplicacao.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioFeature.Queries
{
    public class ObterUsuarioPorEmail : IRequest<bool>
    {
        public string Email { get; set; }

        public class ObterUsuarioPorEmailHandler : IRequestHandler<ObterUsuarioPorEmail, bool>
        {
            private readonly IUsuarioPersistence _persistence;

            public ObterUsuarioPorEmailHandler(IUsuarioPersistence persistence)
                => _persistence = persistence;

            public Task<bool> Handle(ObterUsuarioPorEmail request, CancellationToken cancellationToken)
                => _persistence.ObterUsuarioPorEmail(request.Email);
        }
    }
}
