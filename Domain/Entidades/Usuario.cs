using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Usuario
    {
        [Key]
        public int CodigoUsuario { get; set; }
        public bool Ativo { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(350)]
        public string Senha { get; set; }

        [NotMapped]
        public string Token { get; set; }

        [Required]
        [MinLength(10)]
        public string Email { get; set; }

        public string ImagemUrl { get; set; }

        public int? CodigoEmpresa { get; set; }
        [ForeignKey("CodigoEmpresa")]
        public Empresa Empresa { get; set; }

        public int? CodigoSetor { get; set; }
        [ForeignKey("CodigoSetor")]
        public Setor Setor { get; set; }

        public int CodigoUsuarioPermissao { get; set; }
        [ForeignKey("CodigoUsuarioPermissao")]
        public UsuarioPermissao UsuarioPermissao { get; set; }


    }
}
