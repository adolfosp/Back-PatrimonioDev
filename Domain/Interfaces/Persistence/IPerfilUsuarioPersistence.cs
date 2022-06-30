using Aplicacao.Dtos;
using Domain.Entidades;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IPerfilUsuarioPersistence
    {
        Task<PerfilUsuario> ObterInformacaoPerfil(int codigoUsuario);
        Task<int> AtualizarPerfilUsuario(PerfilUsuarioDto perfil);
    }
}
