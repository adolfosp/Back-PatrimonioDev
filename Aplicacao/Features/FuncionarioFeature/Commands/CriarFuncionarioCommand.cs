using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.FuncionarioFeature.Commands
{
    public class CriarFuncionarioCommand : IRequest<Funcionario>
    {
        public FuncionarioDto FuncionarioDto { get; set; }

        public class CriarFuncionarioCommandHandler : IRequestHandler<CriarFuncionarioCommand, Funcionario>
        {

            private readonly IFuncionarioPersistence _persistence;
            private readonly IMapper _mapper;

            public CriarFuncionarioCommandHandler(IFuncionarioPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            }


            public async Task<Funcionario> Handle(CriarFuncionarioCommand command, CancellationToken cancellationToken)
            {
                var funcionario = _mapper.Map<Funcionario>(command.FuncionarioDto);
                return await _persistence.Adicionar(funcionario);
            }
        }
    }
}
