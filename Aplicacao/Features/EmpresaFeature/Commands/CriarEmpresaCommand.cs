using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Commands
{
    public class CriarEmpresaCommand : IRequest<Empresa>
    {
        public EmpresaDto Empresa { get; set; }

        public class CriarEquipamentoCommandHandler : IRequestHandler<CriarEmpresaCommand, Empresa>
        {
            private readonly IApplicationDbContext _context;

            public CriarEquipamentoCommandHandler(IApplicationDbContext context)
                 => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<Empresa> Handle(CriarEmpresaCommand request, CancellationToken cancellationToken)
            {

                var empresa = new Empresa();
                empresa.CNPJ = request.Empresa.CNPJ;
                empresa.NomeFantasia = request.Empresa.NomeFantasia;
                empresa.RazaoSocial = request.Empresa.RazaoSocial;
                empresa.EmpresaPadraoImpressao = request.Empresa.EmpresaPadraoImpressao;

                await _context.Empresa.AddAsync(empresa);

                await _context.SaveChangesAsync();

                return empresa;

            }
        }
    }
}
