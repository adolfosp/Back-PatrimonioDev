using Aplicacao.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Queries
{
    public class ObterEmpresaPadrao: IRequest<string>
    {
        public class ObterEmpresaPadraoHandler : IRequestHandler<ObterEmpresaPadrao, string>
        {
            private readonly IApplicationDbContext _context;

            public ObterEmpresaPadraoHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<string> Handle(ObterEmpresaPadrao query, CancellationToken cancellationToken)
            {

                var empresaPadrao = await _context.Empresa.Where(x => x.EmpresaPadraoImpressao == true).Select(x => x.NomeFantasia).FirstOrDefaultAsync();

                if (empresaPadrao == null)
                    return string.Empty;
                
                return empresaPadrao;
            }
        }
    }
}
