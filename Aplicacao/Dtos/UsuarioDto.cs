﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao.Dtos
{
    public class UsuarioDto
    {

        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Senha { get; set; }
        [EmailAddress(ErrorMessage ="É preciso informar um e-mail válido")]
        public string Email { get; set; }
        [ForeignKey("Empresa")]
        public int CodigoEmpresa { get; set; }
        [ForeignKey("Setor")]
        public int CodigoSetor { get; set; }
        [ForeignKey("UsuarioPermissao")]
        public int CodigoPermissao { get; set; }
    }
}
