using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.InformacaoAdicionalFeature.Commands
{
    public class CriarInformacaoAdicionalCommand : IRequest<InformacaoAdicional>
    {
        public InformacaoAdicionalDto InformacaoAdicional { get; set; }

        public class CriarInformacaoCommandHandler : IRequestHandler<CriarInformacaoAdicionalCommand, InformacaoAdicional>
        {

            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CriarInformacaoCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<InformacaoAdicional> Handle(CriarInformacaoAdicionalCommand request, CancellationToken cancellationToken)
            {
                var informacaoAdicional = new InformacaoAdicional();
                informacaoAdicional = _mapper.Map<InformacaoAdicional>(request.InformacaoAdicional);

                await _context.InformacaoAdicional.AddAsync(informacaoAdicional);

                await _context.SaveChangesAsync();

                return informacaoAdicional;
            }
        }
    }
}
