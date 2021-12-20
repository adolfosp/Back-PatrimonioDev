using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.InformacaoAdicionalFeature.Queries
{
    public class ObterInformacaoAdicionalPorId : IRequest<InformacaoAdicional>
    {
        public int Id { get; set; }

        public class ObterInformacaoAdicionalPorIdHandler : IRequestHandler<ObterInformacaoAdicionalPorId, InformacaoAdicional>
        {

            private readonly IApplicationDbContext _context;

            public ObterInformacaoAdicionalPorIdHandler(IApplicationDbContext context)
                => _context = context;

            public async Task<InformacaoAdicional> Handle(ObterInformacaoAdicionalPorId request, CancellationToken cancellationToken)
            {
                var informacaoAdicional = await _context.InformacaoAdicional.Where(x => x.CodigoInformacao == request.Id).FirstOrDefaultAsync();

                if (informacaoAdicional == null)
                    return null;

                return informacaoAdicional;
            }
        }
    }
}
