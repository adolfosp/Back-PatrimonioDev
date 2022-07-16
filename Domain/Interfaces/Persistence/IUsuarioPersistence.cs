using Aplicacao.Dtos;
using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuarioPersistence
    {
        Task<int> Atualizar(Usuario usuario, int id);
        Task<Usuario> Deletar(int id);
        Task<IEnumerable<Usuario>> ObterTodosUsuario();
        Task<Usuario> ObterApenasUm(int id);
        Task<Usuario> ObterUsuarioLogin(string email, string senha, bool autenticacaoAuth);
        Task<bool> ObterUsuarioPorEmail(string email);
        Task<Usuario> Adicionar(Usuario usuario);
    }
}
