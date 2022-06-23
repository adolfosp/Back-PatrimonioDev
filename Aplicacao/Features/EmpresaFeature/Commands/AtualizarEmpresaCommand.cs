using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Commands
{
    public class AtualizarEmpresaCommand : IRequest<(int CodigoStatus, string NomeEmpresa)>
    {
        public int Id { get; set; }

        public EmpresaDto Empresa { get; set; }

        public class AtualizarEmpresaCommandHandler : IRequestHandler<AtualizarEmpresaCommand, (int CodigoStatus, string NomeEmpresa)>
        {
            private readonly IEmpresaPersistence _persistence;
            private readonly IMapper _mapper;

            public AtualizarEmpresaCommandHandler(IEmpresaPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;
            }

            public async Task<(int CodigoStatus, string NomeEmpresa)> Handle(AtualizarEmpresaCommand command, CancellationToken cancellationToken)
            {
                var empresa = _mapper.Map<Empresa>(command.Empresa);

                return await _persistence.Atualizar(command.Id, empresa);

            }

        }
    }
}
