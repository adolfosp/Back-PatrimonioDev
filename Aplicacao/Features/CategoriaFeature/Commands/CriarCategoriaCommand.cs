using Aplicacao.Dtos;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.CategoriaFeature.Commands
{
    public class CriarCategoriaCommand: IRequest<CategoriaEquipamento>
    {
        public CategoriaDto Categoria { get; set; }

        public class CriarEquipamentoCommandHandler : IRequestHandler<CriarCategoriaCommand, CategoriaEquipamento>
        {
            private readonly ICategoriaPersistence _context;

            public CriarEquipamentoCommandHandler(ICategoriaPersistence context)
                 => _context = context;

            public async Task<CategoriaEquipamento> Handle(CriarCategoriaCommand request, CancellationToken cancellationToken)
                => await _context.CriarCategoria(request.Categoria);
            
        }
    }
}
