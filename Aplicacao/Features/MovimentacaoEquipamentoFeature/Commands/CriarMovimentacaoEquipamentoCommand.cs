using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.MovimentacaoEquipamentoFeature.Commands
{
    public class CriarMovimentacaoEquipamentoCommand : IRequest<MovimentacaoEquipamento>
    {
        public MovimentacaoEquipamento Movimentacao { get; set; }

        public class CriarMovimentacaoEquipamentoCommandHandler: IRequestHandler<CriarMovimentacaoEquipamentoCommand, MovimentacaoEquipamento>
        {
            private readonly IMovimentacaoEquipamentoPersistence _persistence;

            public CriarMovimentacaoEquipamentoCommandHandler(IMovimentacaoEquipamentoPersistence persistence)
                => _persistence = persistence;

            public Task<MovimentacaoEquipamento> Handle(CriarMovimentacaoEquipamentoCommand request,
                CancellationToken cancellationToken)
                => _persistence.CriarMovimentacaoEquipamento(request.Movimentacao);
        }
    }
}
