using Aplicacao.Dtos;
using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using System.Threading.Tasks;

namespace DomainTests.TestesIntegracao.Repositories
{
    public class PerfilUsuarioRepositoryFake : IPerfilUsuarioPersistence
    {
        public Task<int> AtualizarPerfilUsuario(PerfilUsuarioDto perfil)
        {
            return Task.FromResult<int>(404);
        }

        public Task<PerfilUsuario> ObterInformacaoPerfil(int codigoUsuario)
        {
            return Task.FromResult<PerfilUsuario>(new PerfilUsuario());
        }
    }
}
