using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FabricanteFeature.Commands
{
    public class CriarFabricanteCommand : IRequest<Fabricante>
    {
        public Fabricante Fabricante { get; set; }

        public class CriarFabricanteHandler : IRequestHandler<CriarFabricanteCommand, Fabricante>

        {
            private readonly IApplicationDbContext _context;

            public CriarFabricanteHandler(IApplicationDbContext context)
                => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<Fabricante> Handle(CriarFabricanteCommand request, CancellationToken cancellationToken)
            {
                var fabricante = new Fabricante();

                fabricante = request.Fabricante;

                await _context.Fabricante.AddAsync(fabricante);

                await _context.SaveChangesAsync();

                return fabricante;
            }
        }
    }
}
