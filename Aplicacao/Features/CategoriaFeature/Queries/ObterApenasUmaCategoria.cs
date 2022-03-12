using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.CategoriaFeature.Queries
{
    public class ObterApenasUmaCategoria: IRequest<CategoriaEquipamento>
    {
        public int Id { get; set; }

        public class ObterApenasUmaCategoriaHandler : IRequestHandler<ObterApenasUmaCategoria, CategoriaEquipamento>
        {
            private readonly ICategoriaPersistence _persistence;

            public ObterApenasUmaCategoriaHandler(ICategoriaPersistence persistence)
                => _persistence = persistence;

            public async Task<CategoriaEquipamento> Handle(ObterApenasUmaCategoria request, CancellationToken cancellationToken)
                => await _persistence.ObterApenasUmaCategoria(request.Id);
        }
    }
}
