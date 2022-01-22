using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.SetorFeature.Commands
{
    public class CriarSetorCommand : IRequest<Setor>
    {
        public SetorDto Setor { get; set; }

        public class CriarSetorCommandHandler : IRequestHandler<CriarSetorCommand, Setor>
        {
            private readonly IApplicationDbContext _context;
            public CriarSetorCommandHandler(IApplicationDbContext context)
                => _context = context;

            //REFATORAR: criar interface e tirar a responsabilidade da classe
            public async Task<Setor> Handle(CriarSetorCommand request, CancellationToken cancellationToken)
            {
                var setor = new Setor();

                setor.Nome = request.Setor.Nome;

                _context.Setor.Add(setor);

                await _context.SaveChangesAsync();

                return setor;

            }
        }
    }
}
