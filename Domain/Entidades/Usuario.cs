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
        [MaxLength(25)]
        public string Senha { get; set; }

        [Required]
        [MinLength(10)]
        public string Email { get; set; }

        [ForeignKey("Empresa")]
        public int CodigoEmpresa { get; set; }
        public Empresa Empresa { get; set; }

        [ForeignKey("Setor")]
        public int CodigoSetor { get; set; }
        public Setor Setor { get; set; }

        [ForeignKey("UsuarioPermissao")]
        public int CodigoPermissao { get; set; }
        public UsuarioPermissao UsuarioPermissao { get; set; }
    }
}
