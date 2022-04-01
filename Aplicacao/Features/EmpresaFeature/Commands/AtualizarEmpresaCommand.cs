using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Commands
{
    public class AtualizarEmpresaCommand : IRequest<(int CodigoStatus, string NomeEmpresa)>
    {
        public int Id { get; set; }

        public EmpresaDto Empresa { get; set; }

        public class AtualizarEmpresaCommandHandler : IRequestHandler<AtualizarEmpresaCommand, (int CodigoStatus, string NomeEmpresa)>
        {
            private readonly IApplicationDbContext _context;

            public AtualizarEmpresaCommandHandler(IApplicationDbContext context)
                => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<(int CodigoStatus, string NomeEmpresa)> Handle(AtualizarEmpresaCommand command, CancellationToken cancellationToken)
            {

                var empresa = await _context.Empresa.Where(x => x.CodigoEmpresa == command.Id).FirstOrDefaultAsync();

                if (empresa == null) return (404, "");

                if (command.Empresa.EmpresaPadraoImpressao) { 

                    var empresaPadrao = await _context.Empresa.Where(x => x.EmpresaPadraoImpressao == true).Select(x => new { x.NomeFantasia, x.CodigoEmpresa }).FirstOrDefaultAsync();

                    if (empresaPadrao.CodigoEmpresa != command.Id)
                        return (400, empresaPadrao.NomeFantasia);
                }

                empresa.CNPJ = command.Empresa.CNPJ;
                empresa.NomeFantasia = command.Empresa.NomeFantasia;
                empresa.RazaoSocial = command.Empresa.RazaoSocial;
                empresa.EmpresaPadraoImpressao = command.Empresa.EmpresaPadraoImpressao;

                await _context.SaveChangesAsync();

                return (200, "");

            }
        }
    }
}
