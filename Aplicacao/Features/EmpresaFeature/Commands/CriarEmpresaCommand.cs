using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.EmpresaFeature.Commands
{
    public class CriarEmpresaCommand : IRequest<(int CodigoStatus, string NomeEmpresa)>
    {
        public EmpresaDto Empresa { get; set; }

        public class CriarEquipamentoCommandHandler : IRequestHandler<CriarEmpresaCommand, (int CodigoStatus, string NomeEmpresa)>
        {
            private readonly IEmpresaPersistence _persistence;
            private readonly IMapper _mapper;

            public CriarEquipamentoCommandHandler(IEmpresaPersistence persistence, IMapper mapper)
            {
                _persistence = persistence;
                _mapper = mapper;

            }

            public async Task<(int CodigoStatus, string NomeEmpresa)> Handle(CriarEmpresaCommand command, CancellationToken cancellationToken)
            {
                var empresa = _mapper.Map<Empresa>(command.Empresa);

                return await _persistence.Adicionar(empresa);

            }
        }
    }
}
