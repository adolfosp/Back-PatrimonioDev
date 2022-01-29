using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FabricanteFeature.Commands
{
    public class AtualizarFabricanteCommand : IRequest<int>
    {
        public int Id { get; set; }

        public FabricanteDto Fabricante { get; set; }

        public class AtualizarFabricanteHandler : IRequestHandler<AtualizarFabricanteCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public AtualizarFabricanteHandler(IApplicationDbContext context)
                => _context = context;


            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<int> Handle(AtualizarFabricanteCommand command, CancellationToken cancellationToken)
            {

                var fabricante = await _context.Fabricante.Where(x => x.CodigoFabricante == command.Id).FirstOrDefaultAsync();

                if (fabricante == null) return 404;

                fabricante.NomeFabricante = command.Fabricante.NomeFabricante;

                await _context.SaveChangesAsync();

                return 200;

            }
        }
    }
}
