using Aplicacao.Dtos;
using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IUsuarioPersistence
    {
        Task<int> AtualizarUsuario(UsuarioDto usuario, int id);
        Task<int> DeletarUsuario(int id);
        Task<IEnumerable<Usuario>> ObterTodosUsuario();
        Task<Usuario> ObterApenasUm(int id);
        Task<Usuario> ObterUsuarioLogin(string email, string senha);
        Task<Usuario> CriarUsuario(Usuario usuario);
    }
}
