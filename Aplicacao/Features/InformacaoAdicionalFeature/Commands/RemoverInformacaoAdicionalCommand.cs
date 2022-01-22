using Aplicacao.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.InformacaoAdicionalFeature.Commands
{
    public class RemoverInformacaoAdicionalCommand : IRequest<int> 
    {
        public int Id { get; set; }

        public class RemoverInformacaoAdicionalHandler : IRequestHandler<RemoverInformacaoAdicionalCommand, int>
        {

            private readonly IApplicationDbContext _context;

            public RemoverInformacaoAdicionalHandler(IApplicationDbContext context)
                => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<int> Handle(RemoverInformacaoAdicionalCommand request, CancellationToken cancellationToken)
            {
                var informacaoAdicional = await _context.InformacaoAdicional.Where(x => x.CodigoInformacao == request.Id).FirstOrDefaultAsync();

                if (informacaoAdicional == null) return 404;

                _context.InformacaoAdicional.Remove(informacaoAdicional);

                await _context.SaveChangesAsync();

                return 200;
            }
        }
    }
}
