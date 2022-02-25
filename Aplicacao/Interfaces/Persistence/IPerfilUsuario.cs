using Domain.Entidades;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IPerfilUsuario
    {
        Task<PerfilUsuario> ObterInformacaoPerfil(int codigoUsuario);
    }
}
