using Aplicacao.Dtos;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.MovimentacaoEquipamentoFeature.Commands
{
    public class AtualizarMovimentacaoEquipamentoCommand : IRequest<int>
    {
        public int CodigoMovimentacao { get; set; }

        public MovimentacaoEquipamentoDto MovimentacaoDto { get; set; }

        public class AtualizarMovimentacaoEquipamentoCommandHandler : IRequestHandler<AtualizarMovimentacaoEquipamentoCommand, int>
        {
            private readonly IMovimentacaoEquipamentoPersistence _persistence;

            public AtualizarMovimentacaoEquipamentoCommandHandler(IMovimentacaoEquipamentoPersistence persistence)
                => _persistence = persistence;


            public Task<int> Handle(AtualizarMovimentacaoEquipamentoCommand request, CancellationToken cancellationToken)
                => _persistence.AtualizarMovimentacaoEquipamento(request.CodigoMovimentacao, request.MovimentacaoDto);
        }
    }
}
