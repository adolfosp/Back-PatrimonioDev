using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
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

            public AtualizarEmpresaCommandHandler(IEmpresaPersistence persistence)
                => _persistence = persistence;

            public async Task<(int CodigoStatus, string NomeEmpresa)> Handle(AtualizarEmpresaCommand command, CancellationToken cancellationToken)
               =>  await _persistence.AtualizarEmpresa(command.Id, command.Empresa);
      
        }
    }
}
