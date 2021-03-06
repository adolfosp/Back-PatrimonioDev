using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PerfilUsuarioFeature.Queries
{
    public class ObterPerfilUsuario : IRequest<PerfilUsuario>
    {
        public int CodigoUsuario { get; set; }

        public class ObterPerfilUsuarioHandler : IRequestHandler<ObterPerfilUsuario, PerfilUsuario>
        {
            private readonly IPerfilUsuarioPersistence _repository;
            public ObterPerfilUsuarioHandler(IPerfilUsuarioPersistence repository)
                => _repository = repository;

            public Task<PerfilUsuario> Handle(ObterPerfilUsuario request, CancellationToken cancellationToken)
                => _repository.ObterInformacaoPerfil(request.CodigoUsuario);
        }
    }
}
