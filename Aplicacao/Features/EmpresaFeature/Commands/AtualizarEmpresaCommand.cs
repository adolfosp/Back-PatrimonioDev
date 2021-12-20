using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Commands
{
    public class AtualizarEmpresaCommand : IRequest<int>
    {
        public int Id { get; set; }

        public Empresa Empresa { get; set; }

        public class AtualizarEmpresaCommandHandler : IRequestHandler<AtualizarEmpresaCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public AtualizarEmpresaCommandHandler(IApplicationDbContext context)
                => _context = context;

            public async Task<int> Handle(AtualizarEmpresaCommand command, CancellationToken cancellationToken)
            {

                var empresa = await _context.Empresa.Where(x => x.CodigoEmpresa == command.Id).FirstOrDefaultAsync();

                if (empresa == null) return 404;

                empresa.CNPJ = command.Empresa.CNPJ;
                empresa.NomeEmpresa = command.Empresa.NomeEmpresa;
                empresa.NomeFantasia = command.Empresa.NomeFantasia;
                empresa.RazaoSocial = command.Empresa.RazaoSocial;

                await _context.SaveChangesAsync();

                return 200;

            }
        }
    }
}
