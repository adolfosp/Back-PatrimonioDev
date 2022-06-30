using Aplicacao.Dtos;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioPermissaoFeature.Commands
{
    public class AtualizarPermissaoCommand: IRequest<int>
    {
        public int Id { get; set; }

        public UsuarioPermissaoDto UsuarioPermissao { get; set; }

        public class AtualizarPermissaoCommandHandler : IRequestHandler<AtualizarPermissaoCommand, int>
        {
            private readonly IUsuarioPermissaoPersistence _persistence;

            public AtualizarPermissaoCommandHandler(IUsuarioPermissaoPersistence persistence)
                => _persistence = persistence;

            public async Task<int> Handle(AtualizarPermissaoCommand request, CancellationToken cancellationToken)
                => await _persistence.AtualizarUsuarioPermissao(request.UsuarioPermissao, request.Id);
        }
    }
}
