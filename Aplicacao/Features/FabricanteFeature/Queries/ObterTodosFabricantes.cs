using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FabricanteFeature.Queries
{
    public class ObterTodosFabricantes : IRequest<IEnumerable<Fabricante>>
    {

        public class ObterTodosFabricantesHanlder : IRequestHandler<ObterTodosFabricantes, IEnumerable<Fabricante>>
        {
            private readonly IApplicationDbContext _context;

            public ObterTodosFabricantesHanlder(IApplicationDbContext context)
                => _context = context;

            public async Task<IEnumerable<Fabricante>> Handle(ObterTodosFabricantes request, CancellationToken cancellationToken)
            {
                var listaDeFabricantes = await _context.Fabricante.ToListAsync();

                if (listaDeFabricantes == null)
                    return null;
                
                return listaDeFabricantes.AsReadOnly();
            }
        }
    }
}
