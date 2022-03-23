using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PerfilUsuarioFeature.Commands
{
    public class AtualizarPerfilCommand: IRequest<int>
    {
        public PerfilUsuarioDto Perfil { get; set; }

        public class AtualizarPerfilCommandHandler : IRequestHandler<AtualizarPerfilCommand, int>
        {
            private readonly IPerfilUsuarioPersistence _repository;

            public AtualizarPerfilCommandHandler(IPerfilUsuarioPersistence repository)         
               =>  _repository = repository;


            public Task<int> Handle(AtualizarPerfilCommand request, CancellationToken cancellationToken)
                => _repository.AtualizarPerfilUsuario(request.Perfil);
        }
    }
}
