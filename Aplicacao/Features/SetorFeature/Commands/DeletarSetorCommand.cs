using Aplicacao.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.SetorFeature.Commands
{
    public class DeletarSetorCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeletarSetorCommandHandler : IRequestHandler<DeletarSetorCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public DeletarSetorCommandHandler(IApplicationDbContext context)
                 => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<int> Handle(DeletarSetorCommand command, CancellationToken cancellationToken)
            {
                var setor = await _context.Setor.Where(x => x.CodigoSetor == command.Id).FirstOrDefaultAsync();

                if (setor == null) return 404;

                _context.Setor.Remove(setor);

                await _context.SaveChangesAsync();

                return 200;

            }
        }
    }
}
