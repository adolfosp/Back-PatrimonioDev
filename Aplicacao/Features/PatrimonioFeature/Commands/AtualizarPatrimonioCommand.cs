using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PatrimonioFeature.Commands
{
    public class AtualizarPatrimonioCommand : IRequest<int>
    {
        public int Id { get; set; }

        public PatrimonioDto Patrimonio { get; set; }
        public InformacaoAdicionalDto InformacaoAdicional { get; set; }

        public class AtualizarPatrimonioCommandHandler: IRequestHandler<AtualizarPatrimonioCommand,int>
        {
            private readonly IPatrimonioPersistence _persistence;
            private readonly IMapper _mapper;

            public AtualizarPatrimonioCommandHandler(IPatrimonioPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            }

            public Task<int> Handle(AtualizarPatrimonioCommand request, CancellationToken cancellationToken)
                => _persistence.AtualizarPatrimonio(request.Id, request.Patrimonio, request.InformacaoAdicional);
            
        }
    }
}
