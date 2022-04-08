using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EstatisticaFeature.Queries
{
    public class ObterMediaEquipamentoPorFuncionario: IRequest<List<EstatisticaMediaEquipamentoDto>>
    {
        public class ObterMediaEquipamentoPorFuncionarioHandler : IRequestHandler<ObterMediaEquipamentoPorFuncionario, List<EstatisticaMediaEquipamentoDto>>
        {
            private readonly IEstatisticaPersistence _context;
            public ObterMediaEquipamentoPorFuncionarioHandler(IEstatisticaPersistence context)
                => _context = context;

            public async Task<List<EstatisticaMediaEquipamentoDto>> Handle(ObterMediaEquipamentoPorFuncionario request, CancellationToken cancellationToken)
                => await _context.ObterMediaEquipamentoPorFuncionario();
        }
    }
}
