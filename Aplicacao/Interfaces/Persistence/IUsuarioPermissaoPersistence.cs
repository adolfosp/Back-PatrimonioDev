using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuarioPermissaoPersistence
    {
        Task<int> DeletarUsuarioPermissao(int codigoPermissao);
        Task<UsuarioPermissao> CriarUsuarioPermissao(UsuarioPermissao usuarioPermissao);
        Task<IEnumerable<UsuarioPermissao>> ObterTodasPermissoes();

    }
}
