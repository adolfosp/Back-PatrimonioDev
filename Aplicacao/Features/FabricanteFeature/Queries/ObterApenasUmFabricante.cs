using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FabricanteFeature.Queries
{
    public class ObterApenasUmFabricante : IRequest<Fabricante>
    {
        public int Id { get; set; }

        public class ObterApenasUmFabricanteHandler : IRequestHandler<ObterApenasUmFabricante, Fabricante>
        {
            private readonly IApplicationDbContext _context;

            public ObterApenasUmFabricanteHandler(IApplicationDbContext context)
                => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<Fabricante> Handle(ObterApenasUmFabricante request, CancellationToken cancellationToken)
            {
                var listaDeFabricantes = await _context.Fabricante.Where(x => x.CodigoFabricante == request.Id).FirstOrDefaultAsync();

                if (listaDeFabricantes == null)
                    return null;
               
                return listaDeFabricantes;
            }
        }
    }
}
