using Aplicacao.Dtos;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PerfilUsuarioFeature.Commands
{
    public class AtualizarPerfilCommand: IRequest<int>
    {
        public PerfilUsuarioDto PerfilDto { get; set; }

        public class AtualizarPerfilCommandHandler : IRequestHandler<AtualizarPerfilCommand, int>
        {
            private readonly IPerfilUsuarioPersistence _repository;

            public AtualizarPerfilCommandHandler(IPerfilUsuarioPersistence repository)         
               =>  _repository = repository;


            public Task<int> Handle(AtualizarPerfilCommand request, CancellationToken cancellationToken)
                => _repository.AtualizarPerfilUsuario(request.PerfilDto);
        }
    }
}
