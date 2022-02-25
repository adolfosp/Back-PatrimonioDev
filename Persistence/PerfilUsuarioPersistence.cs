using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence
{
    public class PerfilUsuarioPersistence : IPerfilUsuario
    {
        private readonly IApplicationDbContext _context;

        public PerfilUsuarioPersistence(IApplicationDbContext context)
            => _context = context;

        public async Task<PerfilUsuario> ObterInformacaoPerfil(int codigoUsuario) 
           => await _context.PerfilUsuario.FromSqlRaw("SELECT E.RazaoSocial, U.CodigoUsuario, UP.DescricaoPermissao, S.Nome AS NomeSetor, U.Nome AS NomeUsuario, U.Email, U.Senha FROM USUARIO AS U INNER JOIN USUARIOPERMISSAO AS UP ON UP.CodigoUsuarioPermissao = U.CodigoUsuarioPermissao INNER JOIN SETOR AS S ON S.CodigoSetor = U.CodigoSetor INNER JOIN EMPRESA AS E ON E.CodigoEmpresa = U.CodigoEmpresa WHERE U.Ativo = {0} AND U.CodigoUsuario = {1} ", true, codigoUsuario).FirstOrDefaultAsync();
        
    }
}
