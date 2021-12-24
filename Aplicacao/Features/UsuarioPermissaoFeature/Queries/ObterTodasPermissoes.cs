using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioPermissaoFeature.Queries
{
    public class ObterTodasPermissoes : IRequest<IEnumerable<UsuarioPermissao>>
    {

        public class ObterTodasPermissoesHandler : IRequestHandler<ObterTodasPermissoes, IEnumerable<UsuarioPermissao>>
        {
            private readonly IUsuarioPermissaoPersistence _persistence;

            public ObterTodasPermissoesHandler(IUsuarioPermissaoPersistence persistence)
                => _persistence = persistence;

            public Task<IEnumerable<UsuarioPermissao>> Handle(ObterTodasPermissoes request, CancellationToken cancellationToken)
                => _persistence.ObterTodasPermissoes(); 
        }
    }
}
