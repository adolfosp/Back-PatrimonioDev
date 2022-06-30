using Domain.Entidades;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioFeature.Commands
{
    public class RemoverUsuarioCommand : IRequest<Usuario>
    {
        public int Id { get; set; }

        public class RemoverUsuarioHandler : IRequestHandler<RemoverUsuarioCommand, Usuario>
        {

            private readonly IUsuarioPersistence _persistence;

            public RemoverUsuarioHandler(IUsuarioPersistence persistence)
                => _persistence = persistence;

            public Task<Usuario> Handle(RemoverUsuarioCommand request, CancellationToken cancellationToken)
                => _persistence.DeletarUsuario(request.Id);
        }
    }
}
