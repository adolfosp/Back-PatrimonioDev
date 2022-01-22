using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Commands
{
    public class AtualizarEmpresaCommand : IRequest<int>
    {
        public int Id { get; set; }

        public EmpresaDto Empresa { get; set; }

        public class AtualizarEmpresaCommandHandler : IRequestHandler<AtualizarEmpresaCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public AtualizarEmpresaCommandHandler(IApplicationDbContext context)
                => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<int> Handle(AtualizarEmpresaCommand command, CancellationToken cancellationToken)
            {

                var empresa = await _context.Empresa.Where(x => x.CodigoEmpresa == command.Id).FirstOrDefaultAsync();

                if (empresa == null) return 404;

                empresa.CNPJ = command.Empresa.CNPJ;
                empresa.NomeFantasia = command.Empresa.NomeFantasia;
                empresa.RazaoSocial = command.Empresa.RazaoSocial;

                await _context.SaveChangesAsync();

                return 200;

            }
        }
    }
}
