using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Queries
{
    public class ObterApenasUmaEmpresa : IRequest<Empresa>
    {
        public int Id { get; set; }

        public class ObterApenasUmaEmpresaQueryHandler : IRequestHandler<ObterApenasUmaEmpresa, Empresa>
        {
            private readonly IApplicationDbContext _context;

            public ObterApenasUmaEmpresaQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<Empresa> Handle(ObterApenasUmaEmpresa query, CancellationToken cancellationToken)
            {

                var listaEmpresa = await _context.Empresa.Where(x => x.CodigoEmpresa == query.Id).FirstOrDefaultAsync();

                if (listaEmpresa == null)
                    return null;
                

                return listaEmpresa;
            }
        }
    }
}
