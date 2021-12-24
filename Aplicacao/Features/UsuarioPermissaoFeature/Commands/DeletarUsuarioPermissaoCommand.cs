using Aplicacao.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioPermissaoFeature.Commands
{
    public class DeletarUsuarioPermissaoCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeletarUsuarioPermissaoHandler: IRequestHandler<DeletarUsuarioPermissaoCommand, int>
        {
            private readonly IUsuarioPermissaoPersistence _persistence;

            public DeletarUsuarioPermissaoHandler(IUsuarioPermissaoPersistence persistence)
                => _persistence = persistence;

            public Task<int> Handle(DeletarUsuarioPermissaoCommand request, CancellationToken cancellationToken)
                => _persistence.DeletarUsuarioPermissao(request.Id);


        }
    }
}
