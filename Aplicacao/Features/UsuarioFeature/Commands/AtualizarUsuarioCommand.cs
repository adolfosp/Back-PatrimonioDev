using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.UsuarioFeature.Commands
{
    public class AtualizarUsuarioCommand : IRequest<int>
    {
        public int CodigoUsuario { get; set; }

        public UsuarioDto UsuarioDto { get; set; }

        public class AtualizarUsuarioHandler : IRequestHandler<AtualizarUsuarioCommand, int>
        {
            private readonly IUsuarioPersistence _persistence;
            private readonly IMapper _mapper;

            public AtualizarUsuarioHandler(IUsuarioPersistence persistence, IMapper mapper)
            {
                _mapper = mapper;
                _persistence = persistence;
            }


            public async Task<int> Handle(AtualizarUsuarioCommand command, CancellationToken cancellationToken)
            {
                var usuario = _mapper.Map<Usuario>(command.UsuarioDto);

                return await _persistence.Atualizar(usuario, command.CodigoUsuario);
            }
        }
    }
}
