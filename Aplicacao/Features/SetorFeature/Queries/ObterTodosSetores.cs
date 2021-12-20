using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.SetorFeature.Queries
{
    public class ObterTodosSetores : IRequest<IEnumerable<Setor>>
    {

        public class ObterTodosSetoresQueryHandler : IRequestHandler<ObterTodosSetores, IEnumerable<Setor>>
        {
            private readonly IApplicationDbContext _context;

            public ObterTodosSetoresQueryHandler(IApplicationDbContext context)
                => _context = context;

            public async Task<IEnumerable<Setor>> Handle(ObterTodosSetores request, CancellationToken cancellationToken)
            {
                var listaSetor = await _context.Setor.ToListAsync();

                if (listaSetor == null) return null;

                return listaSetor.AsReadOnly();
            }
        }


    }
}
