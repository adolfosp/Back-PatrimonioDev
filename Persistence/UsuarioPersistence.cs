﻿using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
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

            _mapper.Map(usuarioDto, usuario);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<int> DeletarUsuario(int id)
        {
            var usuario = await _context.Usuario.Where(x => x.CodigoUsuario == id).FirstOrDefaultAsync();

            if (usuario == null) return 404;

            usuario.Ativo = false;

            await _context.SaveChangesAsync();

            return 200;
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

        public async Task<Usuario> ObterUsuarioLogin(string email, string senha)
        {
            var usuario = await _context.Usuario.Where(x => x.Email == email && x.Senha == senha).Select(x => x).FirstOrDefaultAsync();

            if (usuario == null) return null;

            return usuario;
        }

        public async Task<Usuario> CriarUsuario(Usuario usuarioCadastrar)
        {
            _context.Usuario.Add(usuarioCadastrar);

            await _context.SaveChangesAsync();

            return usuarioCadastrar;
        }
    }
}
