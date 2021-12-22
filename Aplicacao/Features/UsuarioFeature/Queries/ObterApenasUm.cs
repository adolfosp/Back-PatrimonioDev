using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioFeature.Queries
{
    public class ObterApenasUm : IRequest<Usuario>
    {
        public int Id { get; set; }

        public class ObterApenasUmHandler : IRequestHandler<ObterApenasUm, Usuario>
        {
            private readonly IUsuarioPersistence _persistence;

            public ObterApenasUmHandler(IUsuarioPersistence persistence)
                => _persistence = persistence;

            public async Task<Usuario> Handle(ObterApenasUm request, CancellationToken cancellationToken)
                => await _persistence.ObterApenasUm(request.Id);
        }
    }
}
