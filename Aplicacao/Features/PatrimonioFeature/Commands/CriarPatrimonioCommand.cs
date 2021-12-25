using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;

namespace Aplicacao.Features.PatrimonioFeature.Commands
{
    public class CriarPatrimonioCommand : IRequest<Patrimonio>
    {
        public PatrimonioDto Patrimonio { get; set; }

        public class CriarPatrimonioCommandHandler : IRequestHandler<CriarPatrimonioCommand, Patrimonio>
        {
            private readonly IPatrimonioPersistence _persistence;

            public CriarPatrimonioCommandHandler(IPatrimonioPersistence persistence)
                => _persistence = persistence;


            public Task<Patrimonio> Handle(CriarPatrimonioCommand request, CancellationToken cancellationToken)
                => _persistence.CriarPatrimonio(request.Patrimonio);
        }
    }
}
