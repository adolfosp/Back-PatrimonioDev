using Aplicacao.Dtos;
using Domain.Entidades;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioPermissaoFeature.Commands
{
    public class CriarUsuarioPermissaoCommand : IRequest<UsuarioPermissao>
    {
        public UsuarioPermissaoDto UsuarioPermissao { get; set; }

        public class CriarUsuarioPermissaoHandler : IRequestHandler<CriarUsuarioPermissaoCommand, UsuarioPermissao>
        {
            private readonly IUsuarioPermissaoPersistence _persistence;

            public CriarUsuarioPermissaoHandler(IUsuarioPermissaoPersistence persistence)
                => _persistence = persistence;

            public Task<UsuarioPermissao> Handle(CriarUsuarioPermissaoCommand request, CancellationToken cancellationToken)
                => _persistence.CriarUsuarioPermissao(new UsuarioPermissao() { DescricaoPermissao = request.UsuarioPermissao.DescricaoPermissao, Ativo = true });
        }
    }
}
