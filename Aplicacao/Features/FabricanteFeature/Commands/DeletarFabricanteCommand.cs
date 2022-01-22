using Aplicacao.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FabricanteFeature.Commands
{
    public class DeletarFabricanteCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeletarFabricanteHandler : IRequestHandler<DeletarFabricanteCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public DeletarFabricanteHandler(IApplicationDbContext context)
                => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<int> Handle(DeletarFabricanteCommand command, CancellationToken cancellationToken)
            {
                var fabricante = await _context.Fabricante.Where(x => x.CodigoFabricante == command.Id).FirstOrDefaultAsync();

                if (fabricante == null) return 404;

                _context.Fabricante.Remove(fabricante);

                await _context.SaveChangesAsync();

                return 200;

            }
        }
    }
}
