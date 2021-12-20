using Aplicacao.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Commands
{
    public class DeletarEmpresaCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeletarEmpresaCommandHandler : IRequestHandler<DeletarEmpresaCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public DeletarEmpresaCommandHandler(IApplicationDbContext context)
                 => _context = context;

            public async Task<int> Handle(DeletarEmpresaCommand command, CancellationToken cancellationToken)
            {
                var empresa = await _context.Empresa.Where(x => x.CodigoEmpresa == command.Id).FirstOrDefaultAsync();

                if (empresa == null) return 404;

                _context.Empresa.Remove(empresa);

                await _context.SaveChangesAsync();

                return 200;

            }
        }
    }
}
