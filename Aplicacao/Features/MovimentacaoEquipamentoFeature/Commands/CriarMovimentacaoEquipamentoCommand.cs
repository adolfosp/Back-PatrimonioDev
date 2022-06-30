using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.MovimentacaoEquipamentoFeature.Commands
{
    public class CriarMovimentacaoEquipamentoCommand : IRequest<MovimentacaoEquipamento>
    {
        public MovimentacaoEquipamentoDto Movimentacao { get; set; }

        public class CriarMovimentacaoEquipamentoCommandHandler : IRequestHandler<CriarMovimentacaoEquipamentoCommand, MovimentacaoEquipamento>
        {
            private readonly IMovimentacaoEquipamentoPersistence _persistence;
            private readonly IMapper _mapper;

            public CriarMovimentacaoEquipamentoCommandHandler(IMovimentacaoEquipamentoPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            }

            public Task<MovimentacaoEquipamento> Handle(CriarMovimentacaoEquipamentoCommand request,
                CancellationToken cancellationToken)
            {
                var movimentacao = new MovimentacaoEquipamento();

                _mapper.Map(request.Movimentacao, movimentacao);

                return _persistence.CriarMovimentacaoEquipamento(movimentacao);
            }

        }
    }
}
