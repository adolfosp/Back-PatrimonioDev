using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Queries
{
    public class ObterTodasEmpresas : IRequest<IEnumerable<Empresa>>
    {

        public class ObterTodasEmpresasQueryHandler : IRequestHandler<ObterTodasEmpresas, IEnumerable<Empresa>>
        {
            private readonly IApplicationDbContext _context;

            public ObterTodasEmpresasQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<IEnumerable<Empresa>> Handle(ObterTodasEmpresas query, CancellationToken cancellationToken)
            {

                var listaEmpresas = await _context.Empresa.ToListAsync();

                if (listaEmpresas == null)
                {
                    return null;
                }

                return listaEmpresas.AsReadOnly();
            }
        }
    }
}
