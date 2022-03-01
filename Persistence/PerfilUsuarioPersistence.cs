﻿using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class PerfilUsuarioPersistence : IPerfilUsuario
    {
        private readonly IApplicationDbContext _context;

        public PerfilUsuarioPersistence(IApplicationDbContext context)
            => _context = context;

        public async Task<int> AtualizarPerfilUsuario(PerfilUsuarioDto perfil)
        {
            try
            {
                var usuarioPerfil = await _context.Usuario.Where(x => x.CodigoUsuario == perfil.CodigoUsuario).Select(x => x).FirstOrDefaultAsync();

                if (usuarioPerfil is null) return 404;


                usuarioPerfil.ImagemUrl = perfil.ImagemUrl;
                usuarioPerfil.Nome = perfil.NomeUsuario;
                usuarioPerfil.Senha = perfil.Senha;

                await _context.SaveChangesAsync();

                return 200;
            }
            catch(Exception ex)
            {
                return 500;
            }
          
        }

        public async Task<PerfilUsuario> ObterInformacaoPerfil(int codigoUsuario)
        {
            return (from u in _context.Usuario
                    join s in _context.Setor on u.CodigoSetor equals s.CodigoSetor
                    join e in _context.Empresa on u.CodigoEmpresa equals e.CodigoEmpresa
                    join p in _context.UsuarioPermissao on u.CodigoUsuarioPermissao equals p.CodigoUsuarioPermissao
                    where u.Ativo == true && u.CodigoUsuario == codigoUsuario
                    select new PerfilUsuario
                    {
                        CodigoUsuario = u.CodigoUsuario,
                        NomeSetor = s.Nome,
                        NomeUsuario = u.Nome,
                        DescricaoPermissao = p.DescricaoPermissao,
                        RazaoSocial = e.RazaoSocial,
                        Email = u.Email,
                        Senha = u.Senha,
                        ImagemUrl = u.ImagemUrl
                    }).FirstOrDefault();
        }

    }
}
