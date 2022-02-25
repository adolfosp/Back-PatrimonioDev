using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PerfilUsuarioFeature.Queries
{
    public class ObterPerfilUsuario: IRequest<PerfilUsuario>
    {
        public int CodigoUsuario { get; set; }

        public class ObterPerfilUsuarioHandler : IRequestHandler<ObterPerfilUsuario, PerfilUsuario>
        {
            private readonly IPerfilUsuario _repository;
            public ObterPerfilUsuarioHandler(IPerfilUsuario repository)
                => _repository = repository;

            public Task<PerfilUsuario> Handle(ObterPerfilUsuario request, CancellationToken cancellationToken)
            => _repository.ObterInformacaoPerfil(request.CodigoUsuario);
        }
    }
}
