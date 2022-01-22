using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.SetorFeature.Commands
{
    public class AtualizarSetorCommand : IRequest<int>
    {
        public int Id { get; set; }

        public SetorDto Setor { get; set; }


        public class AtualizarSetorCommandHandler : IRequestHandler<AtualizarSetorCommand, int>
        {
            private IApplicationDbContext _context;

            public AtualizarSetorCommandHandler(IApplicationDbContext context)
                => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<int> Handle(AtualizarSetorCommand request, CancellationToken cancellationToken)
            {
                var setor = await _context.Setor.Where(x => x.CodigoSetor == request.Id).Select(x => x).FirstOrDefaultAsync();

                if (setor is null) return 404;

                setor.Nome = request.Setor.Nome;

                await _context.SaveChangesAsync();

                return 200;
            }
        }
    }
}
