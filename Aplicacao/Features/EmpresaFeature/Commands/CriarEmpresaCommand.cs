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
    public class CriarEmpresaCommand : IRequest<(Empresa Empresa, bool EmpresaContemOpcaoPadraoImpressao)>
    {
        public EmpresaDto Empresa { get; set; }

        public class CriarEquipamentoCommandHandler : IRequestHandler<CriarEmpresaCommand, (Empresa Empresa, bool EmpresaContemOpcaoPadraoImpressao)>
        {
            private readonly IApplicationDbContext _context;

            public CriarEquipamentoCommandHandler(IApplicationDbContext context)
                 => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<(Empresa Empresa, bool EmpresaContemOpcaoPadraoImpressao)> Handle(CriarEmpresaCommand command, CancellationToken cancellationToken)
            {
                //TODO: refatorar pois no atualizar tem o mesmo código
                if (command.Empresa.EmpresaPadraoImpressao)
                {

                    var empresaPadrao = await _context.Empresa.Where(x => x.EmpresaPadraoImpressao == true).Select(x => x).FirstOrDefaultAsync();

                    if (empresaPadrao is not null)
                        return (empresaPadrao, true);
                }

                var empresa = new Empresa();
                empresa.CNPJ = command.Empresa.CNPJ;
                empresa.NomeFantasia = command.Empresa.NomeFantasia;
                empresa.RazaoSocial = command.Empresa.RazaoSocial;
                empresa.EmpresaPadraoImpressao = command.Empresa.EmpresaPadraoImpressao;

                await _context.Empresa.AddAsync(empresa);

                await _context.SaveChangesAsync();

                return (empresa, false);

            }
        }
    }
}
