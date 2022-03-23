using Aplicacao.Dtos;
using Domain.Entidades;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Persistence
{
    public interface IPerfilUsuarioPersistence
    {
        Task<PerfilUsuario> ObterInformacaoPerfil(int codigoUsuario);
        Task<int> AtualizarPerfilUsuario(PerfilUsuarioDto perfil);
    }
}
