using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Features.PatrimonioFeature.Queries
{
    public class ObterPatrimonioPorId : IRequest<Patrimonio>
    {
        public int Id { get; set; }

        public class ObterPatrimonioPorIdHandler : IRequestHandler<ObterPatrimonioPorId, Patrimonio>
        {
            private readonly IPatrimonioPersistence _persistence;

            public ObterPatrimonioPorIdHandler(IPatrimonioPersistence persistence)
                => _persistence = persistence;

            public async Task<Patrimonio> Handle(ObterPatrimonioPorId request, CancellationToken cancellationToken)
                => await _persistence.ObterPatrimonioPorId(request.Id);
        }
    }
}
