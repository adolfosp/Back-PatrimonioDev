using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.SetorFeature.Queries
{
    public class ObterApenasUmSetor : IRequest<Setor>
    {
        public int Id { get; set; }

        public class ObterApenasUmSetorHandler : IRequestHandler<ObterApenasUmSetor, Setor>
        {
            private readonly IApplicationDbContext _context;

            public ObterApenasUmSetorHandler(IApplicationDbContext context)
                 => _context = context;

            public async Task<Setor> Handle(ObterApenasUmSetor query, CancellationToken cancellationToken)
            {
                var setor = await _context.Setor.Where(x => x.CodigoSetor == query.Id).FirstOrDefaultAsync();
                if (setor == null) return null;
                return setor;
            }
        }
    }
}
