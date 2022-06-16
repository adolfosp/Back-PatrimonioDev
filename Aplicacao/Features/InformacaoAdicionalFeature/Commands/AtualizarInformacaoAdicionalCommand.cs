using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.InformacaoAdicionalFeature.Commands
{
    public class AtualizarInformacaoAdicionalCommand : IRequest<int>
    {
        public int Id { get; set; }

        public InformacaoAdicionalDto InformacaoAdicional { get; set; }

        public class AtualizarInformacaoAdicionalHandler : IRequestHandler<AtualizarInformacaoAdicionalCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;


            public AtualizarInformacaoAdicionalHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<int> Handle(AtualizarInformacaoAdicionalCommand request, CancellationToken cancellationToken)
            {
                var informacaoAdicional = await _context.InformacaoAdicional.Where(x => x.CodigoInformacao == request.Id).FirstOrDefaultAsync();

                if (informacaoAdicional == null) return 404;

                //informacaoAdicional.DataCompra = request.InformacaoAdicional.DataCompra;
                //informacaoAdicional.DataExpiracaoGarantia = request.InformacaoAdicional.DataExpiracaoGarantia;
                informacaoAdicional.Antivirus = request.InformacaoAdicional.Antivirus;
                informacaoAdicional.VersaoWindows = request.InformacaoAdicional.VersaoWindows;
                informacaoAdicional.ValorPago = request.InformacaoAdicional.ValorPago;

                await _context.SaveChangesAsync();

                return 200;
            }
        }
    }
}
