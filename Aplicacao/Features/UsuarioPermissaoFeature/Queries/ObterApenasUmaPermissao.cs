using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioFeature.Queries
{
    public class ObterApenasUmaPermissao : IRequest<UsuarioPermissao>
    {
        public int Id { get; set; }

        public class ObterApenasUmaPermissaoHandler : IRequestHandler<ObterApenasUmaPermissao, UsuarioPermissao>
        {
            private readonly IUsuarioPermissaoPersistence _persistence;

            public ObterApenasUmaPermissaoHandler(IUsuarioPermissaoPersistence persistence)
                => _persistence = persistence;

            public async Task<UsuarioPermissao> Handle(ObterApenasUmaPermissao request, CancellationToken cancellationToken)
                => await _persistence.ObterApenasUmaPermissao(request.Id);
        }
    }
}
