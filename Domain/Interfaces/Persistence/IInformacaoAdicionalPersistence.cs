using Aplicacao.Dtos;
using Domain.Entidades;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IInformacaoAdicionalPersistence
    {
        Task<int> Atualizar(InformacaoAdicional informacaoAdicional, int codigoInformacaoAdicional);
        Task<InformacaoAdicional> Adicionar(InformacaoAdicional informacaoAdicional);
        Task<int> Remover(int codigoInformacaoAdicional);

        Task<InformacaoAdicional> ObterPorCodigoInformacao(int codigoInformacaoAdicional);

    }
}
