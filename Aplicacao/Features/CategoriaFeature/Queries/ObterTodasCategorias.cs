using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.CategoriaFeature.Queries
{
    public class ObterTodasCategorias: IRequest<IEnumerable<CategoriaEquipamento>> 
    {

        public class ObterTodasCategoriasHandler : IRequestHandler<ObterTodasCategorias, IEnumerable<CategoriaEquipamento>>
        {
            private readonly ICategoriaPersistence _persistence;

            public ObterTodasCategoriasHandler(ICategoriaPersistence persistence) 
              =>  _persistence = persistence;


            public Task<IEnumerable<CategoriaEquipamento>> Handle(ObterTodasCategorias request, CancellationToken cancellationToken)
                => _persistence.ObterTodasCategorias();
            
        }
    }
}
