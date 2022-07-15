using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioFeature.Commands
{
    public class CriarUsuarioCommand : IRequest<Usuario>
    {
        public UsuarioDto Usuario { get; set; }

        public class CriarUsuarioHandler : IRequestHandler<CriarUsuarioCommand, Usuario>
        {

            private readonly IUsuarioPersistence _persistence;
            private readonly IMapper _mapper;

            public CriarUsuarioHandler(IUsuarioPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            } 


            public Task<Usuario> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
            {
                var usuario = _mapper.Map<Usuario>(request.Usuario);

                return _persistence.CriarUsuario(usuario);

            }
        }
    }
}
