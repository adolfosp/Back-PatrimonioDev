using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Commands
{
    public class CriarEmpresaCommand : IRequest<Empresa>
    {
        public Empresa empresa { get; set; }

        public class CriarEquipamentoCommandHandler : IRequestHandler<CriarEmpresaCommand, Empresa>
        {
            private readonly IApplicationDbContext _context;

            public CriarEquipamentoCommandHandler(IApplicationDbContext context)
                 => _context = context;

            public async Task<Empresa> Handle(CriarEmpresaCommand request, CancellationToken cancellationToken)
            {

                var empresa = new Empresa();
                empresa.CNPJ = request.empresa.CNPJ;
                empresa.NomeFantasia = request.empresa.NomeFantasia;
                empresa.RazaoSocial = request.empresa.RazaoSocial;

                await _context.Empresa.AddAsync(empresa);

                await _context.SaveChangesAsync();

                return empresa;

            }
        }
    }
}
