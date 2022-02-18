using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.CategoriaFeature.Commands
{
    public class DeletarCategoriaCommand: IRequest<int>
    {

        public int Id { get; set; }

        public class DeletarCategoriaCommandHandler : IRequestHandler<DeletarCategoriaCommand, int>
        {

            private readonly ICategoriaPersistence _categoriaPersistence;
            public DeletarCategoriaCommandHandler(ICategoriaPersistence persistence)
                => _categoriaPersistence = persistence;

            public Task<int> Handle(DeletarCategoriaCommand request, CancellationToken cancellationToken)
                => _categoriaPersistence.DeletarCategoria(request.Id);
        }
    }
}
