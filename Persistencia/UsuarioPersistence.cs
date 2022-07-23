using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UsuarioPersistence : IUsuarioPersistence
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioPersistence(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<int> AtualizarUsuario(UsuarioDto usuarioDto, int id)
        {
            var usuario = await _context.Usuario.Where(x => x.CodigoUsuario == id && x.Ativo == true).Select(x => x).FirstOrDefaultAsync();

            if (usuario is null) return 404;

            usuarioDto.Senha = CriptografiaHelper.Criptografar(usuarioDto.Senha);

            _mapper.Map(usuarioDto, usuario);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<Usuario> DeletarUsuario(int id)
        {
            var usuario = await _context.Usuario.Where(x => x.CodigoUsuario == id).FirstOrDefaultAsync();

            if (usuario == null) return new Usuario();

            usuario.Ativo = false;

            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> ObterApenasUm(int id)
        {
            var usuario = await _context.Usuario.Where(x => x.CodigoUsuario == id && x.Ativo == true).Select(x => x).FirstOrDefaultAsync();

            if (usuario is null) return null;

            return usuario;
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuario()
        {
            var usuario = await _context.Usuario.Where(x => x.Ativo == true).ToListAsync();

            if (usuario == null) return null;

            return usuario.AsReadOnly();
        }

        public async Task<Usuario> ObterUsuarioLogin(string email, string senha, bool autenticacaoAuth)
        {

            Usuario usuario;

            usuario = await _context.Usuario.Where(x => x.Email == email).Select(x => x).FirstOrDefaultAsync();

            if (usuario is null) return null;

            if (!autenticacaoAuth)       
                return (CriptografiaHelper.Descriptografar(usuario.Senha) == senha) ? usuario: null;       

            return usuario;
        }


        public async Task<Usuario> CriarUsuario(Usuario usuarioCadastrar)
        {

            usuarioCadastrar.Senha = CriptografiaHelper.Criptografar(usuarioCadastrar.Senha);
            usuarioCadastrar.Ativo = true;

            _context.Usuario.Add(usuarioCadastrar);

            await _context.SaveChangesAsync();

            return usuarioCadastrar;
        }

        public async Task<bool> ObterUsuarioPorEmail(string email)
        {
            var usuario = await _context.Usuario.Where(x => x.Email == email).Select(x => x).FirstOrDefaultAsync();

            if (usuario is null) return false;

            return true;
        }
    }
}
