using Aplicacao.Interfaces;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Aplicacao.Dtos;

namespace Persistence
{
    public class UsuarioPermissaoPersistence : IUsuarioPermissaoPersistence
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioPermissaoPersistence(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AtualizarUsuarioPermissao(UsuarioPermissaoDto permissaoDto, int id)
        {

            var permissaoUsuario = await _context.UsuarioPermissao.Where(x => x.CodigoUsuarioPermissao == id && x.Ativo == true).Select(x => x).FirstOrDefaultAsync();

            if (permissaoUsuario is null) return 404;

            _mapper.Map(permissaoDto, permissaoUsuario);

            await _context.SaveChangesAsync();

            return 200;

        }

        public async Task<UsuarioPermissao> CriarUsuarioPermissao(UsuarioPermissao usuarioPermissao)
        {
            var usuario = new UsuarioPermissao();

            usuario.DescricaoPermissao = usuarioPermissao.DescricaoPermissao;
            usuario.Ativo = usuarioPermissao.Ativo;


            _context.UsuarioPermissao.Add(usuario);

            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<int> DeletarUsuarioPermissao(int codigoPermissao)
        {
            var usuario = await _context.UsuarioPermissao.Where(x => x.CodigoUsuarioPermissao == codigoPermissao).FirstOrDefaultAsync();

            if (usuario == null) return 404;

            usuario.Ativo = false;

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<UsuarioPermissao> ObterApenasUmaPermissao(int codigoPermissao)
        {
            var usuarioPermissao = await _context.UsuarioPermissao.Where(x => x.CodigoUsuarioPermissao == codigoPermissao && x.Ativo == true).Select(x => x).FirstOrDefaultAsync();

            if (usuarioPermissao is null) return null;

            return usuarioPermissao;
        }

        public async Task<IEnumerable<UsuarioPermissao>> ObterTodasPermissoes()
            => await _context.UsuarioPermissao.FromSqlRaw("SELECT * FROM UsuarioPermissao WHERE Ativo = {0}", true).ToListAsync();


    }
}
