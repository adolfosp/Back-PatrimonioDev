using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.CategoriaFeature.Commands
{
    public class CriarCategoriaCommand: IRequest<CategoriaEquipamento>
    {
        public CategoriaEquipamento Categoria { get; set; }

        public class CriarEquipamentoCommandHandler : IRequestHandler<CriarCategoriaCommand, CategoriaEquipamento>
        {
            private readonly IApplicationDbContext _context;

            public CriarEquipamentoCommandHandler(IApplicationDbContext context)
                 => _context = context;

            public async Task<CategoriaEquipamento> Handle(CriarCategoriaCommand request, CancellationToken cancellationToken)
            {

                var categoria = new CategoriaEquipamento();

                categoria.Descricao = request.Categoria.Descricao ;
               
                await _context.CategoriaEquipamento.AddAsync(categoria);

                await _context.SaveChangesAsync();

                return categoria;

            }
        }
    }
}
