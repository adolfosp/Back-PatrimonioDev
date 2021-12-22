using Aplicacao.Interfaces;
using Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioFeature.Commands
{
    public class RemoverUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class RemoverUsuarioHandler : IRequestHandler<RemoverUsuarioCommand, int>
        {

            private readonly IUsuarioPersistence _persistence;

            public RemoverUsuarioHandler(IUsuarioPersistence persistence)
                => _persistence = persistence;

            public Task<int> Handle(RemoverUsuarioCommand request, CancellationToken cancellationToken)
                => _persistence.DeletarUsuario(request.Id);
        }
    }
}
