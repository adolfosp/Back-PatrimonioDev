using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.CategoriaFeature.Commands
{
    public class AtualizarCategoriaCommand: IRequest<int>
    {
        public CategoriaEquipamento Categoria { get; set; }

        public class AtualizarCategoriaCommandHandler : IRequestHandler<AtualizarCategoriaCommand, int>
        {

            private readonly ICategoriaPersistence _categoriaPersistence;
            public AtualizarCategoriaCommandHandler(ICategoriaPersistence persistence)
                => _categoriaPersistence = persistence;

            public Task<int> Handle(AtualizarCategoriaCommand request, CancellationToken cancellationToken)
                => _categoriaPersistence.AtualizarEquipamento(request.Categoria.CodigoCategoria, request.Categoria);
        }
    }
}
