using Aplicacao.Dtos;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioFeature.Commands
{
    public class AtualizarUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }

        public UsuarioDto Usuario { get; set; }

        public class AtualizarUsuarioHandler: IRequestHandler<AtualizarUsuarioCommand, int>
        {
            private readonly IUsuarioPersistence _persistence;

            public AtualizarUsuarioHandler(IUsuarioPersistence persistence)
                => _persistence = persistence;

            public async Task<int> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
                => await _persistence.AtualizarUsuario(request.Usuario, request.Id);
        }
    }
}
