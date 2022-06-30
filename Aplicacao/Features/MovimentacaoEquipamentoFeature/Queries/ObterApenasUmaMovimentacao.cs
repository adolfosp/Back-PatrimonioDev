using Aplicacao.Dtos;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.MovimentacaoEquipamentoFeature.Queries
{
    public class ObterApenasUmaMovimentacao : IRequest<MovimentacaoEquipamentoDto>
    {
        public int CodigoMovimentacao { get; set; }

        public class ObterApenasUmaMovimentacaoHandler : IRequestHandler<ObterApenasUmaMovimentacao, MovimentacaoEquipamentoDto>
        {
            private readonly IMovimentacaoEquipamentoPersistence _persistence;

            public ObterApenasUmaMovimentacaoHandler(IMovimentacaoEquipamentoPersistence persistence)
                => _persistence = persistence;

            public Task<MovimentacaoEquipamentoDto> Handle(ObterApenasUmaMovimentacao request, CancellationToken cancellationToken)
                 => _persistence.ObterApenasUmaMovimentacao(request.CodigoMovimentacao);
        }
    }
}
